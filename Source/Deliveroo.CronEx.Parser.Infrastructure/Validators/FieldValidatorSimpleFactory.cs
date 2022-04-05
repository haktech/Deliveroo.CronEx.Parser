using Deliveroo.CronEx.Parser.Core.Constants;
using Deliveroo.CronEx.Parser.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Deliveroo.CronEx.Parser.Infrastructure.Validators
{
    /// <summary>
    /// Field validator simple factory
    /// </summary>
    public class FieldValidatorSimpleFactory : IFieldValidatorSimpleFactory
    {
        /// <summary>
        /// Create instance of FieldValidator
        /// </summary>
        /// <param name="fieldExpression">Field expression</param>
        /// <returns>Instance of field validator</returns>
        /// <exception cref="ArgumentNullException">Null or empty field expression</exception>
        public IFieldValidator Create(string fieldExpression)
        {
            // This should not happen, but let's safeguard it
            if (string.IsNullOrEmpty(fieldExpression))
            {
                throw new ArgumentNullException("Empty or null field expression");
            }

            if (fieldExpression.IndexOf(Constants.IntervalOperation) >= 0)
            {
                return new IntervalValuesFieldValidator();
            }
            else if (fieldExpression.IndexOf(Constants.RangeOperator) >= 0)
            {
                return new RangeValuesFieldValidator();
            }
            else if (fieldExpression.IndexOf(Constants.SetOfValuesOperator) >= 0)
            {
                return new SetOfValuesFieldValidator();
            }
            else
            {
                return new SpecificValueFieldValidator();
            }
        }
    }
}
