// --------------------------------------------------------------------------------------------------------------------
// <copyright file="SettingsException.cs" company="Josh Charles">
//   Copyright 2013 Josh Charles.  Released under the MIT License.
// </copyright>
// <summary>
//   The settings exception.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace SimpleSettings
{
	using System;

	/// <summary>
	/// Exceptions thrown in this library should be of this type.
	/// </summary>
	public class SettingsException : Exception
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="SettingsException"/> class.
		/// </summary>
		public SettingsException()
		{
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="SettingsException"/> class.
		/// </summary>
		/// <param name="message">
		/// The message.
		/// </param>
		public SettingsException(string message) : base(message)
		{
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="SettingsException"/> class.
		/// </summary>
		/// <param name="message">
		/// The message.
		/// </param>
		/// <param name="inner">
		/// The inner.
		/// </param>
		public SettingsException(string message, Exception inner) : base(message, inner)
		{
		}
	}
}