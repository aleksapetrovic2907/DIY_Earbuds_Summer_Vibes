using UnityEngine;
using DG.Tweening;

namespace Aezakmi.Tweens
{
    public class Scale : BaseTween
    {
        [SerializeField] private Vector3 _scaleEnd;

        protected override void SetTweener()
        {
            _tweener = transform
                .DOScale(_scaleEnd, _loopDuration)
                .SetLoops(_loopCount, _loopType)
                .SetEase(_loopEase)
                .SetDelay(_delay);
        }
    }
}