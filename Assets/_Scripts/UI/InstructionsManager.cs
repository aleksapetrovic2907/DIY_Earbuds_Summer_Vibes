using UnityEngine;
using Aezakmi.PaintMechanics;
using PaintIn3D;

namespace Aezakmi.UI
{
    public class InstructionsManager : MonoBehaviour
    {
        public static InstructionsManager current;

        private void Awake()
        {
            if (current != this)
                current = this;
        }

        [SerializeField] private GameObject _swipeToSprinkleCase;

        [Space(20)]
        [SerializeField] private P3dHitScreen _painterSpray;
        [SerializeField] private GameObject _swipeToRotateCase;

        [SerializeField] private GameObject _swipeToDraw;
        [SerializeField] private GameObject _dragAndDropSticker;
        [SerializeField] private GameObject _swipeToOpenCase;
        [SerializeField] private GameObject _swipeToMoveCase;
        [SerializeField] private GameObject _tapToRestart;

        // TEMPORARY
        [SerializeField] private GameObject _plane;

        // TEMPORARY

        private bool flag = false;
        public bool hasStartedPainting = false;

        private void Start()
        {
            EventManager.current.onCaseAnimationEnd += delegate { _swipeToSprinkleCase.SetActive(true); };
            EventManager.current.onCaseSprayComplete += delegate { TurnOffAll(); _swipeToDraw.SetActive(true); };
            EventManager.current.onCaseMarkerComplete += delegate { TurnOffAll(); _dragAndDropSticker.SetActive(true); _swipeToRotateCase.SetActive(true); };
            EventManager.current.onSelectedSticker += delegate { _dragAndDropSticker.SetActive(false); };
            EventManager.current.onCaseStickerComplete += delegate { TurnOffAll(); _swipeToOpenCase.SetActive(true); };
            EventManager.current.onCaseOpened += delegate { TurnOffAll(); _swipeToMoveCase.SetActive(true); };
            EventManager.current.onStartEarbudsSpray += delegate { TurnOffAll(); _swipeToRotateCase.SetActive(true); };
            EventManager.current.onGameFinished += delegate { TurnOffAll(); _tapToRestart.SetActive(true); }; 
            EventManager.current.onShowEndScreen += delegate { TurnOffAll(); };
        }

        private void Update()
        {
            if (!flag && hasStartedPainting)
            {
                flag = true;
                Invoke("ShowRotateCase", 1f);
            }
        }

        private void ShowRotateCase()
        {
            EventManager.current.StartedSpray();
            _swipeToSprinkleCase.SetActive(false);
            _swipeToRotateCase.SetActive(true);
        }

        private void TurnOffAll()
        {
            _swipeToSprinkleCase.SetActive(false);
            _swipeToRotateCase.SetActive(false);
            _swipeToDraw.SetActive(false);
            _dragAndDropSticker.SetActive(false);
            _swipeToOpenCase.SetActive(false);
            _swipeToMoveCase.SetActive(false);
            _tapToRestart.SetActive(false);
        }
    }
}
