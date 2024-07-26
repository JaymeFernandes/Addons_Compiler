using Addons;
using Addons.Controller.Items;
using Addons.Interfaces.Items;
using Addons.View;

namespace AddonTest
{
    class Program
    {
        static void Main(string[] args)
        {
            var builder = new Addon.CreateBuilder()
                .BuildLogs(true)
                .SetName("Temp")
                .SetDescription("temp")
                .AddBehavior()
                .AddResource();

            var app = builder.BuildBase();

            IMinecraftItem item = new Item();

            item.Property(x =>
            {
                x.Identifier = "my_custom_item:item";
                x.Category = ItemCategory.Misc;
                x.Name = "apple";
                x.SetTexture("my_custom_item");
            });

            Console.WriteLine(item.ToString());
        }
    }
}
