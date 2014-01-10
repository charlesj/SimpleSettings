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
	/// <summary>
	/// The settings base creates a basis for using ApplicationSettings.
	/// </summary>
	public abstract class Settings
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="Settings"/> class.
		/// </summary>
		/// <param name="typeConverter">
		/// The type Converter.
		/// </param>
		/// <param name="reader">
		/// The reader.
		/// </param>
		protected Settings(ITypeConverter typeConverter = null, IConfigurationReader reader = null)
		{
			if (typeConverter == null)
			{
				typeConverter = new TypeConverter();
			}

			this.TypeConverter = typeConverter;

			if (reader == null)
			{
				reader = new ConfigurationReader();
			}

			this.ConfigurationReader = reader;
		}

		/// <summary>
		/// Gets or sets the type converter.
		/// </summary>
		protected ITypeConverter TypeConverter { get; set; }

		/// <summary>
		/// Gets or sets the configuration reader.
		/// </summary>
		protected IConfigurationReader ConfigurationReader { get; set; }

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
					throw new SettingsException(message);
				}
			}
		}
	}
}