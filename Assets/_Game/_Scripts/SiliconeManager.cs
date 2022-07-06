using UnityEngine;
using Aezakmi.Tweens;
using Aezakmi.PaintMechanics;
using DG.Tweening;

namespace Aezakmi
{
    public class SiliconeManager : MonoBehaviour
    {
        [SerializeField] private Material _siliconeMaterial;

        private SiliconeAnimation _leftSiliconeReturn;
        private SiliconeAnimation _rightSiliconeReturn;

        private void Start()
        {
            EventManager.current.onChooseSiliconeColor += MoveSiliconeBack;
            EventManager.current.onSiliconeColorChange += ChangeMaterialColor;
        }

        private void ChangeMaterialColor(int index)
        {
            _siliconeMaterial.SetColor("_Color", ColorPalette.SelectedSiliconeColor);

            ReferenceManager.Instance.CurrentEarbudLeftSilicone.GetComponent<Scale>().PlayTween();
            ReferenceManager.Instance.CurrentEarbudRightSilicone.GetComponent<Scale>().PlayTween();
        }

        private void MoveSiliconeBack()
        {
            ReferenceManager.Instance.CurrentEarbudLeftSilicone.SetActive(true);
            ReferenceManager.Instance.CurrentEarbudRightSilicone.SetActive(true);

            ReferenceManager.Instance.CurrentEarbudLeftSilicone.GetComponent<SiliconeAnimation>()._tweener.PlayBackwards();
            ReferenceManager.Instance.CurrentEarbudRightSilicone.GetComponent<SiliconeAnimation>()._tweener.PlayBackwards();
        }



    }
}
