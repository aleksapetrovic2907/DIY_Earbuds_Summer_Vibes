using UnityEngine;

namespace Aezakmi.PaintMechanics
{
    public enum Tool { Spray, Marker }
    public class Painter : MonoBehaviour
    {
        public bool StartedPaint = false;

        [SerializeField] private Tool _toolUsed;

        [SerializeField] private GameObject _brushEntity;
        [SerializeField] private float _brushSize;
        [SerializeField] private Color32 _brushColor;
        [SerializeField] private Sprite _brushSprite;

        [SerializeField] private Camera _mainCamera;
        [SerializeField] private PaintCursor _cursor;

        [SerializeField] private ParticleSystem _cursorParticleSystem;
        [SerializeField] private PaintSoundPlayer _paintSoundPlayer;

        private const int MAX_PAINT_DISTANCE = 200;
        private Paintable _currentPaintable = null;

        private void Start()
        {
            EventManager.current.onColorChange += ChangeColors;
            _brushColor = ColorPalette.SelectedColor;
        }

        private void ChangeColors(int index)
        {
            #pragma warning disable
            if (_cursorParticleSystem != null)
                _cursorParticleSystem.startColor = ColorPalette.current.colors[index];
            _brushColor = ColorPalette.current.colors[index];
        }

        private void Update()
        {
            if (InputManager.current.IsTouching && !InputManager.current.IsClickingUI)
            {

                Paint();
            }
            else
            {
                #pragma warning disable
                if (_cursorParticleSystem != null)
                    _cursorParticleSystem.enableEmission = false;
                _paintSoundPlayer.StopPaintSound();
            }
        }

        private void Paint()
        {
            Vector3 uvWorldPosition = Vector3.zero;

            if (HitTestUVPosition(ref uvWorldPosition))
            {
                GameObject brushObject;

                brushObject = Instantiate(_brushEntity); // Paint a brush
                brushObject.GetComponent<SpriteRenderer>().sprite = _brushSprite; // Set the brush color
                brushObject.GetComponent<SpriteRenderer>().color = _brushColor; // Set the brush color

                if (_toolUsed == Tool.Spray)
                    brushObject.transform.parent = _currentPaintable.BrushContainer.transform; // Add the brush to our container to be wiped later
                else if (_toolUsed == Tool.Marker)
                    brushObject.transform.parent = _currentPaintable.MarkerContainer.transform; // Add the brush to our container to be wiped later
                    
                brushObject.transform.localPosition = uvWorldPosition; // The position of the brush (in the UVMap)
                brushObject.transform.localScale = Vector3.one * _brushSize; // The size of the brush
            }
        }

        private bool HitTestUVPosition(ref Vector3 uvWorldPosition)
        {
            RaycastHit hit;
            Vector3 cursorPos = new Vector3(InputManager.current.Touch.position.x, InputManager.current.Touch.position.y, 0.0f);
            Ray cursorRay = _mainCamera.ScreenPointToRay(cursorPos);
            if (Physics.Raycast(cursorRay, out hit, MAX_PAINT_DISTANCE))
            {
                MeshCollider meshCollider = hit.collider as MeshCollider;
                if (meshCollider == null || meshCollider.sharedMesh == null || meshCollider.gameObject.tag != "Paintable")
                    return false;

                _currentPaintable = hit.collider.gameObject.GetComponent<Paintable>();
                var canvasCam = _currentPaintable.CanvasCamera;

                Vector2 pixelUV = new Vector2(hit.textureCoord.x, hit.textureCoord.y);
                uvWorldPosition.x = pixelUV.x - canvasCam.orthographicSize; //To center the UV on X
                uvWorldPosition.y = pixelUV.y - canvasCam.orthographicSize; //To center the UV on Y
                uvWorldPosition.z = 0.0f;



                PlayEffects(hit);

                return true;
            }
            else
            {
                return false;
            }
        }

        private void PlayEffects(RaycastHit hit)
        {
            // _cursor.UpdateTarget(hit);
            // // Vibration.Vibrate(10000, -1, false);

            if (_cursorParticleSystem != null)
                _cursorParticleSystem.enableEmission = true;

            _paintSoundPlayer.StartPaintSound();
            StartedPaint = true;
        }
    }
}
