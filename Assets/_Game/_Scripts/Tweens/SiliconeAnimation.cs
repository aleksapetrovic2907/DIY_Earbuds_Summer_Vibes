using UnityEngine;
using DG.Tweening;

namespace Aezakmi.Tweens
{
    public class SiliconeAnimation : BaseTween
    {
        [SerializeField] private Vector3 _moveAmount;

        protected override void SetTweener()
        {
            _tweener = transform
                .DOLocalMove(transform.localPosition + _moveAmount, _loopDuration)
                .SetLoops(_loopCount, _loopType)
                .SetEase(_loopEase);
        }
    }
}
