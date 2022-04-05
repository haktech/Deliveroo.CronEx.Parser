using Deliveroo.CronEx.Parser.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Deliveroo.CronEx.Parser.Core.Constants
{
    public static class Constants
    {
        /// <summary>
        /// Contains the maximum and minimum values of the datetime elements
        /// </summary>
        public static readonly Dictionary<CronExpressionConponentType, DateTimeRangeModel> DateTimeRangeValues = new Dictionary<CronExpressionConponentType, DateTimeRangeModel>
        {
            {CronExpressionConponentType.Minute, new DateTimeRangeModel(){ MinimumValue= 0, MaximumValue=59} },
            {CronExpressionConponentType.Hour, new DateTimeRangeModel(){ MinimumValue= 0, MaximumValue=59} },
            {CronExpressionConponentType.DayOfMonth, new DateTimeRangeModel(){ MinimumValue= 1, MaximumValue=31} },
            {CronExpressionConponentType.Month, new DateTimeRangeModel(){ MinimumValue= 1, MaximumValue=12} },
            {CronExpressionConponentType.DayOfWeek, new DateTimeRangeModel(){ MinimumValue= 1, MaximumValue=7} }
        };

        // Friendly display names of date time components
        public static readonly Dictionary<CronExpressionConponentType, string> DateTimeComponentDisplayNames = new Dictionary<CronExpressionConponentType, string>
        {
            {CronExpressionConponentType.Minute, "minute" },
            {CronExpressionConponentType.Hour, "hour" },
            {CronExpressionConponentType.DayOfMonth, "day of month" },
            {CronExpressionConponentType.Month, "month" },
            {CronExpressionConponentType.DayOfWeek, "day of week" },
            {CronExpressionConponentType.Command, "command" }
        };

        public const string IntervalOperation = "/";
        public const string RangeOperator = "-";
        public const string SetOfValuesOperator = ",";
    }
}
