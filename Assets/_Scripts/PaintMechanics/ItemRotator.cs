using UnityEngine;
using UnityEngine.EventSystems;
using System.Collections.Generic;

namespace Aezakmi
{
    public class ItemRotator : MonoBehaviour
    {
        [SerializeField] private GameObject _caseParent;
        [SerializeField] private GameObject _earbudRight;
        [SerializeField] private GameObject _earbudLeft;
        [SerializeField] private float _rotateSpeed;


        private bool _canRotate = false;

        private void Start()
        {
            EventManager.current.onStartedSpray += delegate { _canRotate = true; };
            EventManager.current.onCaseStickerComplete += delegate { _canRotate = false; };
            EventManager.current.onStartEarbudsSpray += delegate { _canRotate = true; };
            EventManager.current.onGameFinished += delegate { _canRotate = false; };
        }

        private void Update()
        {
            if (InputManager.current.IsTouching && _canRotate)
            {
                Touch touch = InputManager.current.Touch;

                bool touchInRotateRect = false;

                var pointerEventData = new PointerEventData(null);
                pointerEventData.position = touch.position;
                List<RaycastResult> hitsList = new List<RaycastResult>();
                EventSystem.current.RaycastAll(pointerEventData, hitsList);

                foreach (var hit in hitsList)
                    if (hit.gameObject.tag == "RotateArea") touchInRotateRect = true;


                if (touchInRotateRect)
                {
                    bool IsCaseCurrentStep = (GameManager.current.CurrentStep == Step.CaseSpray
                                            || GameManager.current.CurrentStep == Step.CaseMarker
                                            || GameManager.current.CurrentStep == Step.CaseSticker);

                    if (IsCaseCurrentStep) Rotate(_caseParent, 1);
                    else
                    {
                        Rotate(_earbudLeft, 1);
                        Rotate(_earbudRight, -1);
                    }
                }
            }
        }

        private void Rotate(GameObject obj, int dir)
        {
            var targetRotation = Quaternion.Euler(0f, dir * -InputManager.current.MoveDelta.x * _rotateSpeed * Time.deltaTime, 0f);
            obj.transform.rotation *= targetRotation;
        }
    }
}
