using System;
using UnityEngine;

namespace Code.Gameplay.GameField
{
    public class ClusterCell : MonoBehaviour
    {
        public bool IsEmpty => transform.childCount == 0;
        public Cluster Cluster => transform.childCount > 0 ? transform.GetChild(0).GetComponent<Cluster>() : null;
    }
}