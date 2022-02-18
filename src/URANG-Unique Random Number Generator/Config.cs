// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Config.cs" company="Hämmer Electronics">
//   Copyright (c) All rights reserved.
// </copyright>
// <summary>
//   The configuration class.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace URANG_Unique_Random_Number_Generator;

/// <summary>
/// The configuration class.
/// </summary>
public class Config
{
    /// <summary>
    /// Gets or sets the chars.
    /// </summary>
    public string Chars { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets the density.
    /// </summary>
    public double Density { get; set; }
}
