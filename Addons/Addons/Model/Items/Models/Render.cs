using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Addons
{
    /// <summary>
    /// Represents render properties of a Minecraft item.
    /// </summary>
    public class RenderItem
    {
        public Dictionary<string, object> Renders { get; set; } = new Dictionary<string, object>();

        /// <summary>
        /// Initializes a new instance of the <see cref="RenderItem"/> class.
        /// </summary>
        public RenderItem()
        {
            AddRenderOffset(HandTypes.MainHand, ViewTypes.FirstPerson);
            AddRenderOffset(HandTypes.MainHand, ViewTypes.ThirdPerson, new float[] { 0.002f, 0.002f, 0.002f });
        }

        /// <summary>
        /// Adds a render offset for the specified hand and view type.
        /// </summary>
        /// <param name="hand">The hand type.</param>
        /// <param name="view">The view type.</param>
        /// <param name="scale">The scale values (optional).</param>
        /// <param name="rotation">The rotation values (optional).</param>
        /// <param name="translation">The translation values (optional).</param>
        public void AddRenderOffset(HandTypes hand, ViewTypes view, float[]? scale = null, float[]? rotation = null, float[]? translation = null)
        {
            scale ??= new float[] { 0.001f, 0.001f, 0.001f };

            if (!Renders.ContainsKey(hand.GetString()))
            {
                Renders[hand.GetString()] = new Dictionary<string, object>();
            }

            var handDict = (Dictionary<string, object>)Renders[hand.GetString()];

            var viewDict = new Dictionary<string, object>
            {
                ["scale"] = scale
            };
            if (rotation != null) viewDict["rotation"] = rotation;
            if (translation != null) viewDict["translation"] = translation;

            handDict[view.GetString()] = viewDict;
        } 
    }

    internal static class RenderExtension
    {
        internal static string GetString(this ViewTypes type)
        {
            return type switch
            {
                ViewTypes.FirstPerson => "first_person",
                ViewTypes.ThirdPerson => "third_person",
                _ => string.Empty,
            };
        }

        internal static string GetString(this HandTypes type)
        {
            return type switch
            {
                HandTypes.MainHand => "main_hand",
                HandTypes.OffHand => "off_hand",
                _ => string.Empty,
            };
        }
    }
}
