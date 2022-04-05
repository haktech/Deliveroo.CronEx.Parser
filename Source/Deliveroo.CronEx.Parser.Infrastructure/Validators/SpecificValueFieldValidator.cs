using Deliveroo.CronEx.Parser.Core.Constants;
using Deliveroo.CronEx.Parser.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Deliveroo.CronEx.Parser.Infrastructure.Validators
{
    /// <summary>
    /// Specific value field validator
    /// </summary>
    public class SpecificValueFieldValidator : IFieldValidator
    {
        /// <summary>
        /// Validate specific value field
        /// </summary>
        /// <param name="field">Field string to be validated</param>
        /// <param name="type">Type</param>
        /// <exception cref="FormatException">Invalid format</exception>
        /// <exception cref="ArgumentNullException">Null or Empty</exception>
        public void Validate(string field, CronExpressionConponentType type)
        {
            if (string.IsNullOrEmpty(field))
            {
                throw new ArgumentNullException($"Null or empty field thrown by: {nameof(IntervalValuesFieldValidator)}");
            }

            var dateTimeRangeValues = Constants.DateTimeRangeValues[type];
            if (!int.TryParse(field, out var value))
            {
                throw new FormatException($"Invalid value: {field}. Value should be integer.");
            }

            if (value < dateTimeRangeValues.MinimumValue || value > dateTimeRangeValues.MaximumValue)
            {
                throw new FormatException($"Invalid value: {value}. Value is out of '{Constants.DateTimeComponentDisplayNames[type]}' bound: {dateTimeRangeValues.MinimumValue} - {dateTimeRangeValues.MaximumValue}");
            }
        }
    }
}
