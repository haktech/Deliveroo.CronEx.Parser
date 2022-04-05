using Deliveroo.CronEx.Parser.Core.Constants;
using Deliveroo.CronEx.Parser.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Deliveroo.CronEx.Parser.Infrastructure.Validators
{
    /// <summary>
    /// Set of values field validator
    /// </summary>
    public class SetOfValuesFieldValidator : IFieldValidator
    {
        /// <summary>
        /// Validate Set of values field
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

            if (field.IndexOf(Constants.SetOfValuesOperator) < 1)
            {
                throw new FormatException($"Invalid set of values field: {field}. Set of values field should have '{Constants.SetOfValuesOperator}'");
            }

            var fieldParts = field.Split(Constants.SetOfValuesOperator);
            if (fieldParts.Length < 2)
            {
                throw new FormatException($"Invalid set of values field: {field}. '{Constants.SetOfValuesOperator}' should be preceeded and followed by value");
            }

            var dateTimeRangeValues = Constants.DateTimeRangeValues[type];
            for (var i = 0; i < fieldParts.Length; i++)
            {
                if(!int.TryParse(fieldParts[i], out var value))
                {
                    throw new FormatException($"Invalid value: {fieldParts[i]}. Value should be integer.");
                }

                if(value < dateTimeRangeValues.MinimumValue || value > dateTimeRangeValues.MaximumValue)
                {
                    throw new FormatException($"Invalid value: {value}. Value is out of '{Constants.DateTimeComponentDisplayNames[type]}' bound: {dateTimeRangeValues.MinimumValue} - {dateTimeRangeValues.MaximumValue}");
                }
            }
        }
    }
}
