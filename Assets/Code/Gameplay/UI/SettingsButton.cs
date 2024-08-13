using UnityEngine;
using UnityEngine.UI;

namespace Code.Gameplay.UI
{
    [RequireComponent(typeof(Button))]
    public class SettingsButton : MonoBehaviour
    {
        [SerializeField] private SettingsWindow _settingsWindow;
        
        private Button _button;

        private void Awake()
        {
            _button = GetComponent<Button>();
            _button.onClick.AddListener(OnButtonClick);
        }

        private void OnDestroy()
        {
            _button.onClick.RemoveAllListeners();
        }

        private void OnButtonClick()
        {
            _settingsWindow.Open();
        }
    }
}