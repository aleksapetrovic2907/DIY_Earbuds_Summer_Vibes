using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Aezakmi.Tweens;

namespace Aezakmi
{
    public class CameraStartAnimation : MonoBehaviour
    {
        [SerializeField] private List<BaseTween> _tweens;

        private void Start()
        {
            EventManager.current.onGameStart += PlayTweens;
        }

        private void PlayTweens()
        {
            foreach(BaseTween tween in _tweens)
            {
                tween.PlayTween();
            }
        }
    }
}
