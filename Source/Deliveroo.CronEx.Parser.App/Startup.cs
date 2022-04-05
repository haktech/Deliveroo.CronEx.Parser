using Deliveroo.CronEx.Parser.Core.Interfaces;
using Deliveroo.CronEx.Parser.Infrastructure.CronExpressionInterpreter;
using Deliveroo.CronEx.Parser.Infrastructure.Services;
using Deliveroo.CronEx.Parser.Infrastructure.Validators;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace Deliveroo.CronEx.Parser.App
{
    public static class Startup
    {
        public static IServiceCollection AddApplicationServices()
        {
            var services = new ServiceCollection();

            //register Infrastructure / Domain
            services.AddSingleton<IComponentInterpreter, ComponentInterpreter>();
            services.AddSingleton<ICronExpression, CronExpressionService>();
            services.AddSingleton<IFieldValidatorSimpleFactory, FieldValidatorSimpleFactory>();
            // Hookup entrypoint
            services.AddTransient<EntryPoint>();

            return services;
        }
    }
}
