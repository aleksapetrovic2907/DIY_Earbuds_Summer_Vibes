using UnityEngine;

namespace Aezakmi.Tweens
{
    public class EarbudsRotateOnEnd : MonoBehaviour
    {
        [SerializeField] private Rotate _rotate;

        private void Start()
        {
            EventManager.current.onGameFinished += delegate { _rotate.PlayTween(); };
        }
    }
}
