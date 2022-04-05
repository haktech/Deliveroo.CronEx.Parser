using Deliveroo.CronEx.Parser.Core.Constants;
using Deliveroo.CronEx.Parser.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Deliveroo.CronEx.Parser.Infrastructure.Validators
{
    /// <summary>
    /// Interval values field validator
    /// </summary>
    public class IntervalValuesFieldValidator : IFieldValidator
    {
        /// <summary>
        /// Validate interval values field
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

            if (field.IndexOf(Constants.IntervalOperation) != 1)
            {
                throw new FormatException($"Invalid interval values field: {field}. '{Constants.IntervalOperation}' should be preceeded by '*' and followed by value");
            }

            var fieldParts = field.Split(Constants.IntervalOperation);
            if (fieldParts.Length != 2)
            {
                throw new FormatException($"Invalid interval values field: {field}. Wrong position of '{Constants.IntervalOperation}'.");
            }

            int multiplicand;
            if (fieldParts[0] != "*" || !int.TryParse(fieldParts[1], out multiplicand))
            {
                throw new FormatException($"Invalid interval values field: {field}. Field should start with '*'");
            }

            var dateTimeRangeValues = Constants.DateTimeRangeValues[type];
            if(multiplicand < dateTimeRangeValues.MinimumValue || multiplicand > dateTimeRangeValues.MaximumValue)
            {
                throw new FormatException($"Multiplicand {multiplicand} is out of '{Constants.DateTimeComponentDisplayNames[type]}' bound: {dateTimeRangeValues.MinimumValue} - {dateTimeRangeValues.MaximumValue}");
            }
        }
    }
}
