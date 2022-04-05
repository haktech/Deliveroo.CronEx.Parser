using Deliveroo.CronEx.Parser.Core.Constants;
using Deliveroo.CronEx.Parser.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Deliveroo.CronEx.Parser.Infrastructure.Services
{
    public class CronExpressionService : ICronExpression
    {
        private string _cronExpression;
        private Dictionary<CronExpressionConponentType, List<string>> _parsedExpression;
        private readonly IComponentInterpreter _componentInterpreter;
        public string CronExpression => this._cronExpression;

        public CronExpressionService(IComponentInterpreter componentInterpreter)
        {
            this._componentInterpreter = componentInterpreter;
        }

        /// <summary>
        /// Parse cron expression string
        /// </summary>
        /// <param name="cronExpression">Cron expression string</param>
        /// <returns>Parsed cron expression</returns>
        /// <exception cref="ArgumentNullException">Null or empty cron expression</exception>
        /// <exception cref="FormatException">Invalid expression</exception>
        public Dictionary<CronExpressionConponentType, List<string>> Parse(string cronExpression)
        {
            // Safeguard checking
            if (string.IsNullOrEmpty(cronExpression))
            {
                throw new ArgumentNullException("Cron expression is null or empty!");
            }
            this._cronExpression = cronExpression;

            // Let's get cron expression components, e.g 'Minute Hour DayOfMonth Month DayOfWeek Command'
            var cronExpressionComponents = cronExpression.Split(' ');
            if (cronExpressionComponents.Length != 6)
            {
                throw new FormatException("Cron expression is invalid. Correct format 'Minute Hour DayOfMonth Month DayOfWeek Command'");
            }

            var parsedCronExpression = new Dictionary<CronExpressionConponentType, List<string>>();
            for (var i = 0; i < cronExpressionComponents.Length - 1; i++) // We skip command since it is just output the exact string
            {
                var type = (CronExpressionConponentType)i + 1;

                // Get interpreted value
                parsedCronExpression[type] = _componentInterpreter.ExpandValue(cronExpressionComponents[i], type);
            }

            parsedCronExpression[CronExpressionConponentType.Command] = new List<string>() { cronExpressionComponents[5] };
            this._parsedExpression = parsedCronExpression;
            return parsedCronExpression;
        }

        public void Print()
        {
            Console.WriteLine("======================================================");
            foreach (var item in this._parsedExpression)
            {
                Console.Write($"{Constants.DateTimeComponentDisplayNames[item.Key]}");
                if(item.Key == CronExpressionConponentType.DayOfMonth || item.Key == CronExpressionConponentType.DayOfWeek)
                {
                    Console.Write("\t");
                }
                else
                {
                    Console.Write("\t\t");
                }
                Console.WriteLine($"{ string.Join(' ', item.Value)}");
                //Console.WriteLine($"{Constants.DateTimeComponentDisplayNames[item.Key]} \t\t {string.Join(' ', item.Value)}");
            }
            Console.WriteLine("======================================================");
        }
    }
}
