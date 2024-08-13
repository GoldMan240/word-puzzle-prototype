using UnityEngine;

namespace Code.Gameplay.GameField
{
    public interface IClusterStorage
    {
        Transform SnapCluster(Cluster cluster);
        bool IsEmpty { get; }
    }
}