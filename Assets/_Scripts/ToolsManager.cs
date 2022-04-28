using UnityEngine;
using System.Collections.Generic;

namespace Aezakmi.PaintMechanics
{
    public class ToolsManager : MonoBehaviour
    {
        [SerializeField] private GameObject _caseSprayPainter;
        [SerializeField] private GameObject _caseMarkerPainter;
        [SerializeField] private GameObject _caseStickerer;
        [SerializeField] private GameObject _caseOpener;
        [SerializeField] private GameObject _earbudsSprayPainter;


        [SerializeField] private GameObject _spray;
        [SerializeField] private Vector3 _sprayOriginalPosition;
        [SerializeField] private Vector3 _sprayOriginalRotation;
        [SerializeField] private GameObject _marker;
        [SerializeField] private Vector3 _markerOriginalPosition;
        [SerializeField] private Vector3 _markerOriginalRotation;

        [SerializeField] private GameObject _earbuds;

        private void Start()
        {
            EventManager.current.onCaseAnimationEnd += delegate { _caseSprayPainter.SetActive(true); };
            EventManager.current.onCaseSprayComplete += delegate { TurnOffAll(); ResetSpray(); _caseMarkerPainter.SetActive(true); };
            EventManager.current.onCaseMarkerComplete += delegate { TurnOffAll(); ResetMarker(); _caseStickerer.SetActive(true); };
            EventManager.current.onCaseStickerComplete += delegate { TurnOffAll(); _caseOpener.SetActive(true); _earbuds.SetActive(true); };
            EventManager.current.onStartEarbudsSpray += delegate { TurnOffAll(); _earbudsSprayPainter.SetActive(true); };
            EventManager.current.onChooseSiliconeColor += delegate { TurnOffAll(); ResetSpray(); };
            EventManager.current.onGameFinished += delegate { TurnOffAll(); };
        }

        private void TurnOffAll()
        {
            _caseSprayPainter.SetActive(false);
            _caseMarkerPainter.SetActive(false);
            _caseStickerer.SetActive(false);
            _caseOpener.SetActive(false);
            _earbudsSprayPainter.SetActive(false);
        }

        private void ResetSpray()
        {
            _spray.GetComponent<PaintCursor>().canMove = false;
            _spray.transform.position = _sprayOriginalPosition;
            _spray.transform.rotation = Quaternion.Euler(_sprayOriginalRotation);
        }

        private void ResetMarker()
        {
            _marker.GetComponent<PaintCursor>().canMove = false;
            _marker.transform.position = _markerOriginalPosition;
            _marker.transform.rotation = Quaternion.Euler(_markerOriginalRotation);
        }
    }
}
