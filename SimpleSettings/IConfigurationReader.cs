// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IConfigurationReader.cs" company="Josh Charles">
//   Copyright 2013 Josh Charles.  Released under the MIT License.
// </copyright>
// <summary>
//   Defines the IConfigurationReader type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace SimpleSettings
{
	using System;

	public interface IConfigurationReader
	{
		/// <summary>
		/// Gets the Value from the Application Configuration
		/// </summary>
		/// <param name="key">
		/// The key.
		/// </param>
		/// <returns>
		/// The <see cref="string"/>.
		/// </returns>
		string GetValue(string key);

		/// <summary>
		/// Gets the value generically.
		/// </summary>
		/// <param name="key">
		/// The key.
		/// </param>
		/// <typeparam name="TSettingsType">
		/// The target type.
		/// </typeparam>
		/// <returns>
		/// The <see cref="TSettingsType"/>.
		/// </returns>
		TSettingsType GetValue<TSettingsType>(string key);
	}
}