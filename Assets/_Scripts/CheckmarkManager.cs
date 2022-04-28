using UnityEngine;

namespace Aezakmi
{
    public class CheckmarkManager : MonoBehaviour
    {
        [SerializeField] private GameObject _sprayCaseCheckmark;
        [SerializeField] private GameObject _sprayMarkerCheckmark;
        [SerializeField] private GameObject _sprayStickerCheckmark;
        [SerializeField] private GameObject _sprayEarbudsCheckmark;
        [SerializeField] private GameObject _siliconeColorCheckmark;


        private void Start()
        {
            EventManager.current.onStartedSpray += delegate { _sprayCaseCheckmark.SetActive(true); };
            EventManager.current.onCaseSprayComplete += delegate { TurnOffAll(); _sprayMarkerCheckmark.SetActive(true); };
            EventManager.current.onCaseMarkerComplete += delegate { TurnOffAll(); _sprayStickerCheckmark.SetActive(true); };
            EventManager.current.onCaseStickerComplete += delegate { TurnOffAll(); };
            EventManager.current.onStartEarbudsSpray += delegate { _sprayEarbudsCheckmark.SetActive(true); };
            EventManager.current.onChooseSiliconeColor += delegate { TurnOffAll(); _siliconeColorCheckmark.SetActive(true); };
            EventManager.current.onGameFinished += delegate { TurnOffAll(); };
        }

        private void TurnOffAll()
        {
            _sprayCaseCheckmark.SetActive(false);
            _sprayMarkerCheckmark.SetActive(false);
            _sprayStickerCheckmark.SetActive(false);
            _sprayEarbudsCheckmark.SetActive(false);
            _siliconeColorCheckmark.SetActive(false);
        }
    }
}
