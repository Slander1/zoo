using TMPro;
using UnityEngine;

namespace Game.UI.UpPanel
{
    public abstract class CountView : MonoBehaviour
    {
        [SerializeField] private TMP_Text countText;

        private string _defaultText;
        private void Awake()
        {
            _defaultText = countText.text;
            UpdateCount(0);
        }

        public void UpdateCount(int count)
        {
            countText.text = _defaultText + " " +count;
        }
    }
}