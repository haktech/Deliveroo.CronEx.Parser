using Deliveroo.CronEx.Parser.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Deliveroo.CronEx.Parser.App
{
    public class EntryPoint
    {
        private readonly ICronExpression _cronExpression;

        public EntryPoint(ICronExpression cronExpression)
        {
            this._cronExpression = cronExpression;
        }
        public void Run(string[] args)
        {
            Console.WriteLine("Deliveroo Cron Expression Parser App Started Successfully!\n\n");

            var exit = false;
            while (!exit)
            {
                Console.Write("Cron Expression:");
                var cronExpression = Console.ReadLine();
                if(string.Equals(cronExpression, "exit", StringComparison.OrdinalIgnoreCase))
                {
                    exit = true;
                }

                try
                {
                    var parseCronExpression = this._cronExpression.Parse(cronExpression);
                    this._cronExpression.Print();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }
    }
}