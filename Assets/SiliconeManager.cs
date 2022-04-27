using UnityEngine;
using Aezakmi.Tweens;
using Aezakmi.PaintMechanics;
using DG.Tweening;

namespace Aezakmi
{
    public class SiliconeManager : MonoBehaviour
    {
        [SerializeField] private Material _siliconeMaterial;
        
        [SerializeField] private SiliconeAnimation _leftSiliconeReturn;
        [SerializeField] private SiliconeAnimation _rightSiliconeReturn;

        private void Start()
        {
            EventManager.current.onChooseSiliconeColor += MoveSiliconeBack;
            EventManager.current.onSiliconeColorChange += ChangeMaterialColor;
        }

        private void ChangeMaterialColor(int index)
        {
            _siliconeMaterial.SetColor("_Color", ColorPalette.SelectedSiliconeColor);
        }

        private void MoveSiliconeBack()
        {
            _leftSiliconeReturn.gameObject.SetActive(true);
            _rightSiliconeReturn.gameObject.SetActive(true);

            _leftSiliconeReturn._tweener.PlayBackwards();
            _rightSiliconeReturn._tweener.PlayBackwards();
        }



    }
}
