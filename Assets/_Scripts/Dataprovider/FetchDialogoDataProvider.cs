using System;
using System.Collections;
using System.Collections.Generic;
using DefaultNamespace;
using Injection;
using UnityEngine;
using UnityEngine.Networking;
using _Scripts.Core.Entity;
using _Scripts.Core.Usecase.Gateway;

namespace _Scripts.Dataprovider
{
    public class FetchDialogoDataProvider: IFetchPerguntaGateway, IInjectable
    {
        private DataParser data;

        [Inject] protected GameConfig GameConfig;
        [Inject] protected AppContext AppContext; 
        
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
                Debug.Log(request.downloadHandler.text);
                callback(request.downloadHandler.text);
            }
        }

        public void FetchAll( Action<List<Dialogo>> callback)
        {
            UnityWebRequest request = UnityWebRequest.Get(GameConfig.UrlData);
            AppContext.StartCoroutine(MakeRequest(request, data =>
            {
                var response = JsonUtility.FromJson<DataParser>(data);
                callback(response.Dialogos);
            }));
        }
    }
}
