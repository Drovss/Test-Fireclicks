using TMPro;
using UnityEngine;

namespace Tabs.TimeTab
{
    public class TimeTabController : ATabController
    {
        [SerializeField] private Transform _rootTransform;
        [SerializeField] private TextMeshProUGUI _text;

        private bool _isInit;
        private readonly char[] _chars = new char[12];

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

            _chars[2] = ':';
            _chars[5] = ':';
            _chars[8] = '.';

            _isInit = true;
        }

        private void Update()
        {
            if (!IsActive)
                return;

            var now = System.DateTime.Now;
            WriteTwoDigits(now.Hour, 0);
            WriteTwoDigits(now.Minute, 3);
            WriteTwoDigits(now.Second, 6);
            WriteThreeDigits(now.Millisecond, 9);

            _text.SetCharArray(_chars, 0, _chars.Length);
        }

        private void WriteTwoDigits(int value, int index)
        {
            int tens = value / 10;
            int ones = value - tens * 10;
            _chars[index] = (char)('0' + tens);
            _chars[index + 1] = (char)('0' + ones);
        }

        private void WriteThreeDigits(int value, int index)
        {
            int hundreds = value / 100;
            int tens = (value / 10) - hundreds * 10;
            int ones = value - (value / 10) * 10;
            _chars[index] = (char)('0' + hundreds);
            _chars[index + 1] = (char)('0' + tens);
            _chars[index + 2] = (char)('0' + ones);
        }

        public override void DeactiveTab()
        {
            _rootTransform.gameObject.SetActive(false);
            IsActive = false;
        }
    }
}