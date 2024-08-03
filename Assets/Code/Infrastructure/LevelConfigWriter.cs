using Code.Infrastructure.Configs;
using UnityEngine;

namespace Code.Infrastructure
{
    public class LevelConfigWriter : MonoBehaviour
    {
        [SerializeField] private LevelConfig _levelConfig;

        public void Write()
        {
            if (!IsMatchClustersToWords()) return;

            DataWriter.DataWriter.WriteToJson(_levelConfig);
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