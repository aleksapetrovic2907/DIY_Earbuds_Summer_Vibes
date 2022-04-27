using UnityEngine;
using DG.Tweening;

namespace Aezakmi.Tweens
{
    public class MoveByAmount : BaseTween
    {
        [SerializeField] private Vector3 _moveAmount;

        protected override void SetTweener()
        {
            _tweener = transform
                .DOMove(transform.position + _moveAmount, _loopDuration)
                .SetLoops(_loopCount, _loopType)
                .SetEase(_loopEase);
        }
    }
}
