using System;
using System.Data.OleDb;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;
using System.Xml.Linq;
using System.Xml.Serialization;

namespace URANG_Unique_Random_Number_Generator
{
    public partial class Main : Form
    {
        private readonly OleDbCommand _command;
        private readonly Config _config;
        private readonly OleDbConnection _connection;
        private readonly Random _random;
        private double _counter;
        private OleDbDataReader _reader;
        private bool _succesfull;

        public Main()
        {
            _connection = new OleDbConnection();
            _command = new OleDbCommand();
            var location = Assembly.GetExecutingAssembly().Location;
            try
            {
                if (location == null)
                    throw new ArgumentNullException(nameof(location));
                var configFile = Path.Combine(Directory.GetParent(location).FullName, "URANG_DB.accdb");
                _connection.ConnectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" +
                                               configFile + ";Persist Security Info=False";
                _command.Connection = _connection;
                _random = new Random();
                _succesfull = false;
                configFile = Path.Combine(Directory.GetParent(location).FullName, "Config.xml");
                _config = InitConfiguration(configFile);
                InitializeComponent();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private Config InitConfiguration(string filename)
        {
            try
            {
                var xDocument = XDocument.Load(filename);
                return CreateObjectsFromString<Config>(xDocument);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                return null;
            }
        }

        private T CreateObjectsFromString<T>(XDocument xDocument)
        {
            var xmlSerializer = new XmlSerializer(typeof(T));
            return (T) xmlSerializer.Deserialize(new StringReader(xDocument.ToString()));
        }

        private void button_Generate_Click(object sender, EventArgs e)
        {
            try
            {
                _counter = 0;
                numericUpDown_Length.Enabled = false;
                button_Generate.Enabled = false;

                do
                {
                    //Generate new random string
                    var tempResult =
                        new string(
                            Enumerable.Repeat(_config.Chars, (int) numericUpDown_Length.Value)
                                .Select(s => s[_random.Next(s.Length)])
                                .ToArray());

                    //Connect to DB
                    _command.CommandText = "SELECT KeyName FROM Keys WHERE KeyName = '" + tempResult + "'";
                    _connection.Open();
                    _reader = _command.ExecuteReader();

                    //If Empty --> Value doesn't exist --> Create new one
                    if (_reader != null && !_reader.HasRows)
                    {
                        _reader.Close();
                        _connection.Close();
                        _connection.Open();
                        _command.CommandText = "INSERT INTO Keys (KeyName) VALUES('" + tempResult + "')";
                        textBox_Generate.Text = tempResult;
                        numericUpDown_Length.Enabled = true;
                        button_Generate.Enabled = true;
                        _command.ExecuteNonQuery();
                        _succesfull = true;
                        _reader.Close();
                        _connection.Close();
                        _counter = 0;
                    }
                    else if (_counter >= Math.Pow(_config.Chars.Length, (double) numericUpDown_Length.Value) * 0.55)
                    {
                        _reader?.Close();
                        _connection.Close();
                        textBox_Generate.Text = @"Couldn't find another unique random number with length " +
                                                numericUpDown_Length.Value;
                        break;
                    }
                    else
                    {
                        _reader?.Close();
                        _connection.Close();
                        _counter++;
                    }
                } while (_succesfull == false);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
    }
}