﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.
using System;

namespace Microsoft.Bot.Builder.Expressions
{
    /// <summary>
    /// Constant expression.
    /// </summary>
    public class Constant : Expression
    {
        /// <summary>
        /// Construct an expression constant.
        /// </summary>
        /// <param name="value"></param>
        public Constant(object value = null)
            : base(new ExpressionEvaluator(ExpressionType.Constant, (expression, state) => ((expression as Constant).Value, null)))
        {
            Value = value;
        }

        /// <summary>
        /// Constant value.
        /// </summary>
        public object Value
        {
            get
            {
                return _value;
            }
            set
            {
                Evaluator.ReturnType =
                      (value is string ? ReturnType.String
                      : value.IsNumber() ? ReturnType.Number
                      : value is bool ? ReturnType.Boolean
                      : ReturnType.Object);
                _value = value;
            }
        }

        private object _value;

        public override string ToString()
        {
            if (Value == null)
            {
                return "null";
            }
            else if (Value is string str)
            {
                return $"'{Value}'";
            }
            else
            {
                return Value?.ToString();
            }
        }
    }
}
