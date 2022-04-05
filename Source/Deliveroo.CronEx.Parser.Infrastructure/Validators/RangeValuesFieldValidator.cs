using Deliveroo.CronEx.Parser.Core.Constants;
using Deliveroo.CronEx.Parser.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Deliveroo.CronEx.Parser.Infrastructure.Validators
{
    /// <summary>
    /// Range values field validator
    /// </summary>
    public class RangeValuesFieldValidator : IFieldValidator
    {
        /// <summary>
        /// Validate Range values field
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

            if (field.IndexOf(Constants.RangeOperator) <= 0)
            {
                throw new FormatException($"Invalid range value: {field}. '{Constants.RangeOperator}' should be preceeded and followed by value");
            }

            var fieldParts = field.Split(Constants.RangeOperator);
            if (fieldParts.Length != 2)
            {
                throw new FormatException($"Invalid range value: {field}. It should be preceeded and followed by value");
            }

            if (!int.TryParse(fieldParts[0], out var left) || !int.TryParse(fieldParts[1], out var right))
            {
                throw new FormatException($"Invalid range value: {field}. Value should be integer.");
            }

            var dateTimeRangeValues = Constants.DateTimeRangeValues[type];
            if (left < dateTimeRangeValues.MinimumValue || left > dateTimeRangeValues.MaximumValue || right < dateTimeRangeValues.MinimumValue || right > dateTimeRangeValues.MaximumValue)
            {
                throw new FormatException($"Invalid range value: {field}. Value/s are out of '{Constants.DateTimeComponentDisplayNames[type]}' bound: {dateTimeRangeValues.MinimumValue} - {dateTimeRangeValues.MaximumValue}");
            }
        }
    }
}
