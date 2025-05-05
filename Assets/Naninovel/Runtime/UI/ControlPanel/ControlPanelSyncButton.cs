using UnityEngine;
using UnityEngine.Networking;
using System.Collections;

namespace Naninovel.UI
{
    public class ControlPanelSyncButton : ScriptableButton
    {
        private IUIManager uiManager;

        protected override void Awake ()
        {
            base.Awake();

            uiManager = Engine.GetService<IUIManager>();
        }

        protected override void OnButtonClick ()
        {
            string log = uiManager.GetUI<IBacklogUI>()?.GetFullLogTextPlain();
            if (!string.IsNullOrEmpty(log))
                StartCoroutine(SendLogToServer(log));
        }

        private IEnumerator SendLogToServer(string log)
        {
            var json = JsonUtility.ToJson(new LogData { text = log });
            var request = new UnityWebRequest("http://localhost:5002/add_interaction", "POST");
            byte[] bodyRaw = System.Text.Encoding.UTF8.GetBytes(json);
            request.uploadHandler = new UploadHandlerRaw(bodyRaw);
            request.downloadHandler = new DownloadHandlerBuffer();
            request.SetRequestHeader("Content-Type", "application/json");

            yield return request.SendWebRequest();

            if (request.result != UnityWebRequest.Result.Success)
                Debug.LogError("Error sending log: " + request.error);
            else
                Debug.Log("Log sent successfully.");
        }

        [System.Serializable]
        private class LogData
        {
            public string text;
        }
    } 
}
