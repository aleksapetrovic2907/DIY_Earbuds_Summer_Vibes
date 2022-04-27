using UnityEngine;
using UnityEngine.SceneManagement;

namespace Aezakmi
{
    public enum Step
    { None, CaseSpray, CaseMarker, CaseSticker, EarbudsSpray, EarbudsSilicone, Finished }

    public class GameManager : MonoBehaviour
    {
        public static GameManager current;

        private void Awake()
        {
            if (current != this)
                current = this;

            Application.targetFrameRate = 90;
        }

        public Step CurrentStep = Step.None;

        private void Start()
        {
            EventManager.current.onStartEarbudsSpray += delegate { CurrentStep = Step.EarbudsSpray; };
            EventManager.current.onGameFinished += delegate { CurrentStep = Step.Finished; };
        }

        private void Update()
        {
            // IF IN MAIN MENU
            if (CurrentStep == Step.None)
            {
                if (InputManager.current.IsTouching && !InputManager.current.IsClickingUI && InputManager.current.Touch.phase == TouchPhase.Began)
                {
                    CurrentStep = Step.CaseSpray;

                    EventManager.current.GameStarted();
                }
            }

            // IF GAME ENDED
            if (CurrentStep == Step.Finished)
            {
                if (InputManager.current.IsTouching && !InputManager.current.IsClickingUI && InputManager.current.Touch.phase == TouchPhase.Began)
                {
                    EventManager.current.ShowEndScreen();
                }
            }
        }

        public void RestartGame()
        {
            SceneManager.LoadScene(0);
        }
    }
}
