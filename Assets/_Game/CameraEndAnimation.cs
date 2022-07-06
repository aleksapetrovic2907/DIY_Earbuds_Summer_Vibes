using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Aezakmi.Tweens;

namespace Aezakmi
{
    public class CameraEndAnimation : MonoBehaviour
    {
        [SerializeField] private List<BaseTween> _tweens;

        private void Start()
        {
            EventManager.current.onGameFinished += PlayAnimation;
        }

        private void PlayAnimation()
        {
            foreach(BaseTween tween in _tweens)
            {
                tween.PlayTween();
            }
        }
    }
}
