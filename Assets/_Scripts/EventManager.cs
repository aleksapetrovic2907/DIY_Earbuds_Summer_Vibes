using System;
using UnityEngine;

namespace Aezakmi
{
    public class EventManager : MonoBehaviour
    {
        public static EventManager current;

        private void Awake()
        {
            if (current != this)
                current = this;
        }

        public event Action onGameStart;
        public void GameStarted()
        {
            if (onGameStart != null) onGameStart();
        }


        public event Action onStepFinished;
        public void StepFinished()
        {
            if (onStepFinished != null) onStepFinished();
        }

        public event Action<int> onColorChange;
        public void ColorChanged(int index)
        {
            if (onColorChange != null) onColorChange(index);
        }

        public event Action<int> onSiliconeColorChange;
        public void SiliconeColorChanged(int index)
        {
            if (onSiliconeColorChange != null) onSiliconeColorChange(index);
        }

        public event Action onStartedSpray;
        public void StartedSpray()
        {
            if (onStartedSpray != null) onStartedSpray();
        }
        

        #region STEPS
        public event Action onCaseAnimationEnd;
        public void CaseAnimationEnded()
        {
            if (onCaseAnimationEnd != null) onCaseAnimationEnd();
        }

        public event Action onCaseSprayComplete;
        public void CaseSprayCompleted()
        {
            if(onCaseSprayComplete != null) onCaseSprayComplete();
        }

        public event Action onCaseMarkerComplete;
        public void CaseMarkerCompleted()
        {
            if(onCaseMarkerComplete != null) onCaseMarkerComplete();
        }

        public event Action onCaseStickerComplete;
        public void CaseStickerCompleted()
        {
            if(onCaseStickerComplete != null) onCaseStickerComplete();
        }

        public event Action onSelectedSticker;
        public void CaseStickerSelected()
        {
            if(onSelectedSticker != null) onSelectedSticker();
        }

        public event Action onCaseOpened;
        public void CaseOpened()
        {
            if(onCaseOpened != null) onCaseOpened();
        }

        public event Action onStartEarbudsSpray;
        public void StartEarbudsSpray()
        {
            if(onStartEarbudsSpray != null) onStartEarbudsSpray();
        }

        public event Action onChooseSiliconeColor;
        public void ChooseSiliconeColor()
        {
            if(onChooseSiliconeColor != null) onChooseSiliconeColor();
        }

        public event Action onGameFinished;
        public void GameFinished()
        {
            if(onGameFinished != null) onGameFinished();
        }

        public event Action onShowEndScreen;
        public void ShowEndScreen()
        {
            if(onShowEndScreen != null) onShowEndScreen();
        }

        #endregion
    }
}
