// --------------------------------------------------------------------------------------------------------------------
// <copyright file="BaseSettings.cs" company="Josh Charles">
//   Copyright 2013 Josh Charles.  Released under the MIT License.
// </copyright>
// <summary>
//   This settings object uses reflection to load the settings from application configuration.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace SimpleSettings
{
	using System;

	/// <summary>
	/// This settings object uses reflection to load the settings from application configuration.
	/// </summary>
	public abstract class BaseSettings : Settings
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="BaseSettings"/> class.
		/// </summary>
		/// <param name="typeConverter">
		/// The type Converter.
		/// </param>
		/// <param name="reader">
		/// The reader.
		/// </param>
		protected BaseSettings(ITypeConverter typeConverter = null, IConfigurationReader reader = null) : base(typeConverter, reader)
		{
			this.LoadSettingsUsingReflection();
		}

		/// <summary>
		/// Sets the values of the properties of this object with the values from the application configuration file.
		/// </summary>
		protected void LoadSettingsUsingReflection()
		{
			var properties = this.GetProperties();
			foreach (var property in properties)
			{
				try
				{
					var settingsValue = this.ConfigurationReader.GetValue(property.Name);
					var propertyType = property.PropertyType;
					var typedValue = this.TypeConverter.Convert(settingsValue, propertyType);
					property.SetValue(this, typedValue);
				}
				catch (Exception exception)
				{
					string message = string.Format("Error trying to set a value for {0} from application configuration.  See inner exception for more details.", property.Name);
					throw new SettingsException(message, exception);
				}
			}
		}
	}
}