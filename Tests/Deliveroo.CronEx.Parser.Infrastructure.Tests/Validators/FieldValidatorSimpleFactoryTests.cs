using Deliveroo.CronEx.Parser.Infrastructure.Validators;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Deliveroo.CronEx.Parser.Infrastructure.Tests.Validators
{
    public class FieldValidatorSimpleFactoryTests
    {
        private FieldValidatorSimpleFactory _instance = new FieldValidatorSimpleFactory();

        [Theory(DisplayName = "Should throw ArgumentNullException when field expression is empty or null")]
        [InlineData("")]
        [InlineData(null)]
        public void Test01(string fieldExpression)
        {
            Assert.Throws<ArgumentNullException>(() => { _instance.Create(fieldExpression); });
        }

        [Theory(DisplayName = "Should return the right Field validator based field expression")]
        [ClassData(typeof(ExpectedValidators))]
        public void Test02(string fieldExpression, object expectedItemQualityCalculator)
        {
            var resolvedQualityCalculator = this._instance.Create(fieldExpression);

            resolvedQualityCalculator.ShouldBeOfType(expectedItemQualityCalculator.GetType());
        }
    }
}
