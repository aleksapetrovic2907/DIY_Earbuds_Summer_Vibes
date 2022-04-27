using UnityEngine;
using DG.Tweening;

namespace Aezakmi.PaintMechanics
{
    public class PaintSoundPlayer : MonoBehaviour
    {
        [Range(0f, 1f)] [SerializeField] private float _volume;
        [SerializeField] private float _fadeDuration;

        private AudioSource _audioSource;

        private void Start()
        {
            _audioSource = GetComponent<AudioSource>();
        }

        public void StartPaintSound()
        {
            _audioSource.DOFade(_volume, _fadeDuration).Play();
        }

        public void StopPaintSound()
        {
            _audioSource.DOFade(0f, _fadeDuration).Play();
        }
    }
}
