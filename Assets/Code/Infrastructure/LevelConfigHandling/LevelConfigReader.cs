using Code.Infrastructure.Configs;
using Code.Infrastructure.DataHandling;
using UnityEngine;

namespace Code.Infrastructure.LevelConfigHandling
{
    public class LevelConfigReader
    {
        public LevelConfig Read()
        {
            LevelConfig levelConfig = DataReader.ReadFromJson<LevelConfig>(InfrastructureConstants.LevelConfigPath);
            return levelConfig;
        }
    }
}