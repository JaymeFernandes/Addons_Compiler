﻿using Addons;
using Addons.View;
using Addons.Texture;
using Newtonsoft.Json;
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