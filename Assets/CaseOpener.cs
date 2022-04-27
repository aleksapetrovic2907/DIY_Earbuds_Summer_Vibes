using UnityEngine;
using Aezakmi.Tweens;
using DG.Tweening;
namespace Aezakmi
{
    public class CaseOpener : MonoBehaviour
    {
        [SerializeField] private Rotate _caseRotateTween;
        [SerializeField] private MoveToPosition _caseMoveTween;
        [SerializeField] private Scale _earbudsScaleTween;
        [SerializeField] private MoveByAmount _earbudsMoveToPosRight;
        [SerializeField] private MoveByAmount _earbudsMoveToPosLeft;
        [SerializeField] private SiliconeAnimation _leftSilicone;
        [SerializeField] private SiliconeAnimation _rightSilicone;

        private bool _flag0 = false;
        private bool _flag1 = false;
        private bool _flag2 = false;
        private bool _flag3 = false;
        private bool _flag4 = false;


        private void Start()
        {
            InputManager.current.SwipeDirection = null;
        }

        private void Update()
        {
            if (InputManager.current.SwipeDirection == Swipes.Up && !_flag0)
            {
                _flag0 = true;
                _caseRotateTween.PlayTween();
                EventManager.current.CaseOpened();
            }

            if (InputManager.current.SwipeDirection == Swipes.Down && !_flag1 && _caseRotateTween.IsComplete)
            {
                _flag1 = true;
                _caseMoveTween.PlayTween();
            }

            if (!_flag2 && _caseMoveTween.IsComplete)
            {
                _flag2 = true;
                _earbudsScaleTween.PlayTween();
                _earbudsMoveToPosRight.PlayTween();
                _earbudsMoveToPosLeft.PlayTween();

            }


            if (!_flag3 && _earbudsMoveToPosRight.IsComplete)
            {
                _flag3 = true;

                _leftSilicone.PlayTween();
                _rightSilicone.PlayTween();
            }

            if (_leftSilicone.IsComplete)
            {
                _leftSilicone.gameObject.SetActive(false);
                _rightSilicone.gameObject.SetActive(false);
            }

            if (!_flag4 && _leftSilicone.IsComplete)
            {
                _flag4 = true;
                EventManager.current.StartEarbudsSpray();
            }

        }
    }
}
