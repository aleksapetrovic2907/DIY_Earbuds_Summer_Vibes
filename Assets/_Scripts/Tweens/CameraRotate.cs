using UnityEngine;
using DG.Tweening;

namespace Aezakmi.Tweens
{
    public class CameraRotate : BaseTween
    {
        [SerializeField] private Vector3 _rotationEnd;

        protected override void SetTweener()
        {
            _tweener = transform
                .DORotate(_rotationEnd, _loopDuration, RotateMode.FastBeyond360)
                .SetLoops(_loopCount, _loopType)
                .SetEase(_loopEase)
                .SetRelative(true);
        }
    }
}