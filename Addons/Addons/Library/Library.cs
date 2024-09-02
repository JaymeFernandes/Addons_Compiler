using System;
using System.IO;


namespace Addons
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

    public enum SaturationModifier
    {
        Low,
        Normal,
        High
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
}
