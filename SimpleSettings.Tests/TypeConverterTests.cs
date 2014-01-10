﻿// --------------------------------------------------------------------------------------------------------------------
// <copyright file="TypeConverterTests.cs" company="Josh Charles">
//   Copyright 2013 Josh Charles.  Released under the MIT License.
// </copyright>
// <summary>
//   Defines the TypeConverterTests type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace SimpleSettings.Tests
{
	using System;
	using System.Diagnostics.CodeAnalysis;

	using Xunit;
	using Xunit.Extensions;

	[SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1600:ElementsMustBeDocumented", Justification = "Reviewed. Suppression is OK here.")]
	public class TypeConverterTests
	{
		private readonly TypeConverter typeConverter;

		public TypeConverterTests()
		{
			this.typeConverter = new TypeConverter();
		}

		[Theory]
		[InlineData("1", typeof(int))]
		[InlineData("B6A7EAF2-08A1-4DD3-BD19-DB95BFA59EDF", typeof(Guid))]
		[InlineData("true", typeof(bool))]
		public void CanConvertWithoutThrowing(object source, Type target)
		{
			Assert.DoesNotThrow(() => this.typeConverter.Convert(source, target));
		}

		[Fact]
		public void ThrowsOnInvalidConversion()
		{
			Assert.Throws<SettingsException>(() => this.typeConverter.Convert<int>("Hello"));
		}
	}
}