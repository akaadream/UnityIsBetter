using UnityEngine;
using UnityEngine.UI;

namespace UnityIsBetter.Utils
{
    public static class ButtonExtensions
    {
        public static void SetNormalColor(this Button button, Color color)
        {
            UpdateColors(button, color, button.colors.highlightedColor, button.colors.pressedColor, button.colors.disabledColor);
        }

        public static void SetHighlightedColor(this Button button, Color color)
        {
            UpdateColors(button, button.colors.normalColor, color, button.colors.pressedColor, button.colors.disabledColor);
        }

        public static void SetPressedColor(this Button button, Color color)
        {
            UpdateColors(button, button.colors.normalColor, button.colors.highlightedColor, color, button.colors.disabledColor);
        }

        public static void SetDisabledColor(this Button button, Color color)
        {
            UpdateColors(button, button.colors.normalColor, button.colors.highlightedColor, button.colors.pressedColor, color);
        }

        private static void UpdateColors(Button button, Color normalColor, Color highlightedColor, Color pressedColor, Color disabledColor)
        {
            ColorBlock colorBlock = button.colors;
            colorBlock.normalColor = normalColor;
            colorBlock.highlightedColor = highlightedColor;
            colorBlock.pressedColor = pressedColor;
            colorBlock.disabledColor = disabledColor;
            button.colors = colorBlock;
        }
    }
}
