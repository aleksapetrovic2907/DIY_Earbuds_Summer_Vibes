using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Aezakmi.UI
{
    public class RequestManager : MonoBehaviour
    {
        [SerializeField] private List<Sprite> _caseSprites;
        [SerializeField] private List<Sprite> _earbudsSprites;

        [SerializeField] private GameObject _bubbleParent;
        [SerializeField] private SpriteRenderer _bubbleSprite;
        [SerializeField] private GameObject _requestCanvas;
        [SerializeField] private Image _requestUI;

        private int _currentIndex;

        private void Start()
        {
            _currentIndex = Random.Range(0, _caseSprites.Count);

            _bubbleSprite.sprite = _caseSprites[_currentIndex];
            _requestUI.sprite = _caseSprites[_currentIndex];

            EventManager.current.onGameStart += OrganizeRequest;
            EventManager.current.onStartEarbudsSpray += SetEarbudsRequest;
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
        }
    }
}
