using UnityEngine;
using UnityEngine.UI;

namespace Tabs.AnimationTab
{
    public class StaticImage : MonoBehaviour
    {
        [SerializeField] private RectTransform _rectTransform;
        [SerializeField] private Image _image;

        public void Initialize(Vector2 position, Color color)
        {
            _rectTransform.anchoredPosition = position;
            _image.color = color;
        }
    }
}