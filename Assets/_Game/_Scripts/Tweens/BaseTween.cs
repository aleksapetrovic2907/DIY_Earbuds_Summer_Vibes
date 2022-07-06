using UnityEngine;
using UnityEngine.Events;
using DG.Tweening;

namespace Aezakmi.Tweens
{
    public abstract class BaseTween : MonoBehaviour
    {
        [SerializeField] protected int _loopCount;
        [SerializeField] protected float _loopDuration;
        [SerializeField] protected LoopType _loopType;
        [SerializeField] protected Ease _loopEase;
        [SerializeField] protected float _delay = 0f;
        [SerializeField] private bool _playOnAwake;

        [SerializeField] private UnityEvent _eventsOnComplete;

        public Tweener _tweener;

        [HideInInspector] public bool IsComplete = false;

        protected virtual void Awake()
        {
            SetTweener();
            _tweener.OnComplete(Complete);

            if (_playOnAwake) PlayTween();
        }

        public void PlayTween() => _tweener.Play();
        public void Rewind() => _tweener.Rewind();

        protected abstract void SetTweener();
        private void OnDestroy() => _tweener.Kill();


        private void Complete()
        {
            IsComplete = true;
            _eventsOnComplete.Invoke();
        }
    }
}