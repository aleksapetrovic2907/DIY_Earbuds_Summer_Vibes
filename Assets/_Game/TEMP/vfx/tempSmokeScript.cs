using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Aezakmi
{
    public class tempSmokeScript : MonoBehaviour
    {
        private ParticleSystem _particleSystem;
        private void Start()
        {
            _particleSystem = GetComponent<ParticleSystem>();
            EventManager.current.onGameFinished += delegate { _particleSystem.enableEmission = true; };
        }
    }
}
