using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Aezakmi.UI
{
    public class RequestManager : MonoBehaviour
    {
        private List<Sprite> _caseSprites;
        private List<Sprite> _earbudsSprites;

        [Header("Normal")]
        [SerializeField] private List<Sprite> _normalCaseSprites;
        [SerializeField] private List<Sprite> _normalEarbudsSprites;

        [Header("Pokemon")]
        [SerializeField] private List<Sprite> _pokemonCaseSprites;
        [SerializeField] private List<Sprite> _pokemonEarbudsSprites;

        [Space(20)]
        [SerializeField] private GameObject _bubbleParent;
        [SerializeField] private SpriteRenderer _bubbleSprite;
        [SerializeField] private GameObject _requestCanvas;
        [SerializeField] private Image _requestUI;

        private int _currentIndex;

        private void Start()
        {
            CopyListOfCaseType();
            _currentIndex = Random.Range(0, _caseSprites.Count);

            _bubbleSprite.sprite = _caseSprites[_currentIndex];
            _requestUI.sprite = _caseSprites[_currentIndex];

            EventManager.current.onCaseAnimationEnd += OrganizeRequest;
            EventManager.current.onStartEarbudsSpray += SetEarbudsRequest;
            EventManager.current.onGameFinished += DisableRequestBubble;
        }

        private void CopyListOfCaseType()
        {
            if(ReferenceManager.Instance.CurrentCaseType == CaseType.Normal)
            {
                _caseSprites = _normalCaseSprites;
                _earbudsSprites = _normalEarbudsSprites;
            }
            else if(ReferenceManager.Instance.CurrentCaseType == CaseType.Pokemon)
            {
                _caseSprites = _pokemonCaseSprites;
                _earbudsSprites = _pokemonEarbudsSprites;
            }
        }

        private void OrganizeRequest()
        {
            _bubbleParent.SetActive(false);
            _requestCanvas.SetActive(true);

            _bubbleSprite.enabled = false;
            _requestUI.enabled = true;
        }

        private void SetEarbudsRequest()
        {
            _requestUI.sprite = _earbudsSprites[_currentIndex];

            _requestUI.preserveAspect = true;
            _requestUI.transform.localScale = Vector3.one;
        }

        private void DisableRequestBubble()
        {
            _requestCanvas.SetActive(false);
        }
    }
}
