using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts
{
    internal class EnemySpawner
    {
        private readonly EnemyView _enemyViewPrefab;
        private EnemyView _currentView;
        public event EventHandler<EnemyView> EnemySpawned;
        //public EnemySpawner EnemySpawnerLink => EnemySpawner EnemySpawnerLink;

        public EnemySpawner(EnemyView enemyView)
        {
            _enemyViewPrefab = enemyView;
        }

        public void Spawn()
        {
            _currentView = GameObject.Instantiate(_enemyViewPrefab);
            EnemySpawned?.Invoke(this, _currentView);
        }
    }
}
