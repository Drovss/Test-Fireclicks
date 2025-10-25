using TMPro;
using UnityEngine;
using UnityEngine.Networking;
using System.IO;

namespace Tabs.RequestTab
{
    public class RequestTabController : ATabController
    {
        [SerializeField] private Transform _rootTransform;
        [SerializeField] private TextMeshProUGUI _text;

        private bool _isInit;
        private string _requestUrl;

        public override bool IsActive { get; protected set; }

        public override void ActiveTab()
        {
            IsActive = true;
            Init();
            _rootTransform.gameObject.SetActive(true);
        }

        private void Init()
        {
            if (_isInit)
                return;

            LoadConfig();

            if (string.IsNullOrEmpty(_requestUrl))
            {
                _text.text = "URL not found in config!";
                return;
            }

            SendRequest();

            _isInit = true;
        }

        private void LoadConfig()
        {
            string path = Path.Combine(Application.streamingAssetsPath, "config.json");

#if UNITY_WEBGL && !UNITY_EDITOR
        var request = UnityWebRequest.Get(path);
        request.SendWebRequest().completed += _ =>
        {
            if (request.result == UnityWebRequest.Result.Success)
            {
                ConfigData config = JsonUtility.FromJson<ConfigData>(request.downloadHandler.text);
                _requestUrl = config.requestUrl;
                SendRequest();
            }
            else
            {
                _text.text = "Failed to load config.json!";
            }
        };
#else
            if (File.Exists(path))
            {
                string json = File.ReadAllText(path);
                ConfigData config = JsonUtility.FromJson<ConfigData>(json);
                _requestUrl = config.requestUrl;
            }
            else
            {
                _text.text = "config.json not found!";
            }
#endif
        }

        private void SendRequest()
        {
            UnityWebRequest req = UnityWebRequest.Get(_requestUrl);
            var asyncOp = req.SendWebRequest();

            asyncOp.completed += _ =>
            {
                if (req.result == UnityWebRequest.Result.Success)
                {
                    _text.text = req.downloadHandler.text;
                }
                else
                {
                    _text.text = $"Error: {req.error}";
                }

                req.Dispose();
            };
        }

        public override void DeactiveTab()
        {
            _rootTransform.gameObject.SetActive(false);
            IsActive = false;
        }
    }
}