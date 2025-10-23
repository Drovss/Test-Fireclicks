using UnityEngine;

namespace Tabs.AnimationTab
{
    public class UIAnimator : MonoBehaviour
    {
        [SerializeField] private RectTransform[] animatedRects;
        [SerializeField] private float moveRadius = 100f;
        [SerializeField] private float moveSpeed = 1.5f;
        [SerializeField] private float rotationSpeed = 90f;

        private Vector3[] _posCache;
        private Vector3[] _rotCache;

        private void Awake()
        {
            _posCache = new Vector3[animatedRects.Length];
            _rotCache = new Vector3[animatedRects.Length];
        }

        private void LateUpdate()
        {
            float t = Time.unscaledTime * moveSpeed;

            for (int i = 0; i < animatedRects.Length; i++)
            {
                float angle = t + i * 1.2f;
                var pos = _posCache[i];
                pos.x = Mathf.Sin(angle) * moveRadius;
                pos.y = Mathf.Cos(angle * 1.3f) * moveRadius;
                _posCache[i] = pos;

                var rot = _rotCache[i];
                rot.z += rotationSpeed * Time.unscaledDeltaTime;
                if (rot.z >= 360f) rot.z -= 360f;
                _rotCache[i] = rot;

                animatedRects[i].anchoredPosition = pos;
                animatedRects[i].localEulerAngles = rot;
            }
        }
    }
}