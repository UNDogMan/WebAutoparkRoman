using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebAutopark.BusinessLogic.Dto;

namespace WebAutopark.BusinessLogic.Extensions
{
    public static class BusiniessCalculatorExtension
    {
        public static float CalcTaxPerMount(this VehicleDto vehicle) 
            => vehicle.TankCapacity / vehicle.Consumption * 100;

        public static float CalcMaxMileage(this VehicleDto vehicle, VehicleTypeDto type) {
            const float WeightCoefficient = 0.0013f;
            const int BaseTax = 30;
            const int MinTax = 5;
            return vehicle.Weight * WeightCoefficient + type.TaxCoefficient * BaseTax + MinTax;
        }
    }
}
