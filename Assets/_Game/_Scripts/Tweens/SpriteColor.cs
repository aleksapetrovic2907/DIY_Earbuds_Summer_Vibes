using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

namespace Aezakmi.Tweens
{
    public class SpriteColor : BaseTween
    {
        [SerializeField] private Color32 _endColor;
        [SerializeField] private Image _image;

        protected override void SetTweener()
        {
            _tweener = _image
                .DOColor(_endColor, _loopDuration)
                .SetLoops(_loopCount, _loopType)
                .SetEase(_loopEase);
        }
    }
}
