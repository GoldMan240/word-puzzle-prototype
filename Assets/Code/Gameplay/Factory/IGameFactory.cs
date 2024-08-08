using Code.Gameplay.GameField;
using UnityEngine;

namespace Code.Gameplay.Factory
{
    public interface IGameFactory
    {
        ClusterWord CreateClusterWord(int length, Transform parent, GameController gameController);
        ClusterCell CreateClusterCell(Transform parent);
        Cluster CreateCluster(string letters, Transform parent);
    }
}