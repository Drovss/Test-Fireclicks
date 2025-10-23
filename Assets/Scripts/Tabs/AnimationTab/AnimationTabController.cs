using UnityEngine;

namespace Tabs.AnimationTab
{
    public class AnimationTabController : ATabController
    {
        [SerializeField] private Transform _rootTransform;
        [SerializeField] private Canvas _targetCanvas;        
        [SerializeField] private StaticImage _prefab;
        [SerializeField] private int _countStaticImages = 100;
        
        private bool _isInit;
        
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

            GenerateStaticImages();
            
            _isInit = true;
        }

        private void GenerateStaticImages()
        {
            RectTransform canvasRect = _targetCanvas.GetComponent<RectTransform>();
            float halfW = canvasRect.rect.width / 2f;
            float halfH = canvasRect.rect.height / 2f;
            
            for (int i = 0; i < _countStaticImages; i++)
            {
                StaticImage spawned = Instantiate(_prefab, _targetCanvas.transform, false);
                
                Vector2 randomPos = new Vector2(
                    Random.Range(-halfW, halfW),
                    Random.Range(-halfH, halfH)
                );

                Color randomColor = new Color(Random.value, Random.value, Random.value, 1f);

                spawned.Initialize(randomPos, randomColor);
            }
            
        }

        public override void DeactiveTab()
        {
            _rootTransform.gameObject.SetActive(false);
            IsActive = false;
        }
    }
}