using UnityEngine;
using PaintIn3D;
using Aezakmi.PaintMechanics;

namespace Aezakmi
{
    public class ColorGrabber : MonoBehaviour
    {
        [SerializeField] private P3dPaintDecal _painter;

        private void Start()
        {
            EventManager.current.onColorChange += UpdateColor;
            _painter.Color = ColorPalette.SelectedColor;
        }

        private void UpdateColor(int index)
        {
            _painter.Color = ColorPalette.current.colors[index];
        }
    }
}
