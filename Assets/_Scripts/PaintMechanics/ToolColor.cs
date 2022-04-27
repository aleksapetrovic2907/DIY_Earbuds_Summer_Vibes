using UnityEngine;

namespace Aezakmi.PaintMechanics
{
    public class ToolColor : MonoBehaviour
    {
        private void Start()
        {
            EventManager.current.onColorChange += ChangeColor;
            GetComponent<Renderer>().material.color = ColorPalette.SelectedColor;
        }

        private void ChangeColor(int index)
        {
            GetComponent<Renderer>().material.color = ColorPalette.current.colors[index];
        }
    }
}
