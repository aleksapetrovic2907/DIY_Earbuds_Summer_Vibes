using UnityEngine;
using UnityEngine.UI;
using Aezakmi.Tweens;

namespace Aezakmi.UI
{
    public class StepUI : MonoBehaviour
    {
        [SerializeField] private Sprite _currentStep;
        [SerializeField] private Sprite _finishedStep;

        private Image _image;

        private void Start()
        {
            _image = GetComponent<Image>();
        }

        public void CompleteStep()
        {
            _image.sprite = _finishedStep;
        }

        public void CurrentStep()
        {
            _image.sprite = _currentStep;
            GetComponent<Scale>().PlayTween();
        }
    }
}
