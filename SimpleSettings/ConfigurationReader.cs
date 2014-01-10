// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ConfigurationReader.cs" company="Josh Charles">
//   Copyright 2013 Josh Charles.  Released under the MIT License.
// </copyright>
// <summary>
//   The configuration reader.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace SimpleSettings
{
	using System.Configuration;

	/// <summary>
	/// The configuration reader.
	/// </summary>
	public class ConfigurationReader : IConfigurationReader
	{
		/// <summary>
		/// The type converter.
		/// </summary>
		private readonly ITypeConverter typeConverter;

		/// <summary>
		/// Initializes a new instance of the <see cref="ConfigurationReader"/> class.
		/// </summary>
		/// <param name="typeConverter">
		/// The type converter.
		/// </param>
		public ConfigurationReader(ITypeConverter typeConverter = null)
		{
			if (typeConverter == null)
			{
				typeConverter = new TypeConverter();
			}

			this.typeConverter = typeConverter;
		}

		/// <summary>
		/// Gets a value from the configuration manager.
		/// </summary>
		/// <param name="key">
		/// The key in the configuration file.
		/// </param>
		/// <returns>
		/// The <see cref="string"/>.
		/// </returns>
		public string GetValue(string key)
		{
			var value = ConfigurationManager.AppSettings[key];
			if (string.IsNullOrEmpty(value))
			{
				string message = string.Format("Missing Settings Value: {0}", key);
				throw new SettingsException(message);
			}

			return value;
		}

		/// <summary>
		/// Gets the value generically.
		/// </summary>
		/// <param name="key">
		/// The key.
		/// </param>
		/// <typeparam name="TSettingsType">
		/// The type of the settings value.
		/// </typeparam>
		/// <returns>
		/// The <see cref="TSettingsType"/>.
		/// </returns>
		public TSettingsType GetValue<TSettingsType>(string key)
		{
			return this.typeConverter.Convert<TSettingsType>(this.GetValue(key));
		}
	}
}