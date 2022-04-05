using System;
using System.Collections.Generic;
using System.Text;

namespace Deliveroo.CronEx.Parser.Core.Models
{
    public class DateTimeRangeModel
    {
        /// <summary>
        /// Sets or gets the maximum possible value
        /// </summary>
        public int MaximumValue { get; set; }

        /// <summary>
        /// Sets or get the miniumum possible value
        /// </summary>
        public int MinimumValue { get; set; }
    }
}
