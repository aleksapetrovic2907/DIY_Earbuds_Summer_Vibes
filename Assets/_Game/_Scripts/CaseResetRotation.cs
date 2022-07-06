using UnityEngine;

namespace Aezakmi
{
    public class CaseResetRotation : MonoBehaviour
    {
        [SerializeField] private Vector3 _defaultRotation;

        private void Start()
        {
            EventManager.current.onCaseStickerComplete += ResetRotation;
        }

        private void ResetRotation()
        {
            transform.eulerAngles = _defaultRotation;
        }
    }
}
