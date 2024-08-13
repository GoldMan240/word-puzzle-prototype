using System.Collections.Generic;
using System.Linq;
using Code.Extensions;
using Code.Gameplay.Factory;
using Code.Gameplay.GameField;
using Code.Infrastructure.Configs;
using Code.Infrastructure.LevelConfigHandling;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Code.Gameplay
{
    public class GameController : MonoBehaviour
    {
        [SerializeField] private Transform _wordRoot;
        [SerializeField] private Transform _clusterRoot;
        [SerializeField] private Button _checkWordsButton;
        
        private IGameFactory _gameFactory;
        private LevelConfigReader _levelConfigReader;
        private LevelConfig _levelConfig;
        private readonly List<string> _words = new();
        private readonly List<ClusterWord> _clusterWords = new();

        [Inject]
        private void Construct(IGameFactory gameFactory, LevelConfigReader levelConfigReader)
        {
            _gameFactory = gameFactory;
            _levelConfigReader = levelConfigReader;
        }

        private void Awake()
        {
            _levelConfig = _levelConfigReader.Read();

            foreach (WordConfig wordConfig in _levelConfig.WordConfigs) 
                _words.Add(wordConfig.Word);
            
            _checkWordsButton.onClick.AddListener(CheckIfAllWordsGuessed);
        }

        private void Start()
        {
            CreateClusters();
            CreateClusterWords();
        }

        private void CreateClusters()
        {
            List<WordConfig> wordConfigs = _levelConfig.WordConfigs;
            wordConfigs.Shuffle();

            foreach (string[] wordClusters in wordConfigs.Select(wordConfig => wordConfig.WordClusters))
            {
                wordClusters.Shuffle();
                
                foreach (string cluster in wordClusters) 
                    _gameFactory.CreateCluster(cluster, _clusterRoot);
            }
        }

        private void CreateClusterWords()
        {
            List<WordConfig> wordConfigs = _levelConfig.WordConfigs;
            wordConfigs.Shuffle();

            foreach (ClusterWord clusterWord in wordConfigs.Select(
                         wordConfig => _gameFactory.CreateClusterWord(wordConfig.WordClusters.Length, _wordRoot, this)))
            {
                _clusterWords.Add(clusterWord);
            }
        }

        private void CheckIfAllWordsGuessed()
        {
            List<string> words = _words;
            
            foreach (ClusterWord clusterWord in _clusterWords)
            {
                if (clusterWord.TryToMakeWord(out string word) && words.Contains(word))
                {
                    words.Remove(word);
                    continue;
                }
                Debug.Log("Not all words are guessed");
                return;
            }
            
            Debug.Log("All words are guessed");
        }
    }
}