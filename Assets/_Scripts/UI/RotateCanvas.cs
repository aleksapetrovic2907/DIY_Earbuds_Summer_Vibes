using UnityEngine;
using UnityEngine.UI;

namespace Aezakmi.UI
{
    public class RotateCanvas : MonoBehaviour
    {
        GraphicRaycaster _graphicRaycaster;

        private void Start()
        {
            _graphicRaycaster = GetComponent<GraphicRaycaster>();
            EventManager.current.onGameStart += delegate { _graphicRaycaster.enabled = true; };
            EventManager.current.onCaseStickerComplete += delegate { _graphicRaycaster.enabled = false; };
            EventManager.current.onStartEarbudsSpray += delegate { _graphicRaycaster.enabled = true; };
            EventManager.current.onGameFinished += delegate { _graphicRaycaster.enabled = false; };
        }


    }
}
