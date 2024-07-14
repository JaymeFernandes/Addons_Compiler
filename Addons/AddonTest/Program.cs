using Addons;
using System;

namespace AddonTest
{
    class Program
    {
        static void Main(string[] args)
        {
            var builder = new Addon.Builder()
                .SetName("Temp")
                .SetDescription("temp")
                .AddBehavior()
                .AddResource();

            var app = builder.Build();
        }
    }
}
