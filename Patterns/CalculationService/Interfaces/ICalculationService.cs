using System;
using System.Collections.Generic;
using System.Text;

namespace CalculationService
{
    internal interface ICalculationService
    {
        decimal Calculate(decimal firstParameter, decimal secondParameter);
    }
}
