using UnityEngine;
using Aezakmi.Tweens;

namespace Aezakmi
{
    public class CharacterAnimator : MonoBehaviour
    {
        [SerializeField] private Animator _animator;
        [SerializeField] private Vector3 _offset;
        [SerializeField] private Scale _bubbleScale;

        private bool _flag0 = false;

        private void Start()
        {
            EventManager.current.onGameFinished += StartDance;
        }

        private void Update()
        {
            if(!_flag0 && _animator.GetCurrentAnimatorStateInfo(0).IsName("Idle"))
            {
                _flag0 = true;
                _bubbleScale.PlayTween();
            }
        }

        private void StartDance()
        {
            transform.position += _offset;
            _animator.Play("Dance");
        }
    }
}
