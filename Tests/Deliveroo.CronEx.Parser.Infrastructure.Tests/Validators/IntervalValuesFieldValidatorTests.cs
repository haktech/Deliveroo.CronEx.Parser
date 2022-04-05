using Deliveroo.CronEx.Parser.Infrastructure.Validators;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Deliveroo.CronEx.Parser.Infrastructure.Tests.Validators
{
    public class IntervalValuesFieldValidatorTests
    {
        private IntervalValuesFieldValidator _instance = new IntervalValuesFieldValidator();

        [Theory(DisplayName = "Should throw ArgumentNullException when field is empty or null")]
        [InlineData("")]
        [InlineData(null)]
        public void Test01(string field)
        {
            Assert.Throws<ArgumentNullException>(() => { _instance.Validate(field, Core.Constants.CronExpressionConponentType.Minute); });
        }

        [Fact(DisplayName = "Should throw FormatException when field doesn't contain interval char '/'")]
        public void Test02()
        {
            Assert.Throws<FormatException>(() => { _instance.Validate("*15", Core.Constants.CronExpressionConponentType.Minute); });
        }

        [Theory(DisplayName = "Should throw FormatException when field doesn't interval char '/' is not preceeded and followed by chars/digits")]
        [InlineData("*/")]
        [InlineData("/15")]
        public void Test03(string field)
        {
            Assert.Throws<FormatException>(() => { _instance.Validate(field, Core.Constants.CronExpressionConponentType.Minute); });
        }

        [Fact(DisplayName = "Should throw FormatException when field expression doesn't start with '*'")]
        public void Test04()
        {
            Assert.Throws<FormatException>(() => { _instance.Validate("1/15", Core.Constants.CronExpressionConponentType.Minute); });
        }

        [Fact(DisplayName = "Should throw FormatException when field value is out of component type boundries example (Month: 1-12)")]
        public void Test05()
        {
            Assert.Throws<FormatException>(() => { _instance.Validate("*/13", Core.Constants.CronExpressionConponentType.Month); });
        }
    }
}
