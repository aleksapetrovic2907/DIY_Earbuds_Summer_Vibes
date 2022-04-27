using UnityEngine;
using UnityEngine.UI;
using Aezakmi.PaintMechanics;

namespace Aezakmi.UI
{
    public class ItemColorer : MonoBehaviour
    {
        [SerializeField] private Image _coloredPart;

        private int _index;

        public void SetColor(Color32 targetColor, int i)
        {
            _coloredPart.color = targetColor;
            _index = i;
        }

        public void SelectColor()
        {
            ColorPalette.current.SetColor(_index);
        }

        public void SelectSiliconeColor()
        {
            ColorPalette.current.SetSiliconeColor(_index);
        }
    }
}
