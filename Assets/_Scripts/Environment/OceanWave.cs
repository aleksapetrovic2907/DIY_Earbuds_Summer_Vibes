using UnityEngine;

namespace Aezakmi
{
    public class OceanWave : MonoBehaviour
    {
        [SerializeField] private Vector2 scrollSpeed;
        private Renderer _renderer;

        private void Start()
        {
            _renderer = GetComponent<Renderer>();
        }

        private void Update()
        {
            _renderer.material.mainTextureOffset = scrollSpeed * Time.time;
        }
    }
}