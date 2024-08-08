using System;
using System.Collections.Generic;
using Code.Gameplay.Factory;
using UnityEngine;

namespace Code.Gameplay.GameField
{
    public class ClusterWord : MonoBehaviour
    {
        private readonly List<ClusterCell> _clusterCells = new();
        private GameFactory _gameFactory;

        public void Setup(int length, GameFactory gameFactory)
        {
            _gameFactory = gameFactory;

            AddClusterCells(length);
        }

        public bool TryToMakeWord(out string word)
        {
            word = string.Empty;

            foreach (ClusterCell clusterCell in _clusterCells)
            {
                if (clusterCell.IsEmpty)
                    return false;

                word += clusterCell.Cluster.Letters;
                Debug.Log(clusterCell.Cluster.Letters);
                Debug.Log(word);

            }
            Debug.Log(word);
            
            return true;
        }

        private void AddClusterCells(int amount)
        {
            for (int i = 0; i < amount; i++)
            {
                ClusterCell clusterCell = _gameFactory.CreateClusterCell(transform);
                _clusterCells.Add(clusterCell);
            }
        }
    }
}