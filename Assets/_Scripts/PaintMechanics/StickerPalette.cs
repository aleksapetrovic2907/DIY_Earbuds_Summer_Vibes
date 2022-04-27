using System.Collections.Generic;
using UnityEngine;

namespace Aezakmi
{
    public class StickerPalette : MonoBehaviour
    {
        public static StickerPalette current;

        public List<Sprite> stickers;

        private void Awake()
        {
            current = this;
        }
    }
}
