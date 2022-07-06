using System.Collections.Generic;
using UnityEngine;

namespace Aezakmi
{
    public class NPCTextureManager : MonoBehaviour
    {
        [SerializeField] private List<Texture> _textures;
        [SerializeField] private Material _material;

        private void Awake()
        {
            _material.SetTexture("_MainTex", _textures[Random.Range(0, _textures.Count)]);
        } 
    }
}
