using System.Collections.Generic;
using UnityEngine;
using PaintIn3D;

namespace Aezakmi
{
    public class StickerPalette : MonoBehaviour
    {
        [SerializeField] private P3dPaintDecal _stickerPainter;

        public static StickerPalette current;

        public List<Sprite> stickers;

        public Sprite CurrentSticker;

        private void Awake()
        {
            current = this;
        }

        public void ChangeSprite(Sprite sticker)
        {
            CurrentSticker = sticker;
            _stickerPainter.Texture = CurrentSticker.texture;
        }

        private Texture SpriteToTexture(Sprite sprite)
        {
            if(sprite.rect.width != sprite.texture.width){
             Texture2D newText = new Texture2D((int)sprite.rect.width,(int)sprite.rect.height);
             Color[] newColors = sprite.texture.GetPixels((int)sprite.textureRect.x, 
                                                          (int)sprite.textureRect.y, 
                                                          (int)sprite.textureRect.width, 
                                                          (int)sprite.textureRect.height );
             newText.SetPixels(newColors);
             newText.Apply();
             return newText;
         } else
             return sprite.texture;
        }

        public void Test(Sprite sprite)
        {
            Debug.Log(sprite);
        }


    }
}
