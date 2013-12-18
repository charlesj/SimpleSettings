// --------------------------------------------------------------------------------------------------------------------
// <copyright file="TypeConverter.cs" company="Josh Charles">
//   Copyright 2013 Josh Charles.  Released under the MIT License.
// </copyright>
// <summary>
//   The type converter is used to genericly convert an object from one type to another.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace SimpleSettings
{
	using System;
	using System.ComponentModel;

	/// <summary>
	/// The type converter is used to generically convert an object from one type to another.
	/// </summary>
	public class TypeConverter
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
		public object Convert(object value, Type targetType)
		{
			var converter = TypeDescriptor.GetConverter(targetType);
			if (!converter.IsValid(value) || !converter.CanConvertFrom(value.GetType()))
			{
				// TODO: Make this a better exception.
				throw new Exception("Attempted to convert to a type that was not valid.");
			}

			if (value is string)
			{
				return converter.ConvertFromString(value as string);
			}

			return converter.ConvertTo(value, targetType);
		}

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
		public TTargetType Convert<TTargetType>(object value)
		{
			return (TTargetType)this.Convert(value, typeof(TTargetType));
		}
	}
}
