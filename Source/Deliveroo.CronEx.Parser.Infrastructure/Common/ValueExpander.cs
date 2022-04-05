using Deliveroo.CronEx.Parser.Core.Constants;
using Deliveroo.CronEx.Parser.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Deliveroo.CronEx.Parser.Infrastructure.Common
{
    public static class ValueExpander
    {
        public static List<string> Expand(string componentExpression, CronExpressionConponentType type)
        {
            //Note: By right, code execution reaches here only if componentExpression is valid. 

            var expandedValues = new List<string>();
            //Let's get the value bound (Max, Min) by type (Minute, Hour, ...)
            var dateTimeRangeValues = Constants.DateTimeRangeValues[type];

            if (componentExpression == "*")
            {
                expandedValues = ExpandAllValues(dateTimeRangeValues);
            }
            else if (componentExpression.IndexOf(Constants.IntervalOperation) > 0)
            {
                var step = int.Parse(componentExpression.Split(Constants.IntervalOperation)[1]);
                expandedValues = ExpandIntervalValues(step, dateTimeRangeValues);
            }
            else if (componentExpression.IndexOf(Constants.RangeOperator) > 0)
            {
                var expressionParts = componentExpression.Split(Constants.RangeOperator);
                expandedValues = ExpandRangeValues(int.Parse(expressionParts[0]), int.Parse(expressionParts[1]));
            }
            else if (componentExpression.IndexOf(Constants.SetOfValuesOperator) > 0)
            {
                var expressionParts = componentExpression.Split(Constants.SetOfValuesOperator);
                expandedValues = ExpandSetOfValues(expressionParts);
            }
            else
            {
                // Specific value
                expandedValues.Add(componentExpression);
            }

            return expandedValues;
        }

        private static List<string> ExpandAllValues(DateTimeRangeModel dateTimeRangeValues)
        {
            var expandedValues = new List<string>();

            for (var i = dateTimeRangeValues.MinimumValue; i <= dateTimeRangeValues.MaximumValue; i++)
            {
                expandedValues.Add($"{i}");
            }

            return expandedValues;
        }

        private static List<string> ExpandIntervalValues(int step, DateTimeRangeModel dateTimeRangeValues)
        {
            var expandedValues = new List<string>();
            var incrementedInterval = dateTimeRangeValues.MinimumValue;
            while (incrementedInterval <= dateTimeRangeValues.MaximumValue)
            {
                if (incrementedInterval % step == 0)
                {
                    expandedValues.Add($"{incrementedInterval}");
                }
                incrementedInterval += step;
            }

            return expandedValues;
        }

        private static List<string> ExpandRangeValues(int start, int end)
        {
            var expandedValues = new List<string>();
            for (var i = start; i <= end; i++)
            {
                expandedValues.Add($"{i}");
            }

            return expandedValues;
        }

        private static List<string> ExpandSetOfValues(string[] setOfValues)
        {
            var expandedValues = new List<string>();
            for (var i = 0; i < setOfValues.Length; i++)
            {
                expandedValues.Add(setOfValues[i]);
            }

            return expandedValues;
        }
    }
}
