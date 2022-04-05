using Deliveroo.CronEx.Parser.Core.Constants;
using Deliveroo.CronEx.Parser.Core.Interfaces;
using Deliveroo.CronEx.Parser.Infrastructure.Common;
using Deliveroo.CronEx.Parser.Infrastructure.Validators;
using System;
using System.Collections.Generic;
using System.Text;

namespace Deliveroo.CronEx.Parser.Infrastructure.CronExpressionInterpreter
{
    /// <summary>
    /// Month component value interpreter
    /// </summary>
    public class ComponentInterpreter : IComponentInterpreter
    {
        private readonly IFieldValidatorSimpleFactory _termValidatorFactory;

        /// <summary>
        /// Initializes a new instance of the <see cref="ComponentInterpreter"/> class.
        /// </summary>
        /// <param name="termValidatorFactory"></param>
        public ComponentInterpreter(IFieldValidatorSimpleFactory termValidatorFactory)
        {
            this._termValidatorFactory = termValidatorFactory;
        }

        /// <summary>
        /// Interprete month component value
        /// </summary>
        /// <param name="componentExpression">Cron expression component string</param>
        /// <param name="type"></param>
        /// <returns>Expanded value</returns>
        public List<string> ExpandValue(string componentExpression, CronExpressionConponentType type)
        {
            // Let's validate
            if (componentExpression != "*") // All values doesn't need to be validated
            {
                var validator = this._termValidatorFactory.Create(componentExpression);
                validator.Validate(componentExpression, type);
            }

            // Value expander 
            return ValueExpander.Expand(componentExpression, type);
        }
    }
}
