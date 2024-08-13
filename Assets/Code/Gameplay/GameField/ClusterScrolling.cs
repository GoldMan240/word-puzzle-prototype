using UnityEngine;
using UnityEngine.UI;

namespace Code.Gameplay.GameField
{
    public class ClusterScrolling : MonoBehaviour, IClusterStorage
    {
        public bool IsEmpty => true;
        
        [SerializeField] private Transform _clusterStorage;
        [SerializeField] private HorizontalLayoutGroup _horizontalLayoutGroup;
        
        public Transform SnapCluster(Cluster cluster)
        {
            cluster.transform.SetParent(_clusterStorage);
            return cluster.transform;
        }
    }
}