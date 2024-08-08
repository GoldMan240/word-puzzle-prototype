using Code.Gameplay.AssetManagment;
using Code.Gameplay.GameField;
using UnityEngine;

namespace Code.Gameplay.Factory
{
    public class GameFactory : IGameFactory
    {
        private readonly IAssetProvider _assetProvider;

        public GameFactory(IAssetProvider assetProvider)
        {
            _assetProvider = assetProvider;
        }
        
        public Cluster CreateCluster(string letters, Transform parent)
        {
            Cluster clusterAsset = _assetProvider.LoadAsset<Cluster>(AssetPath.ClusterPath);
            clusterAsset.Setup(letters);
            return Object.Instantiate(clusterAsset, parent);
        }
        
        public ClusterWord CreateClusterWord(int length, Transform parent, GameController gameController)
        {
            ClusterWord clusterWordAsset = _assetProvider.LoadAsset<ClusterWord>(AssetPath.ClusterWordPath);
            
            ClusterWord clusterWord = Object.Instantiate(clusterWordAsset, parent);
            clusterWord.Setup(length, this);
            return clusterWord;
        }
        
        public ClusterCell CreateClusterCell(Transform parent)
        {
            ClusterCell clusterCellAsset = _assetProvider.LoadAsset<ClusterCell>(AssetPath.ClusterCellPath);
            return Object.Instantiate(clusterCellAsset, parent);
        }
    }
}