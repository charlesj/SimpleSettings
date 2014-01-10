// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ITypeConverter.cs" company="Josh Charles">
//   Copyright 2013 Josh Charles.  Released under the MIT License.
// </copyright>
// <summary>
//   Defines the ITypeConverter type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace SimpleSettings
{
	using System;

	/// <summary>
	/// The TypeConverter interface.
	/// </summary>
	public interface ITypeConverter
	{
		/// <summary>
		/// Converts an object to another type, with some error checking.
		/// </summary>
		/// <param name="value">
		/// The value is the object to convert from.
		/// </param>
		/// <param name="targetType">
		/// The target type.
		/// </param>
		/// <returns>
		/// The <see cref="object"/>.
		/// </returns>
		/// <exception cref="Exception">
		/// Throws an exception if the requested conversion is not valid.
		/// </exception>
		object Convert(object value, Type targetType);

		/// <summary>
		/// Converts an object to another type generically.
		/// </summary>
		/// <param name="value">
		/// The value.
		/// </param>
		/// <typeparam name="TTargetType">
		/// The type to target.
		/// </typeparam>
		/// <returns>
		/// The <see cref="TTargetType"/>.
		/// </returns>
		TTargetType Convert<TTargetType>(object value);
	}
}