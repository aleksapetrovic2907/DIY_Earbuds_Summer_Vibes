using UnityEngine;
using Aezakmi.Tweens;
using DG.Tweening;

namespace Aezakmi
{
    public class CaseCloser : MonoBehaviour
    {
        [SerializeField] private GameObject _rotatingParent;
        [SerializeField] private float _parentScale;


        [SerializeField] private GameObject _case;
        [SerializeField] private float _caseScale;

        [Space(10)]
        [SerializeField] private GameObject _earbuds;
        [SerializeField] private float _earbudsScale;


        [SerializeField] private GameObject _leftEarbud;
        [SerializeField] private GameObject _rightEarbud;
        [SerializeField] private Vector3 _leftEarbudPosition;
        [SerializeField] private Vector3 _rightEarbudPosition;


        private void Start()
        {
            EventManager.current.onGameFinished += StartAnimations;
        }

        private void StartAnimations()
        {
            _case.transform.localScale = Vector3.one * _caseScale;
            _leftEarbud.transform.position += new Vector3(.05f, 0f, 0f);
            _rightEarbud.transform.position -= new Vector3(.07f, 0f, 0f);

            Vector3 originalRotation = new Vector3(0f, 180f, 0f);
            _leftEarbud.transform.rotation = Quaternion.Euler(originalRotation);
            _rightEarbud.transform.rotation = Quaternion.Euler(originalRotation);
            _earbuds.transform.localScale = Vector3.one * _earbudsScale;

            _case.transform.parent = _rotatingParent.transform;
            _case.transform.localPosition = Vector3.zero;
            
            _earbuds.transform.parent = _rotatingParent.transform;
            _earbuds.transform.localPosition = Vector3.zero;

            _rotatingParent.transform.localScale = Vector3.one * _parentScale;

            _leftEarbud.transform.localPosition = _leftEarbudPosition;
            _rightEarbud.transform.localPosition = _rightEarbudPosition;

            _rotatingParent.GetComponent<Rotate>().PlayTween();
        }
    }
}