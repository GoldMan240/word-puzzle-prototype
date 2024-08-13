using System.Collections.Generic;
using Code.Infrastructure.SceneLoading;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Code.Gameplay.UI
{
    public class WinWindow : WindowBase
    {
        [SerializeField] private TextMeshProUGUI _descriptionText;
        [SerializeField] private Button _mainMenuButton;
        
        private void Awake()
        {
            _mainMenuButton.onClick.AddListener(MoveToMainMenu);
        }

        private void OnDestroy()
        {
            _mainMenuButton.onClick.RemoveAllListeners();
        }

        public void Setup(List<string> words)
        {
            string description = "You have guessed all the words!\n\n";
            foreach (string word in words) 
                description += word + "\n";
            
            _descriptionText.text = description;
        }

        private void MoveToMainMenu() => 
            SceneLoader.LoadScene(Scene.MainMenu);
    }
}