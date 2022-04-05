using Deliveroo.CronEx.Parser.Core.Constants;
using System;
using System.Collections.Generic;
using System.Text;

namespace Deliveroo.CronEx.Parser.Core.Interfaces
{
    /// <summary>
    /// Cron expression intrepreter
    /// </summary>
    public interface IComponentInterpreter
    {
        /// <summary>
        /// Expand cron expression component value by CronExpressionConponentType
        /// </summary>
        /// <param name="componentExpression">Cron expression component string</param>
        /// <param name="type">Cron expression component type</param>
        /// <returns>Expanded value</returns>
        List<string> ExpandValue(string componentExpression, CronExpressionConponentType type);
    }
}
