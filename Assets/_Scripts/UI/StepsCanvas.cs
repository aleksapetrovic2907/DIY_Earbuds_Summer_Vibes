using UnityEngine;

namespace Aezakmi.UI
{
    public class StepsCanvas : MonoBehaviour
    {
        [SerializeField] private GameObject _stepsParent;
        [SerializeField] private StepUI _caseSpray;
        [SerializeField] private StepUI _caseMarker;
        [SerializeField] private StepUI _caseSticker;
        [SerializeField] private StepUI _earbudsSpray;
        [SerializeField] private StepUI _siliconeColor;

        private void Start()
        {
            EventManager.current.onCaseAnimationEnd += delegate { _stepsParent.SetActive(true); };
            EventManager.current.onCaseSprayComplete += CaseSprayComplete;
            EventManager.current.onCaseMarkerComplete += CaseMarkerComplete;
            EventManager.current.onCaseStickerComplete += CaseStickerComplete;
            EventManager.current.onChooseSiliconeColor += EarbudsSprayComplete;
            EventManager.current.onGameFinished += SiliconeColorComplete;
            EventManager.current.onShowEndScreen += delegate { _stepsParent.SetActive(false); };
        }


        private void CaseSprayComplete()
        {
            _caseSpray.CompleteStep();
            _caseMarker.CurrentStep();
        }

        private void CaseMarkerComplete()
        {
            _caseMarker.CompleteStep();
            _caseSticker.CurrentStep();
        }

        private void CaseStickerComplete()
        {
            _caseSticker.CompleteStep();
            _earbudsSpray.CurrentStep();
        }

        private void EarbudsSprayComplete()
        {
            _earbudsSpray.CompleteStep();
            _siliconeColor.CurrentStep();
        }

        private void SiliconeColorComplete()
        {
            _siliconeColor.CompleteStep();
        }
    }
}
