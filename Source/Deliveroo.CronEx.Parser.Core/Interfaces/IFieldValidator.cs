using Deliveroo.CronEx.Parser.Core.Constants;
using System;
using System.Collections.Generic;
using System.Text;

namespace Deliveroo.CronEx.Parser.Core.Interfaces
{
    /// <summary>
    /// Term validator
    /// </summary>
    public interface IFieldValidator
    {
        /// <summary>
        /// Time field validator
        /// </summary>
        /// <param name="field">Field string to be validated</param>
        /// <param name="type">Type</param>
        void Validate(string field, CronExpressionConponentType type);
    }
}
