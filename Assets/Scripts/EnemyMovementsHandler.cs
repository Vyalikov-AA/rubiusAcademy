using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts
{
    internal class EnemyMovementsHandler : IDisposable
    {
        private PlayerView _playerView;
        private EnemyView _enemyView;
        private readonly EnemyMovements _enemyMovements;
        private readonly PlayerSpawner _playerSpawner;
        private readonly EnemySpawner _enemySpawner;
        private readonly EnemyParametrsHandler _enemyHealthHandler;

        public EnemyMovementsHandler(PlayerView playerView,
                                    EnemyView enemyView,
                                    PlayerSpawner playerSpawner,
                                    EnemySpawner enemySpawner,
                                    EnemyParametrsHandler enemyHealthHandler,
                                    EnemyMovements enemyMovements)
        {
            _playerView = playerView;
            _enemyView = enemyView;
            _playerSpawner = playerSpawner;
            _enemySpawner = enemySpawner;
            _enemyHealthHandler = enemyHealthHandler;
            _enemyMovements = enemyMovements;
            _enemyView.TriggerStay += OnTriggerStay;
            _enemySpawner.EnemySpawned += OnEnemySpawned;
            _playerSpawner.PlayerSpawned += OnPlayerSpawned;
        }

        private void OnEnemySpawned(object sender, EnemyView e)
        {
            _enemyView = e;
            _enemySpawner.EnemySpawned += OnEnemySpawned;
            _enemyView.TriggerStay += OnTriggerStay;
        }

        private void OnPlayerSpawned(object sender, PlayerView e)
        {
            _playerView = e;
            _playerSpawner.PlayerSpawned += OnPlayerSpawned;
        }

        private void OnTriggerStay(object sender, (GameObject, string) e)
        {
            if (e.Item2 == "Player")
            {
                _enemyMovements.Move(_playerView, _enemyView, _enemyHealthHandler);
                Debug.Log("Player enter triggers");
            }
        }

        public void Dispose()
        {
            _enemyView.TriggerStay -= OnTriggerStay;
            _playerSpawner.PlayerSpawned -= OnPlayerSpawned;
            _playerSpawner.PlayerSpawned -= OnPlayerSpawned;
        }
    }
}
