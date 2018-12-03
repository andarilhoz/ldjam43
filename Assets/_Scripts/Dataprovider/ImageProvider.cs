using System;
using System.Collections;
using DefaultNamespace;
using Injection;
using UnityEngine;
using UnityEngine.Networking;

namespace _Scripts.Dataprovider
{
    public class ImageProvider : IInjectable
    {
        [Inject] protected GameConfig GameConfig;
        [Inject] protected AppContext AppContext;
        
        
        public void GetImage(string imagePath, Action<Sprite> callback)
        {
            Debug.Log($"{GameConfig.UrlArt}/{imagePath}");
            UnityWebRequest request = UnityWebRequest.Get($"{GameConfig.UrlArt}/{imagePath}.png");
            AppContext.StartCoroutine(Request(request, callback));
        }

        private IEnumerator Request(UnityWebRequest request, Action<Sprite> callback)
        {
            yield return request.SendWebRequest();
            if (request.isNetworkError || request.isHttpError)
            {
                Debug.LogError("Deu ruim");
                Debug.LogError(request.error);
            }
            else
            {
                Debug.Log(request.downloadHandler.data);
                callback(GenerateSprite(request.downloadHandler.data));
            }
        }

        public Sprite GenerateSprite(byte[] bytes)
        {
            Texture2D text = new Texture2D(1, 1);
            text.LoadImage(bytes);
            text.Apply();
            return Sprite.Create(text, new Rect(0, 0, text.width, text.height), new Vector2(.5f, .5f));
        }
    }
}