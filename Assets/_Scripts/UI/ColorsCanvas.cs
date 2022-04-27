using UnityEngine;
using UnityEngine.UI;
using Aezakmi.PaintMechanics;

namespace Aezakmi.UI
{
    public class ColorsCanvas : MonoBehaviour
    {
        [SerializeField] private GameObject _spraysScrollView;
        [SerializeField] private GameObject _markersScrollView;
        [SerializeField] private GameObject _stickersScrollView;
        [SerializeField] private GameObject _siliconeScrollView;
        [SerializeField] private GameObject _containerSprays;
        [SerializeField] private GameObject _containerMarkers;
        [SerializeField] private GameObject _containerStickers;
        [SerializeField] private GameObject _containerSilicones;
        [SerializeField] private GameObject _sprayPrefab;
        [SerializeField] private GameObject _markerPrefab;
        [SerializeField] private GameObject _stickerPrefab;
        [SerializeField] private GameObject _siliconePrefab;

        private void Start()
        {
            SortItemsInScrollView();
            EventManager.current.onCaseAnimationEnd += delegate { TurnOffAll(); _spraysScrollView.SetActive(true); };
            EventManager.current.onCaseSprayComplete += delegate { TurnOffAll(); _markersScrollView.SetActive(true); };
            EventManager.current.onCaseMarkerComplete += delegate { TurnOffAll(); _stickersScrollView.SetActive(true); };
            EventManager.current.onCaseStickerComplete += delegate { TurnOffAll(); };
            EventManager.current.onStartEarbudsSpray += delegate { TurnOffAll(); _spraysScrollView.SetActive(true); };
            EventManager.current.onChooseSiliconeColor += delegate { TurnOffAll(); _siliconeScrollView.SetActive(true); };
            EventManager.current.onGameFinished += delegate { TurnOffAll(); };
        }

        private void TurnOffAll()
        {
            _spraysScrollView.SetActive(false);
            _markersScrollView.SetActive(false);
            _stickersScrollView.SetActive(false);
            _siliconeScrollView.SetActive(false);
        }

        public void SortItemsInScrollView()
        {

            for (int i = 0; i < ColorPalette.current.colors.Count; i++)
            {

                // SPRAYS
                var sprayInstance = Instantiate(_sprayPrefab, _containerSprays.transform);
                var sprayInstanceRect = sprayInstance.GetComponent<RectTransform>();
                sprayInstanceRect.anchoredPosition = new Vector2(sprayInstanceRect.anchoredPosition.x + sprayInstanceRect.sizeDelta.x * i, sprayInstanceRect.anchoredPosition.y);

                sprayInstance.GetComponent<ItemColorer>().SetColor(ColorPalette.current.colors[i], i);

                // MARKERS
                var markerInstance = Instantiate(_markerPrefab, _containerMarkers.transform);
                var markerInstanceRect = markerInstance.GetComponent<RectTransform>();
                markerInstanceRect.anchoredPosition = new Vector2(markerInstanceRect.anchoredPosition.x + markerInstanceRect.sizeDelta.x * i, markerInstanceRect.anchoredPosition.y);

                markerInstance.GetComponent<ItemColorer>().SetColor(ColorPalette.current.colors[i], i);

                // SILICONE
                var siliconeInstance = Instantiate(_siliconePrefab, _containerSilicones.transform);
                var siliconeInstanceRect = siliconeInstance.GetComponent<RectTransform>();
                siliconeInstanceRect.anchoredPosition = new Vector2(siliconeInstanceRect.anchoredPosition.x + siliconeInstanceRect.sizeDelta.x * i, siliconeInstanceRect.anchoredPosition.y);

                siliconeInstance.GetComponent<ItemColorer>().SetColor(ColorPalette.current.colors[i], i);
            }

            for (int i = 0; i < StickerPalette.current.stickers.Count; i++)
            {
                var instance = Instantiate(_stickerPrefab, _containerStickers.transform);
                var instanceRect = instance.GetComponent<RectTransform>();
                instanceRect.anchoredPosition = new Vector2(instanceRect.anchoredPosition.x + instanceRect.sizeDelta.x * i, instanceRect.anchoredPosition.y);

                instance.GetComponent<Image>().sprite = StickerPalette.current.stickers[i];
            }
        }
    }
}
