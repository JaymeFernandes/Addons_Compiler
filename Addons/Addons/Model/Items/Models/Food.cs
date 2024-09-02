using Addons.Model;

namespace Addons
{
    public sealed class Food : BaseJson
    {
        internal Dictionary<string, object> GetData()
        {
            data["can_always_eat"] = CanAlwaysEat;

            data["saturation_modifier"] = GetValue(FoodSaturationModifier);

            data["nutrition"] = Nutrition;
            
            if (UsingConvertsTo != null) data["using_converts_to"] = UsingConvertsTo;

            return data;
        }



        private string GetValue(SaturationModifier saturationModifier) => FoodSaturationModifier switch
        {
            SaturationModifier.Low => "low",
            SaturationModifier.Normal => "normal",
            SaturationModifier.High => "high",
            _ => string.Empty
        };

        public bool CanAlwaysEat { get; set; } = false;
        public int Nutrition { get; set; } = 2;
        public SaturationModifier FoodSaturationModifier { get; set; } = SaturationModifier.Normal;
        public string? UsingConvertsTo { get; set; }
        public int UseDuration { get; set; } = 1;
    }
}
