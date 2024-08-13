using UnityEngine;
using UnityEngine.UI;

namespace Code.Gameplay.UI
{
    public class SettingsWindow : WindowBase
    {
        [SerializeField] private Toggle _soundToggle;
        [SerializeField] private Button _closeButton;
        
        private void Awake()
        {
            _soundToggle.onValueChanged.AddListener(ToggleSound);
            _closeButton.onClick.AddListener(Close);
        }
        
        private void OnDestroy()
        {
            _soundToggle.onValueChanged.RemoveAllListeners();
            _closeButton.onClick.RemoveAllListeners();
        }
        
        private void ToggleSound(bool isOn) => 
            Debug.Log($"Sound is {(isOn ? "enabled" : "disabled")}");
    }
}