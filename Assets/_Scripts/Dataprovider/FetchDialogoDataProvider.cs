using System;
using System.Collections;
using System.Collections.Generic;
using Injection;
using UnityEngine;
using UnityEngine.Networking;
using _Scripts.Core.Entity;
using _Scripts.Core.Usecase.Gateway;

namespace _Scripts.Dataprovider
{
    public class FetchDialogoDataProvider: IFetchPerguntaGateway, IInjectable
    {
        private MonoBehaviour context;
        private DataParser data;
            
        public FetchDialogoDataProvider(MonoBehaviour context, string dataUrl)
        {

            UnityWebRequest request = UnityWebRequest.Get(dataUrl);
            context.StartCoroutine(MakeRequest(request, data => { this.data = JsonUtility.FromJson<DataParser>(data); }));
        }

        private IEnumerator MakeRequest(UnityWebRequest request, Action<string> callback)
        {
            yield return request.SendWebRequest();
            if (request.isNetworkError || request.isHttpError)
            {
                Debug.LogError("Deu ruim");
                Debug.LogError(request.error);
            }
            else
            {
                callback(request.downloadHandler.text);
            }
        }

        public List<Dialogo> FetchAll()
        {
            return data.Dialogos;
        }
    }
}
