using UnityEngine;
using TMPro;

namespace Aezakmi
{
    public class FPSCanvas : MonoBehaviour
    {
        public TextMeshProUGUI touchPos;
        public TextMeshProUGUI uvTouchPos;

        private void Update()
        {
            if(InputManager.current.IsTouching)
            {
                touchPos.text = $"Touch Pos {InputManager.current.Touch.position}";

            }
        }
    }
}
