﻿namespace Addons
{
    /// <summary>
    /// Represents the hand types for rendering.
    /// </summary>
    public enum HandTypes
    {
        MainHand,
        OffHand
    }

    /// <summary>
    /// Represents the view types for rendering.
    /// </summary>
    public enum ViewTypes
    {
        FirstPerson,
        ThirdPerson
    }


    public enum AddonType
    {
        Data,
        Resources,
        Scripting,
        Interface,
        SkinPack,
        WorldTemplate
    }

    public enum TextureType
    {
        Items,
        Terrain,
        Entity,
        Environment,
        Gui,
        Misc,
        Particles
    }

    public static class MinecraftColor
    {
        public const string Black = "§0";
        public const string Dark_blue = "§1";
        public const string Dark_green = "§2";
        public const string Dark_aqua = "§3";
        public const string Dark_red = "§4";
        public const string Dark_purple = "§5";
        public const string Gold = "§6";
        public const string Gray = "§7";
        public const string Dark_gray = "§8";
        public const string Blue = "§9";
        public const string Green = "§a";
        public const string Aqua = "§b";
        public const string Red = "§c";
        public const string Light_purple = "§d";
        public const string Yellow = "§e";
        public const string White = "§f";
        public const string Minecoin_gold = "§g";
        public const string Material_quartz = "§h";
        public const string Material_iron = "§i";
        public const string Material_netherite = "§j";
        public const string Material_redstone = "§m";
        public const string Material_copper = "§n";
        public const string Material_gold = "§p";
        public const string Material_emerald = "§q";
        public const string Material_diamond = "§s";
        public const string Material_lapis = "§t";
        public const string Material_amethyst = "§u";
    }

    public static class MinecraftFormatting
    {
        public const string Obfuscated = "§k";
        public const string Bold = "§l";
        public const string italic = "§o";
        public const string reset = "§r";
    }
}
