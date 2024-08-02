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
        public int Nutrition { get; set; } = 0;
        public SaturationModifier FoodSaturationModifier { get; set; }
        public string UsingConvertsTo { get; set; }

        public Dictionary<string, object> GetData()
        {
            DataFood["can_always_eat"] = CanAlwaysEat;

            if (FoodSaturationModifier != null)
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

                DataFood["saturation_modifier"] = value;
            }

            
            DataFood["nutrition"] = Nutrition;
            
            if (UsingConvertsTo != null) DataFood["using_converts_to"] = UsingConvertsTo;

            return DataFood;
        }
    }
}
