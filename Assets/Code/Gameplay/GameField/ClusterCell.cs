using System;
using UnityEngine;

namespace Code.Gameplay.GameField
{
    public class ClusterCell : MonoBehaviour, IClusterStorage
    {
        public bool IsEmpty => transform.childCount == 0;
        public Cluster Cluster => transform.childCount > 0 ? transform.GetChild(0).GetComponent<Cluster>() : null;
        
        public Transform SnapCluster(Cluster cluster)
        {
            if (!IsEmpty) return null;
            
            cluster.transform.SetParent(transform);
            return transform;
        }
    }
}