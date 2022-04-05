using Deliveroo.CronEx.Parser.Core.Constants;
using Deliveroo.CronEx.Parser.Core.Interfaces;
using Deliveroo.CronEx.Parser.Infrastructure.Services;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;

namespace Deliveroo.CronEx.Parser.Acceptance.Tests
{
    public class CronExpressionServiceSteps
    {
        private IComponentInterpreter _componentInterpreterMock;
        private CronExpressionService _cronExpressionService;
        private Dictionary<CronExpressionConponentType, List<string>> _parsedCronExpression;


    }
}
