using UnityEngine;
using Aezakmi.Tweens;

namespace Aezakmi
{
    public class CaseAnimation : MonoBehaviour
    {
        private bool _flag = false;

        [SerializeField] private Scale _scale;
        [SerializeField] private Rotate _rotate;
        [SerializeField] private MoveToPosition _moveToPos;
        private void Start()
        {
            EventManager.current.onGameStart += PlayAnimation;
        }

        private void PlayAnimation()
        {
            _scale.PlayTween();
            _moveToPos.PlayTween();
        }

        private void Update()
        {
            if(_scale != null && _scale.IsComplete && !_flag)
            {
                GetComponent<Rotate>().PlayTween();
                _flag = true;
            }

            if(_rotate != null && _rotate.IsComplete && _flag == true)
            {
                EventManager.current.CaseAnimationEnded();
                Destroy(this);
            }
        }
    }
}
