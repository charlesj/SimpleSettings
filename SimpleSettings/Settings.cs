// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Settings.cs" company="Josh Charles">
//   Copyright 2013 Josh Charles.  Released under the MIT License.
// </copyright>
// <summary>
//   The settings base creates a basis for using ApplicationSettings.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace SimpleSettings
{
	using System;
	using System.Configuration;

	/// <summary>
	/// The settings base creates a basis for using ApplicationSettings.
	/// </summary>
	public abstract class Settings 
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="Settings"/> class.
		/// </summary>
		protected Settings()
		{
			this.TypeConverter = new TypeConverter();
		}

		/// <summary>
		/// Gets the type converter.
		/// </summary>
		protected TypeConverter TypeConverter { get; private set; }

		/// <summary>
		/// The check all setting for values.
		/// </summary>
		public void CheckAllSettingForValues()
		{
			var properties = this.GetProperties();
			foreach (var property in properties)
			{
				var value = property.GetValue(this);
				if (value == null)
				{
					var message = string.Format("Settings property is missing value: {0}", property.Name);
					throw new Exception(message);
				}
			}
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
		protected string GetValue(string key)
		{
			var value = ConfigurationManager.AppSettings[key];
			if (string.IsNullOrEmpty(value))
			{
				string message = string.Format("Missing Settings Value: {0}", key);
				throw new Exception(message);
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
		protected TSettingsType GetValue<TSettingsType>(string key)
		{
			return this.TypeConverter.Convert<TSettingsType>(this.GetValue(key));
		}
	}
}