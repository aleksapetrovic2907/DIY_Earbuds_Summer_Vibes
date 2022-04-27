using UnityEngine;

namespace Aezakmi.PaintMechanics
{
    public class PaintCursor : MonoBehaviour
    {
        [SerializeField] private float _distance;
        [SerializeField] private float _movementSpeed;
        [SerializeField] private float _rotationSpeed;

        public Vector3 targetPosition;

        private RaycastHit _hit;
        public bool canMove = false;

        private void Update()
        {
            if (canMove)
                UpdateCursorPosition();
        }

        public void UpdateTarget(RaycastHit target)
        {
            _hit = target;
            canMove = true;
        }

        private void UpdateCursorPosition()
        {
            targetPosition = _hit.point + _hit.normal * _distance;
            transform.position = Vector3.Lerp(transform.position, targetPosition, Time.deltaTime * _movementSpeed);

            Vector3 dir = (_hit.point - transform.position).normalized;
            Quaternion lookRotation = Quaternion.LookRotation(dir);
            transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * _rotationSpeed);
        }
    }
}
