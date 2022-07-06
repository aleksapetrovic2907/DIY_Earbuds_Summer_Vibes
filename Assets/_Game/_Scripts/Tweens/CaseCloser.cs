using UnityEngine;
using Aezakmi.Tweens;
using DG.Tweening;

namespace Aezakmi
{
    public class CaseCloser : MonoBehaviour
    {
        [SerializeField] private GameObject _rotatingParent;
        [SerializeField] private float _parentScale;


        private GameObject _case;
        [SerializeField] private float _caseScale;

        [Space(10)]
        private GameObject _earbuds;
        [SerializeField] private float _earbudsScale;

        private GameObject _leftEarbud;
        private GameObject _rightEarbud;
        [SerializeField] private Vector3 _leftEarbudPosition;
        [SerializeField] private Vector3 _rightEarbudPosition;

        private void Start()
        {
            EventManager.current.onGameFinished += StartAnimations;

            _case = ReferenceManager.Instance.CurrentCase.gameObject;
            _earbuds = ReferenceManager.Instance.CurrentEarbuds;
            _leftEarbud = ReferenceManager.Instance.CurrentEarbudLeft;
            _rightEarbud = ReferenceManager.Instance.CurrentEarbudRight;
        }

        private void StartAnimations()
        {
            _case.transform.localScale = Vector3.one * _caseScale;
            // _leftEarbud.transform.position += new Vector3(.05f, 0f, 0f);

            Vector3 originalRotation = new Vector3(0f, 180f, 0f);
            _leftEarbud.transform.rotation = Quaternion.Euler(originalRotation);
            _rightEarbud.transform.rotation = Quaternion.Euler(originalRotation);
            _earbuds.transform.localScale = Vector3.one * _earbudsScale;
            _leftEarbud.transform.localScale = new Vector3(-_leftEarbud.transform.localScale.x, _leftEarbud.transform.localScale.y, -_leftEarbud.transform.localScale.x); 
            _rightEarbud.transform.localScale = new Vector3(-_rightEarbud.transform.localScale.x, _rightEarbud.transform.localScale.y, _rightEarbud.transform.localScale.x); 

            _case.transform.parent = _rotatingParent.transform;
            _case.transform.rotation = Quaternion.Euler(originalRotation);
            _case.transform.localPosition = Vector3.zero;
            
            _earbuds.transform.parent = _rotatingParent.transform;
            _earbuds.transform.localPosition = Vector3.zero;

            _rotatingParent.transform.localScale = Vector3.one * _parentScale;

            _leftEarbud.transform.localPosition = _rightEarbudPosition;
            _rightEarbud.transform.localPosition = _leftEarbudPosition;
            _rightEarbud.transform.position -= new Vector3(0f, -0.046f, 0.044f);
            _leftEarbud.transform.position -= new Vector3(0f, -0.046f, 0.044f);

            _rotatingParent.GetComponent<Rotate>().PlayTween();
        }
    }
}