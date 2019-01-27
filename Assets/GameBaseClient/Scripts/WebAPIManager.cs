using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using GameBase.Data;

namespace GameBase.Networking
{
    /// <summary>
    /// API Transer Class
    /// </summary>
    public class WebAPIManager : MonoBehaviour
    {
        private UnityWebRequest request;

        private WWWForm form;

        private string resultTxt;

        /// <summary>
        /// Init this instance.
        /// </summary>
        public void Init()
        {
            request = new UnityWebRequest();

            form = new WWWForm();

            resultTxt = "";
        }

        /// <summary>
        /// Gets the request.
        /// </summary>
        /// <returns>The request.</returns>
        /// <param name="url">URL.</param>
        /// <param name="successCallback">Success callback.</param>
        /// <param name="errorCallback">Error callback.</param>
        public IEnumerator GetRequest(string url, Action<string> successCallback, Action errorCallback)
        {
            using (request = UnityWebRequest.Get(url))
            {
                yield return request.SendWebRequest();

                if (request.isHttpError || request.isNetworkError)
                {
                    Debug.Log(request.error);
                    errorCallback();
                }
                else
                {
                    Debug.Log(request.downloadHandler.text);
                    resultTxt = request.downloadHandler.text;
                    successCallback(resultTxt);
                }
            }
        }

        /// <summary>
        /// Posts the request.
        /// </summary>
        /// <returns>The request.</returns>
        /// <param name="url">URL.</param>
        /// <param name="successCallback">Success callback.</param>
        /// <param name="errorCallback">Error callback.</param>
        public IEnumerator PostRequest(string url, Action<string> successCallback, Action errorCallback)
        {
            using (request = UnityWebRequest.Post(url, form))
            {
                yield return request.SendWebRequest();

                if (request.isHttpError || request.isNetworkError)
                {
                    Debug.Log(request.error);
                    errorCallback();
                }
                else
                {
                    Debug.Log(request.downloadHandler.text);
                    resultTxt = request.downloadHandler.text;
                    successCallback(resultTxt);
                }
            }
        }

        /// <summary>
        /// Jsons the result.
        /// </summary>
        /// <returns>The result.</returns>
        /// <param name="json">Json.</param>
        /// <typeparam name="T">The 1st type parameter.</typeparam>
        public T JsonResult<T>(string json) where T : class
        {
            T t = JsonUtility.FromJson<T>(json);
            return t;
        }

        /// <summary>
        /// Adds the post data.
        /// </summary>
        /// <param name="key">Key.</param>
        /// <param name="value">Value.</param>
        public void AddPostData(string key, string value)
        {
            form.AddField(key, value);
        }

        /// <summary>
        /// Adds the request header.
        /// </summary>
        /// <param name="name">Name.</param>
        /// <param name="value">Value.</param>
        public void AddRequestHeader(string name, string value)
        {
            request.SetRequestHeader(name, value);
        }
    }

}
