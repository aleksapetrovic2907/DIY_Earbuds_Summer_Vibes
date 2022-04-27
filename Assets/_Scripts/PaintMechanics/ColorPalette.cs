using UnityEngine;
using System.Collections.Generic;

namespace Aezakmi.PaintMechanics
{
    public class ColorPalette : MonoBehaviour
    {
        public static ColorPalette current;

        public static Color32 SelectedColor;
        public static Color32 SelectedSiliconeColor;
        public List<Color32> colors;

        private void Awake()
        {
            SelectedColor = colors[0];

            current = this;
        }

        public void SetColor(int index)
        {
            SelectedColor = colors[index];
            EventManager.current.ColorChanged(index);
        }

        public void SetSiliconeColor(int index)
        {
            SelectedSiliconeColor = colors[index];
            EventManager.current.SiliconeColorChanged(index);
        }
    }
}