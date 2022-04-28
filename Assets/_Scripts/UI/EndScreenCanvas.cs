using UnityEngine;

namespace Aezakmi.UI
{
    public class EndScreenCanvas : MonoBehaviour
    {
        [SerializeField] private GameObject _parent;
        [SerializeField] private GameObject _endCamera;

        private void Start()
        {
            EventManager.current.onShowEndScreen += ShowEndScreen;
        }

        private void ShowEndScreen()
        {
            _parent.SetActive(true);
            _endCamera.SetActive(true);
        }
    }
}
