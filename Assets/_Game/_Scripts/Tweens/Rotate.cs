using UnityEngine;
using DG.Tweening;

namespace Aezakmi.Tweens
{
    public class Rotate : BaseTween
    {
        [SerializeField] private Vector3 _rotationStart;
        [SerializeField] private Vector3 _rotationEnd;

        protected override void SetTweener()
        {
            _tweener = transform
                .DORotate(_rotationEnd, _loopDuration, RotateMode.FastBeyond360)
                .From(_rotationStart)
                .SetLoops(_loopCount, _loopType)
                .SetEase(_loopEase)
                .SetRelative(true);
        }
    }
}