using UnityEngine;

namespace Aezakmi
{
    public class CaseResetRotation : MonoBehaviour
    {
        private void Start()
        {
            EventManager.current.onCaseStickerComplete += ResetRotation;
        }

        private void ResetRotation()
        {
            transform.rotation = Quaternion.identity;
        }
    }
}
