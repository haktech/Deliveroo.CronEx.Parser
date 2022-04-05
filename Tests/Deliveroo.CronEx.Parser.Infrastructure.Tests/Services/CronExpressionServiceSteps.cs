using Deliveroo.CronEx.Parser.Core.Constants;
using Deliveroo.CronEx.Parser.Core.Interfaces;
using Deliveroo.CronEx.Parser.Infrastructure.Services;
using Moq;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Text;

namespace Deliveroo.CronEx.Parser.Infrastructure.Tests.Services
{
    public class CronExpressionServiceSteps
    {
        private Mock<IComponentInterpreter> _componentInterpreterMock;
        private CronExpressionService _cronExpressionService;
        private Dictionary<CronExpressionConponentType, List<string>> _parsedCronExpression;

        public CronExpressionServiceSteps()
        {
            this._componentInterpreterMock = new Mock<IComponentInterpreter>();
        }

        public CronExpressionServiceSteps GivenISetupService(Queue<List<string>> expandedResultList = null)
        {
            // If null, we setup default test data
            if(expandedResultList == null)
            {
                expandedResultList = new Queue<List<string>>();
                expandedResultList.Enqueue(new List<string>() { "0", "15", "30", "45" });
                expandedResultList.Enqueue(new List<string>() { "0"});
                expandedResultList.Enqueue(new List<string>() { "1", "15" });
                expandedResultList.Enqueue(new List<string>() { "1", "2", "3", "4", "5","6", "7", "8", "9", "10", "11", "12" });
                expandedResultList.Enqueue(new List<string>() { "1", "2", "3", "4", "5" });
            }

            this._componentInterpreterMock.Setup(x => x.ExpandValue(It.IsAny<string>(), It.IsAny<CronExpressionConponentType>())).Returns(() => { return expandedResultList.Dequeue(); });
            this._cronExpressionService = new CronExpressionService(this._componentInterpreterMock.Object);
            return this;
        }

        public CronExpressionServiceSteps WhenIExecuteService(string cronExpression)
        {
            this._parsedCronExpression = this._cronExpressionService.Parse(cronExpression);
            return this;
        }

        public void ThenIShouldExpectSuccess(Dictionary<CronExpressionConponentType, List<string>> expectedResult = null)
        {
            if(expectedResult == null)
            {
                this._parsedCronExpression.ShouldNotBeNull();
                this._parsedCronExpression.Count.ShouldBe(6);
                foreach (var item in this._parsedCronExpression)
                {
                    item.Value.ShouldNotBeNull();
                    item.Value.Count.ShouldBeGreaterThan(0);
                }
            }
            else
            {
                this._parsedCronExpression.ShouldBeEquivalentTo(expectedResult);
            }
        }
    }
}
