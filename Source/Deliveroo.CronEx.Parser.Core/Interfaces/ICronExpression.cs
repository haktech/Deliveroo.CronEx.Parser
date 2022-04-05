using Deliveroo.CronEx.Parser.Core.Constants;
using System;
using System.Collections.Generic;
using System.Text;

namespace Deliveroo.CronEx.Parser.Core.Interfaces
{
    /// <summary>
    /// Cron expression parser
    /// </summary>
    public interface ICronExpression
    {
        /// <summary>
        /// Cron Expression string
        /// </summary>
        public string CronExpression { get; }

        /// <summary>
        /// Parse cron expression
        /// </summary>
        /// <param name="cronExpression"></param>
        /// <returns>Parse result</returns>
        Dictionary<CronExpressionConponentType, List<string>> Parse(string cronExpression);

        /// <summary>
        /// Print prased expanded expression
        /// </summary>
        void Print();
    }
}
