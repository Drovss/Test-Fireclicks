using TMPro;
using UnityEngine;

namespace Tabs.ListTab
{
    public class ListTabElement : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _text;

        public void SetText(string text)
        {
            _text.text = text;
        }
    }
}