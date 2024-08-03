using Code.Infrastructure.Configs;
using Code.Infrastructure.DataHandling;
using UnityEngine;

namespace Code.Infrastructure.LevelConfigHandling
{
    public class LevelConfigWriter : MonoBehaviour
    {
        [SerializeField] private LevelConfig _levelConfig;

        public void Write()
        {
            if (!IsMatchClustersToWords()) return;

            DataWriter.WriteToJson(_levelConfig, InfrastructureConstants.LevelConfigPath);
        }

        private bool IsMatchClustersToWords()
        {
            foreach (WordConfig wordConfig in _levelConfig.WordConfigs)
            {
                string word = wordConfig.Word;
                string[] wordClusters = wordConfig.WordClusters;
                string wordClustersString = string.Join("", wordClusters);

                if (!word.Equals(wordClustersString))
                {
                    Debug.LogError($"Word '{word}' is not equal to word clusters '{wordClustersString}'");
                    return false;
                }
            }

            return true;
        }
    }
}