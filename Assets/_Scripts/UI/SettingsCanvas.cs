using System;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

namespace Aezakmi
{
    public class SettingsCanvas : MonoBehaviour
    {
        [SerializeField] private GameObject _debugMenu;
        [SerializeField] private GameObject _tools;

        [Header("Camera Settings")]
        [SerializeField] private Camera _mainCamera;
        [SerializeField] private Slider _sliderFOV;
        [SerializeField] private TMP_InputField[] _cameraPosition;
        [SerializeField] private TMP_InputField[] _cameraRotation;

        [Header("Material Settings")]
        [SerializeField] private Material _baseMaterial;
        [SerializeField] private Slider _sliderMetallic;
        [SerializeField] private Slider _sliderSmoothness;
        [SerializeField] private TMP_InputField[] _baseColors;

        private void Start()
        {
            EventManager.current.onShowEndScreen += delegate { gameObject.SetActive(false); };

            // CAMERA
            _sliderFOV.value = _mainCamera.fieldOfView;

            _cameraPosition[0].text = _mainCamera.transform.position.x.ToString();
            _cameraPosition[1].text = _mainCamera.transform.position.y.ToString();
            _cameraPosition[2].text = _mainCamera.transform.position.z.ToString();

            _cameraRotation[0].text = _mainCamera.transform.rotation.x.ToString();
            _cameraRotation[1].text = _mainCamera.transform.rotation.y.ToString();
            _cameraRotation[2].text = _mainCamera.transform.rotation.z.ToString();

            // MATERIAL
            _sliderMetallic.value = _baseMaterial.GetFloat("_Metallic");
            _sliderSmoothness.value = _baseMaterial.GetFloat("_Glossiness");

            _baseColors[0].text = (_baseMaterial.GetColor("_Color").r * 255f).ToString();
            _baseColors[0].text = (_baseMaterial.GetColor("_Color").g * 255f).ToString();
            _baseColors[0].text = (_baseMaterial.GetColor("_Color").b * 255f).ToString();
        }

        public void OpenDebugMenu()
        {
            _debugMenu.SetActive(true);
            _tools.SetActive(false);
        }

        public void CloseDebugMenu()
        {
            _debugMenu.SetActive(false);
            _tools.SetActive(true);
        }

        public void UpdateCameraFOV()
        {
            _mainCamera.fieldOfView = _sliderFOV.value;
        }

        public void UpdateCameraPosition()
        {
            Vector3 newPosition = new Vector3(float.Parse(_cameraPosition[0].text.Trim()),
                                    float.Parse(_cameraPosition[1].text.Trim()),
                                    float.Parse(_cameraPosition[2].text.Trim()));

            _mainCamera.transform.position = newPosition;
        }

        public void UpdateCameraRotation()
        {
            Vector3 newRotation = new Vector3(float.Parse(_cameraRotation[0].text.Trim()),
                                    float.Parse(_cameraRotation[1].text.Trim()),
                                    float.Parse(_cameraRotation[2].text.Trim()));

            _mainCamera.transform.eulerAngles = newRotation;
        }

        public void UpdateMaterialMetallic()
        {
            _baseMaterial.SetFloat("_Metallic", _sliderMetallic.value);
            Debug.Log(_sliderMetallic.value);
        }

        public void UpdateMaterialSmoothness()
        {
            _baseMaterial.SetFloat("_Glossiness", _sliderSmoothness.value);
        }

        public void UpdateMaterialColor()
        {
            var newColor = new Color(float.Parse(_baseColors[0].text.Trim()) / 255.0f,
                                    float.Parse(_baseColors[1].text.Trim()) / 255.0f,
                                    float.Parse(_baseColors[2].text.Trim()) / 255.0f);

            _baseMaterial.SetColor("_Color", newColor);
        }
    }
}
