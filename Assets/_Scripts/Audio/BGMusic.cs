using UnityEngine;

namespace Aezakmi.Audio
{
    public class BGMusic : MonoBehaviour
    {
        private void Awake()
        {
            if (GameObject.FindGameObjectsWithTag("Music").Length > 1)
            {
                Destroy(gameObject);
            }
            else
            {
                DontDestroyOnLoad(gameObject);
            }

        }
    }
}
