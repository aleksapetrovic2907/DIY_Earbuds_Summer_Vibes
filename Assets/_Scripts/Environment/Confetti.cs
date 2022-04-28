using System.Collections.Generic;
using UnityEngine;

namespace Aezakmi
{
    public class Confetti : MonoBehaviour
    {
        [SerializeField] private List<Color32> _colors;

        private ParticleSystem _particleSystem;
        private ParticleSystem.Particle[] _particles = new ParticleSystem.Particle[100];
        private bool _isPlaying = false;

        private void Start()
        {
            _particleSystem = GetComponent<ParticleSystem>();
            EventManager.current.onGameFinished += Burst;
            EventManager.current.onShowEndScreen += delegate { Destroy(gameObject); };
        }

        private void Burst()
        {
            #pragma warning disable
            _particleSystem.enableEmission = true;
            _particleSystem.Play();
            _isPlaying = true;
        }

        private void LateUpdate()
        {
            if (_isPlaying)
            {
                int numOfParticles = _particleSystem.GetParticles(_particles);

                if (_particles != null)
                {
                    for (int i = 0; i < numOfParticles; i++)
                    {
                        if (_particles[i].startColor == Color.white)
                        {
                            _particles[i].startColor = RandomColor();
                        }
                    }
                }

                _particleSystem.SetParticles(_particles, numOfParticles);
            }
        }

        private Color32 RandomColor()
        {
            return _colors[Random.Range(0, 4)];
        }
    }
}
