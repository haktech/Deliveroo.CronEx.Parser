using Deliveroo.CronEx.Parser.Core.Constants;
using Deliveroo.CronEx.Parser.Core.Interfaces;
using Deliveroo.CronEx.Parser.Infrastructure.CronExpressionInterpreter;
using Deliveroo.CronEx.Parser.Infrastructure.Services;
using Deliveroo.CronEx.Parser.Infrastructure.Validators;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;

namespace Deliveroo.CronEx.Parser.Acceptance.Tests
{
    public class CronExpressionServiceTests
    {
        private CronExpressionService _cronExpressionService;

        public CronExpressionServiceTests()
        {
            this._cronExpressionService = new CronExpressionService(new ComponentInterpreter(new FieldValidatorSimpleFactory()));
        }

        [Theory(DisplayName = "Should throw exception when cron expression is invalid")]
        [InlineData("*/15 0 1,32 * 1-5 /usr/bin/find")] // Invalid month days (32)
        [InlineData("1/15 0 1,15 * 1-5 /usr/bin/find")] // Invalid Interval field (1/15)
        [InlineData("*/60 0 1,15 * 1-5 /usr/bin/find")] // Invalid minute (60)
        [InlineData("*/15 70 1,15 * 1-5 /usr/bin/find")]// Invalid hour (70)
        [InlineData("*&15 0 1,15 * 1-5 /usr/bin/find")] // Invaid minute field operator (&)
        [InlineData("*/15 0 1,15 * 1-8 /usr/bin/find")] // Invalid Week days (8)
        [InlineData("*/15 0 1,15 13 1-5 /usr/bin/find")]// Invalid Month (13)
        [InlineData("*/15 0 1,15 * 1%5 /usr/bin/find")] // Invalid week day operator (%)
        [InlineData("xxxxxx")] // Invalid format
        public void Test01(string cronExpression)
        {
            Assert.Throws<FormatException>(() => this._cronExpressionService.Parse(cronExpression));
        }

        [Fact(DisplayName = "Should be able to parse cron expression properly when it is correct")]
        public void Test02()
        {
            // Arrange
            var cronExpression = "*/15 0 1,15 * 1-5 /usr/bin/find";
            var expectedResult = new Dictionary<CronExpressionConponentType, List<string>>()
            {
                { CronExpressionConponentType.Minute, new List<string>{ "0", "15", "30", "45" } },
                { CronExpressionConponentType.Hour, new List<string>{ "0" } },
                { CronExpressionConponentType.DayOfMonth, new List<string>{ "1", "15" } },
                { CronExpressionConponentType.Month, new List<string>{ "1", "2", "3", "4", "5", "6", "7", "8", "9", "10", "11", "12" } },
                { CronExpressionConponentType.DayOfWeek, new List<string>{ "1", "2", "3", "4", "5" } },
                { CronExpressionConponentType.Command, new List<string>{ "/usr/bin/find"} }
            };

            // Act
            var parseObject = this._cronExpressionService.Parse(cronExpression);

            // Assert 
            foreach (var item in parseObject)
            {
                item.Value.ForEach(x => { expectedResult[item.Key].Any(b => b == x).ShouldBe(true); });
            }
        }
    }
}
