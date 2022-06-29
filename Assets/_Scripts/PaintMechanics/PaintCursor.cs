using UnityEngine;
using Aezakmi.UI;

namespace Aezakmi.PaintMechanics
{
    public class PaintCursor : MonoBehaviour
    {
        [SerializeField] private float _distance;
        [SerializeField] private float _movementSpeed;
        [SerializeField] private float _rotationSpeed;

        private Vector3? targetPosition = null;

        private RaycastHit _hit;
        private Vector3 _hitPoint;
        public Tools ThisTool;

        private Camera _mainCamera;
        private const float MAX_PAINT_DISTANCE = 200f;


        [SerializeField] private ParticleSystem _particleSystem;
        [SerializeField] private PaintSoundPlayer _paintSoundPlayer;

        private void Update()
        {
            if (InputManager.current.IsTouching && !InputManager.current.IsClickingUI)
            {
                if (HitPaintable() && ThisTool == ToolsManager.current.CurrentTool)
                {
                    PlayParticles();
                    _paintSoundPlayer.StartPaintSound();
                }
            }
            else
            {
                StopParticles();
                _paintSoundPlayer.StopPaintSound();
            }

            if (ThisTool != ToolsManager.current.CurrentTool)
                targetPosition = null;

            if (targetPosition != null && ThisTool == ToolsManager.current.CurrentTool)
                UpdateCursorPosition();
        }


        private void UpdateCursorPosition()
        {
            transform.position = Vector3.Lerp(transform.position, (Vector3)targetPosition, Time.deltaTime * _movementSpeed);

            Vector3 dir = (_hitPoint - transform.position).normalized;
            Quaternion lookRotation = Quaternion.LookRotation(dir);
            transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * _rotationSpeed);
        }

        private void Awake()
        {
            _mainCamera = Camera.main;
        }

        private void Start()
        {
            EventManager.current.onColorChange += ChangeParticleColor;
        }

        private bool HitPaintable()
        {
            Vector3 cursorPos = new Vector3(InputManager.current.Touch.position.x, InputManager.current.Touch.position.y, 0.0f);
            Ray cursorRay = _mainCamera.ScreenPointToRay(cursorPos);
            if (Physics.Raycast(cursorRay, out _hit, MAX_PAINT_DISTANCE))
            {
                MeshCollider meshCollider = _hit.collider as MeshCollider;
                if (meshCollider == null || meshCollider.sharedMesh == null || meshCollider.gameObject.tag != "Paintable")
                {
                    return false;
                }
                else if (meshCollider.gameObject.tag == "Paintable")
                {
                    _hitPoint = _hit.point;
                    targetPosition = _hit.point + _hit.normal * _distance;
                    InstructionsManager.current.hasStartedPainting = true;
                    return true;
                }

                return false;
            }
            else
            {
                return false;
            }
        }

        private void PlayParticles()
        {
#pragma warning disable
            if (_particleSystem != null)
                _particleSystem.enableEmission = true;
        }

        private void StopParticles()
        {
            if (_particleSystem != null)
                _particleSystem.enableEmission = false;
        }

        private void ChangeParticleColor(int index)
        {
            if (_particleSystem != null)
                _particleSystem.startColor = ColorPalette.current.colors[index];
        }
    }
}
