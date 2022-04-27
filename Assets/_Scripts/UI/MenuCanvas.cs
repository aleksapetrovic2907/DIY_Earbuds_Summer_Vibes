using UnityEngine;

namespace Aezakmi.UI
{
    public class MenuCanvas : MonoBehaviour
    {
        private void Start()
        {
            EventManager.current.onGameStart += delegate { Destroy(gameObject); };
        }
    }
}
