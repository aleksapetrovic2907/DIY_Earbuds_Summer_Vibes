using UnityEngine;
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

        public Tweener _tweener;

        [HideInInspector] public bool IsComplete = false;

        private void Awake()
        {
            SetTweener();
            _tweener.OnComplete(delegate { IsComplete = true; });

            if (_playOnAwake) PlayTween();
        }

        public void PlayTween() => _tweener.Play();

        protected abstract void SetTweener();
        private void OnDestroy() => _tweener.Kill();
    }
}