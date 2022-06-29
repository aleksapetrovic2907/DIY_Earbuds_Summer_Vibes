using UnityEngine;
using Aezakmi.Tweens;

public enum Tools
{
    None,
    Spray,
    Marker,
    Sticker,
}

namespace Aezakmi.PaintMechanics
{
    public class ToolsManager : MonoBehaviour
    {
        public static ToolsManager current;

        private void Awake()
        {
            if (current != this)
                current = this;
        }

        [SerializeField] private GameObject _caseSprayPainter;
        [SerializeField] private GameObject _caseMarkerPainter;
        [SerializeField] private GameObject _caseStickerer;
        [SerializeField] private GameObject _stickerGuide;
        [SerializeField] private GameObject _caseOpener;
        [SerializeField] private GameObject _earbudsSprayPainter;

        [Header("Spray")]
        [SerializeField] private GameObject _spray;
        [SerializeField] private GameObject _sprayCanister;
        [SerializeField] private Vector3 _sprayOriginalPosition;
        [SerializeField] private Vector3 _sprayOriginalRotation;

        [Header("Marker")]
        [SerializeField] private GameObject _marker;
        [SerializeField] private Vector3 _markerOriginalPosition;
        [SerializeField] private Vector3 _markerOriginalRotation;

        public Tools CurrentTool = Tools.None;

        private void Start()
        {
            EventManager.current.onCaseAnimationEnd += delegate { _caseSprayPainter.SetActive(true); CurrentTool = Tools.Spray; };
            EventManager.current.onCaseSprayComplete += delegate { TurnOffAll(); ResetSpray(); _caseMarkerPainter.SetActive(true); CurrentTool = Tools.Marker; };
            EventManager.current.onCaseMarkerComplete += delegate { TurnOffAll(); ResetMarker(); _caseStickerer.SetActive(true); _stickerGuide.SetActive(true); CurrentTool = Tools.Sticker; };
            EventManager.current.onCaseStickerComplete += delegate { TurnOffAll(); _caseOpener.SetActive(true); ReferenceManager.Instance.CurrentEarbuds.SetActive(true); CurrentTool = Tools.None; };
            EventManager.current.onStartEarbudsSpray += delegate { TurnOffAll(); _earbudsSprayPainter.SetActive(true); CurrentTool = Tools.Spray; };
            EventManager.current.onChooseSiliconeColor += delegate { TurnOffAll(); ResetSpray(); CurrentTool = Tools.None; };
            EventManager.current.onGameFinished += delegate { TurnOffAll(); };

            EventManager.current.onColorChange += delegate { ToolAnimation(); };
        }

        private void ToolAnimation()
        {
            if (CurrentTool == Tools.Spray)
            {
                _sprayCanister.GetComponent<Scale>().PlayTween();
            }
            else if (CurrentTool == Tools.Marker)
            {
                _marker.GetComponent<Scale>().PlayTween();
            }
        }

        private void TurnOffAll()
        {
            _caseSprayPainter.SetActive(false);
            _caseMarkerPainter.SetActive(false);
            _caseStickerer.SetActive(false);
            _stickerGuide.SetActive(false);
            _caseOpener.SetActive(false);
            _earbudsSprayPainter.SetActive(false);
        }

        private void ResetSpray()
        {
            _spray.transform.position = _sprayOriginalPosition;
            _spray.transform.rotation = Quaternion.Euler(_sprayOriginalRotation);
        }

        private void ResetMarker()
        {
            _marker.transform.position = _markerOriginalPosition;
            _marker.transform.rotation = Quaternion.Euler(_markerOriginalRotation);
        }
    }
}
