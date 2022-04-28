using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Aezakmi.Tweens;
using DG.Tweening;

namespace Aezakmi.UI
{
    public class DopamineCanvas : MonoBehaviour
    {
        [SerializeField] private GameObject _wowEffect;
        [SerializeField] private List<Sprite> _sprites;
        [SerializeField] private AudioClip _wowAudio;

        private AudioSource _audioSource;

        private void Start()
        {
            EventManager.current.onCaseSprayComplete += PlayWowEffect;
            EventManager.current.onCaseMarkerComplete += PlayWowEffect;
            EventManager.current.onCaseStickerComplete += PlayWowEffect;
            EventManager.current.onChooseSiliconeColor += PlayWowEffect;
            EventManager.current.onGameFinished += PlayWowEffect;

            _audioSource = GetComponent<AudioSource>();
        }

        private void PlayWowEffect()
        {
            _wowEffect.GetComponent<Image>().sprite = GetRandomSprite();
            _wowEffect.GetComponent<Image>().color = Color.white;

            foreach (BaseTween tween in _wowEffect.GetComponents<BaseTween>())
            {
                tween._tweener.Restart();
                tween.PlayTween();
            }

            _audioSource.PlayOneShot(_wowAudio);
        }

        private Sprite GetRandomSprite()
        {
            return _sprites[Random.Range(0, _sprites.Count)];
        }
    }
}
