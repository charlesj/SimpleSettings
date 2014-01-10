// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ConfigurationReaderTests.cs" company="Josh Charles">
//   Copyright 2013 Josh Charles.  Released under the MIT License.
// </copyright>
// <summary>
//   Defines the ConfigurationReaderTests type.
//   It is important to note that this test depends on values in the application configuration file.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace SimpleSettings.Tests
{
	using System;
	using System.Diagnostics.CodeAnalysis;

	using Xunit;

	[SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1600:ElementsMustBeDocumented", Justification = "Reviewed. Suppression is OK here.")]
	public class ConfigurationReaderTests
	{
		public ConfigurationReaderTests()
		{
			this.SystemUnderTest = new ConfigurationReader();
		}

		protected ConfigurationReader SystemUnderTest { get; set; }

		[Fact]
		public void CanReadValueCorrectly()
		{
			Assert.Equal("wokka wokka", this.SystemUnderTest.GetValue("password"));
		}

		[Fact]
		public void CanReadInt()
		{
			Assert.Equal(42, this.SystemUnderTest.GetValue<int>("answer"));
		}

		[Fact]
		public void ThrowsExceptionOnMissingValue()
		{
			Assert.Throws<SettingsException>(() => this.SystemUnderTest.GetValue("Nope"));
		}

		[Fact]
		public void ExceptionMessageIncludesPropertyName()
		{
			try
			{
				this.SystemUnderTest.GetValue("Nope");
			}
			catch (Exception exception)
			{
				Assert.Contains("Nope", exception.Message);
				return;
			}

			throw new Exception("Test Fails");
		}

		[Fact]
		public void ExceptionThrownOnEmptyString()
		{
			Assert.Throws<SettingsException>(() => this.SystemUnderTest.GetValue("missing"));
		}
	}
}