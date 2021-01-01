// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Main.cs" company="Hämmer Electronics">
//   Copyright (c) All rights reserved.
// </copyright>
// <summary>
//   The main form.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace URANG_Unique_Random_Number_Generator
{
    using System;
    using System.Data.OleDb;
    using System.IO;
    using System.Linq;
    using System.Reflection;
    using System.Windows.Forms;
    using System.Xml.Linq;
    using System.Xml.Serialization;

    /// <summary>
    /// The main form.
    /// </summary>
    public partial class Main : Form
    {
        /// <summary>
        /// The command.
        /// </summary>
        private readonly OleDbCommand command;

        /// <summary>
        /// The configuration.
        /// </summary>
        private readonly Config config;

        /// <summary>
        /// The connection.
        /// </summary>
        private readonly OleDbConnection connection;

        /// <summary>
        /// The random generator.
        /// </summary>
        private readonly Random random;

        /// <summary>
        /// The counter.
        /// </summary>
        private double counter;

        /// <summary>
        /// The reader.
        /// </summary>
        private OleDbDataReader reader;

        /// <summary>
        /// A value indicating whether the process was successful or not.
        /// </summary>
        private bool successful;

        /// <summary>
        /// Initializes a new instance of the <see cref="Main"/> class.
        /// </summary>
        public Main()
        {
            this.connection = new OleDbConnection();
            this.command = new OleDbCommand();
            var location = Assembly.GetExecutingAssembly().Location;

            try
            {
                var configFile = Path.Combine(Directory.GetParent(location)?.FullName ?? string.Empty, "URANG_DB.accdb");
                this.connection.ConnectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" +
                                                    configFile + ";Persist Security Info=False";
                this.command.Connection = this.connection;
                this.random = new Random();
                this.successful = false;
                configFile = Path.Combine(Directory.GetParent(location)?.FullName ?? string.Empty, "Config.xml");
                this.config = InitConfiguration(configFile);
                this.InitializeComponent();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        /// <summary>
        /// Loads the configuration.
        /// </summary>
        /// <param name="fileName">The file name.</param>
        /// <returns>The <see cref="Config"/>.</returns>
        private static Config InitConfiguration(string fileName)
        {
            try
            {
                var xDocument = XDocument.Load(fileName);
                return CreateObjectsFromString<Config>(xDocument);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                return null;
            }
        }

        /// <summary>
        /// Creates an object from the <see cref="string"/>.
        /// </summary>
        /// <typeparam name="T">The type parameter.</typeparam>
        /// <param name="xDocument">The x document.</param>
        /// <returns>A new object of type <see cref="T"/>.</returns>
        private static T CreateObjectsFromString<T>(XDocument xDocument)
        {
            var xmlSerializer = new XmlSerializer(typeof(T));
            return (T)xmlSerializer.Deserialize(new StringReader(xDocument.ToString()));
        }

        /// <summary>
        /// Handles the generate button click event.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The event args.</param>
        private void ButtonGenerateClick(object sender, EventArgs e)
        {
            try
            {
                this.counter = 0;
                this.numericUpDownLength.Enabled = false;
                this.buttonGenerate.Enabled = false;

                do
                {
                    // Generate new random string
                    var tempResult = new string(
                        Enumerable.Repeat(this.config.Chars, (int)this.numericUpDownLength.Value)
                            .Select(s => s[this.random.Next(s.Length)]).ToArray());

                    // Connect to DB
                    this.command.CommandText = "SELECT KeyName FROM Keys WHERE KeyName = '" + tempResult + "'";
                    this.connection.Open();
                    this.reader = this.command.ExecuteReader();

                    // If empty --> Value doesn't exist --> Create new one
                    if (this.reader != null && !this.reader.HasRows)
                    {
                        this.reader.Close();
                        this.connection.Close();
                        this.connection.Open();
                        this.command.CommandText = "INSERT INTO Keys (KeyName) VALUES('" + tempResult + "')";
                        this.textBoxGenerate.Text = tempResult;
                        this.numericUpDownLength.Enabled = true;
                        this.buttonGenerate.Enabled = true;
                        this.command.ExecuteNonQuery();
                        this.successful = true;
                        this.reader.Close();
                        this.connection.Close();
                        this.counter = 0;
                    }
                    else if (this.counter >= Math.Pow(this.config.Chars.Length, (double)this.numericUpDownLength.Value) * 0.55)
                    {
                        this.reader?.Close();
                        this.connection.Close();
                        this.textBoxGenerate.Text = @"Couldn't find another unique random number with length "
                                                    + this.numericUpDownLength.Value;
                        break;
                    }
                    else
                    {
                        this.reader?.Close();
                        this.connection.Close();
                        this.counter++;
                    }
                }
                while (this.successful == false);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
    }
}