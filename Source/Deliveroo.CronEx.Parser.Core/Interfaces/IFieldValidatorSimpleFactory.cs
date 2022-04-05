using System;
using System.Collections.Generic;
using System.Text;

namespace Deliveroo.CronEx.Parser.Core.Interfaces
{
    /// <summary>
    /// Term validator simple factory
    /// </summary>
    public interface IFieldValidatorSimpleFactory
    {
        /// <summary>
        /// Create instance of FieldValidator
        /// </summary>
        /// <param name="fieldExpression">Field expression</param>
        /// <returns>Instance of field validator</returns>
        IFieldValidator Create(string fieldExpression);
    }
}
