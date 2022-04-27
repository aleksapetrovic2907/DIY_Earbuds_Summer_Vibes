using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using System.Collections.Generic;

namespace Aezakmi.PaintMechanics
{
    public class StickerManager : MonoBehaviour
    {
        [SerializeField] private Camera _mainCamera;
        [SerializeField] private GameObject _stickerGuideCanvas;
        [SerializeField] private GameObject _stickerGuide;
        [SerializeField] private GameObject _brushEntity;
        [SerializeField] private ItemRotator _itemRotator;

        private bool _stickerSelected = false;
        private GameObject _guide = null;
        private Paintable _currentPaintable = null;
        private GameObject brushObject = null;

        private bool flag = false;

        private const int MAX_PAINT_DISTANCE = 200;
        private int _stickersPlaced = 0;

        private void Update()
        {
            if (InputManager.current.IsTouching)
            {
                Touch touch = InputManager.current.Touch;

                if (touch.phase == TouchPhase.Began)
                {
                    _stickerSelected = false;

                    var pointerEventData = new PointerEventData(null);
                    pointerEventData.position = touch.position;
                    List<RaycastResult> hitsList = new List<RaycastResult>();
                    EventSystem.current.RaycastAll(pointerEventData, hitsList);

                    foreach (var hit in hitsList)
                        if (hit.gameObject.tag == "Sticker") InstantiateGuide(hit.gameObject);
                }
            }

            if (InputManager.current.IsTouching && _stickerSelected)
            {
                _itemRotator.enabled = false;
                _guide.transform.position = InputManager.current.Touch.position;

                Vector3 uvWorldPosition = Vector3.zero;

                if (HitTestUVPosition(ref uvWorldPosition))
                {

                    if (brushObject != null) Destroy(brushObject);

                    brushObject = Instantiate(_brushEntity); // Paint a brush
                    brushObject.GetComponent<SpriteRenderer>().sprite = _guide.GetComponent<Image>().sprite;
                    brushObject.GetComponent<Renderer>().sortingOrder = _stickersPlaced + 1;

                    brushObject.transform.parent = _currentPaintable.StickerContainer.transform; // Add the brush to our container to be wiped later
                    brushObject.transform.localPosition = uvWorldPosition; // The position of the brush (in the UVMap)

                    _guide.SetActive(false);
                }
                else
                {
                    _guide.SetActive(true);
                    if (brushObject != null) Destroy(brushObject);
                }
            }
            else
            {
                _itemRotator.enabled = true;
            }

            if (InputManager.current.Touch.phase == TouchPhase.Ended && _stickerSelected)
            {
                _stickerSelected = false;

                Vector3 uvWorldPosition = Vector3.zero;

                if (HitTestUVPosition(ref uvWorldPosition))
                {

                    if (brushObject != null) Destroy(brushObject);

                    brushObject = Instantiate(_brushEntity); // Paint a brush
                    brushObject.GetComponent<SpriteRenderer>().sprite = _guide.GetComponent<Image>().sprite;

                    brushObject.GetComponent<Renderer>().sortingOrder = ++_stickersPlaced;

                    brushObject.transform.parent = _currentPaintable.StickerContainer.transform; // Add the brush to our container to be wiped later
                    brushObject.transform.localPosition = uvWorldPosition; // The position of the brush (in the UVMap)

                    brushObject = null;
                }

                Destroy(_guide.gameObject);
            }
        }

        private void InstantiateGuide(GameObject obj)
        {
            _stickerSelected = true;
            _guide = Instantiate(_stickerGuide, InputManager.current.Touch.position, Quaternion.identity, _stickerGuideCanvas.transform);
            _guide.GetComponent<Image>().sprite = obj.GetComponent<Image>().sprite;


            if(!flag)
            {
                flag = true;
                EventManager.current.CaseStickerSelected();
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

                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
