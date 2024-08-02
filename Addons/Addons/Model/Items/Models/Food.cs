using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Addons
{
    public sealed class Food
    {
        private Dictionary<string, object> DataFood = new Dictionary<string, object>();
        public bool CanAlwaysEat { get; set; } = false;
        public int Nutrition { get; set; } = 2;
        public SaturationModifier FoodSaturationModifier { get; set; } = SaturationModifier.Normal;
        public string? UsingConvertsTo { get; set; }
        public int UseDuration { get; set; } = 1;


        public Dictionary<string, object> GetData()
        {
            DataFood["can_always_eat"] = CanAlwaysEat;

            DataFood["saturation_modifier"] = GetValue(FoodSaturationModifier);

            DataFood["nutrition"] = Nutrition;
            
            if (UsingConvertsTo != null) DataFood["using_converts_to"] = UsingConvertsTo;

            return DataFood;
        }



        private string GetValue(SaturationModifier saturationModifier)
        {
            var value = "";

            switch (FoodSaturationModifier)
            {
                case SaturationModifier.Low:
                    value = "low";
                    break;
                case SaturationModifier.Normal:
                    value = "normal";
                    break;
                case SaturationModifier.High:
                    value = "high";
                    break;
                default:
                    throw new NotImplementedException(nameof(FoodSaturationModifier));
            }

            return value;
        }

    }
}
