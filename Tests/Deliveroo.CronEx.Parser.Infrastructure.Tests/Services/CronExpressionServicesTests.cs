using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Deliveroo.CronEx.Parser.Infrastructure.Tests.Services
{
    public class CronExpressionServicesTests
    {
        private CronExpressionServiceSteps _steps = new CronExpressionServiceSteps();

        [Theory(DisplayName = "Should throw ArgumentNullException when cron expression is null or empty")]
        [InlineData("")]
        [InlineData(null)]
        public void Test01(string cronExpression)
        {
            Assert.Throws<ArgumentNullException>(() => { this._steps.GivenISetupService().WhenIExecuteService(cronExpression); });
        }

        [Theory(DisplayName = "Should throw FormatException when cron expression doesnt contain 5 time fields + 1 command")]
        [InlineData("*/15 0 1,15 * /usr/bin/find")]
        [InlineData("*/15 0 1,15 * 1-5")]
        public void Test02(string cronExpression)
        {
            Assert.Throws<FormatException>(() => { this._steps.GivenISetupService().WhenIExecuteService(cronExpression); });
        }

        [Fact(DisplayName = "Should parse non empty cron expression with valid time fields and command")]
        public void Test03()
        {
            this._steps.GivenISetupService().WhenIExecuteService("*/15 0 1,15 * 1-5 /usr/bin/find").ThenIShouldExpectSuccess();
        }

        [Fact(DisplayName = "Should parse non empty cron expression with valid time fields and command")]
        public void Test04()
        {
            this._steps.GivenISetupService().WhenIExecuteService("*/15 0 1,15 * 1-5 /usr/bin/find").ThenIShouldExpectSuccess();
        }
    }
}
