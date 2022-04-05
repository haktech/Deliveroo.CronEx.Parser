using Deliveroo.CronEx.Parser.Core.Constants;
using Deliveroo.CronEx.Parser.Infrastructure.Validators;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Deliveroo.CronEx.Parser.Infrastructure.Tests.Validators
{
    public class ExpectedValidators : IEnumerable<object[]>
    {
        public IEnumerator<object[]> GetEnumerator()
        {
            yield return new object[] { Constants.IntervalOperation, new IntervalValuesFieldValidator() };
            yield return new object[] { Constants.RangeOperator, new RangeValuesFieldValidator() };
            yield return new object[] { Constants.SetOfValuesOperator, new SetOfValuesFieldValidator() };
            yield return new object[] { "anything else", new SpecificValueFieldValidator() };
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}
