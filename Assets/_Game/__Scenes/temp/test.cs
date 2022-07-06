using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Aezakmi
{
    public class test : MonoBehaviour
    {
        [SerializeField] private float _duration;
        [SerializeField] private Image timer;

        private bool shouldBreak = false;

        private Coroutine timerRoutine;

        private void Awake()
        {
            timer = GetComponent<Image>();
        }

        private void Start()
        {
            UpdateTimer();
        }

        public void UpdateTimer()
        {
            float elapsed = _duration;
            if (timerRoutine == null){
                timerRoutine = StartCoroutine(UpdateInternal());
            }

            IEnumerator UpdateInternal()
            {
                while (true)
                {
                    if (shouldBreak){
                        yield break;
                    }

                    if (elapsed <= 0)
                    {
                        Debug.Log("finished!");
                        yield break;
                    }

                    elapsed -= Time.deltaTime;

                    timer.fillAmount = elapsed / _duration;
                    yield return null;
                }
            }
        }
        
    public void StopTimer() => shouldBreak = true;
    }

}
