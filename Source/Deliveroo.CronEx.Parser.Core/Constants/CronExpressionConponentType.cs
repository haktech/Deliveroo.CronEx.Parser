using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Deliveroo.CronEx.Parser.Core.Constants
{
    public enum CronExpressionConponentType
    {
        Minute = 1,
        Hour = 2,
        DayOfMonth = 3,
        Month = 4,
        DayOfWeek = 5,
        Command = 6
    }
}
