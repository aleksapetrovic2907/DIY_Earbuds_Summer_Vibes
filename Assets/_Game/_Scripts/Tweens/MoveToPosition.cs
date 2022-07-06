using UnityEngine;
using DG.Tweening;

namespace Aezakmi.Tweens
{
    public class MoveToPosition : BaseTween
    {
        [SerializeField] private Vector3 _targetPosition;

        protected override void SetTweener()
        {
            _tweener = transform
                .DOMove(_targetPosition, _loopDuration)
                .SetLoops(_loopCount, _loopType)
                .SetEase(_loopEase);
        }
    }
}