using UnityEngine;
using Aezakmi.Tweens;
using DG.Tweening;

namespace Aezakmi
{
    public class CaseOpener : MonoBehaviour
    {
        private BaseTween _upperCaseRotateTween;
        private MoveToPosition _caseMoveTween;
        private Scale _earbudsScaleTween;
        private MoveByAmount _earbudsMoveToPosRight;
        private MoveByAmount _earbudsMoveToPosLeft;
        private SiliconeAnimation _leftSilicone;
        private SiliconeAnimation _rightSilicone;

        private bool _grabbedReferences = false;
        private bool _flag0 = false;
        private bool _flag1 = false;
        private bool _flag2 = false;
        private bool _flag3 = false;
        private bool _flag4 = false;
        
        private void Awake()
        {
            InputManager.current.SwipeDirection = null;

            _upperCaseRotateTween = ReferenceManager.Instance.CurrentCaseUpper.GetComponent<BaseTween>();
            _caseMoveTween = ReferenceManager.Instance.CurrentCase;
            _earbudsScaleTween = ReferenceManager.Instance.CurrentEarbuds.GetComponent<Scale>();
            _earbudsMoveToPosLeft = ReferenceManager.Instance.CurrentEarbudLeft.GetComponent<MoveByAmount>();
            _earbudsMoveToPosRight = ReferenceManager.Instance.CurrentEarbudRight.GetComponent<MoveByAmount>();
            _leftSilicone = ReferenceManager.Instance.CurrentEarbudLeftSilicone.GetComponent<SiliconeAnimation>();
            _rightSilicone = ReferenceManager.Instance.CurrentEarbudRightSilicone.GetComponent<SiliconeAnimation>();

            _grabbedReferences = true;
        }

        private void Update()
        {
            if(_grabbedReferences)
                OpenCase();
        }

        private void OpenCase()
        {
            if (InputManager.current.SwipeDirection == Swipes.Up && !_flag0)
            {
                _flag0 = true;
                _upperCaseRotateTween.PlayTween();
                EventManager.current.CaseOpened();
            }

            if (InputManager.current.SwipeDirection == Swipes.Down && !_flag1 && _upperCaseRotateTween.IsComplete)
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
