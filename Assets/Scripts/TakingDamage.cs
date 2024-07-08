using System;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Assets.Scripts
{
    internal class TakingDamage: IDisposable
    {
        private PlayerView _playerView;
        private EnemyView _enemyView;
        private readonly PlayerParametrsHandler _playerHealthHandler;
        private readonly EnemyParametrsHandler _enemyHealthHandler;
        private readonly float _playerDamage;
        private readonly float _enemyDamage;
        private readonly EnemySpawner _enemySpawner;
        private readonly PlayerSpawner _playerSpawner;

        public TakingDamage(PlayerView playerView, 
                                     EnemyView enemyView, 
                                     PlayerParametrsHandler playerHealthHandler, 
                                     EnemyParametrsHandler enemyHealthHandler,
                                     PlayerSpawner playerSpawner,
                                     EnemySpawner enemySpawner)
        {
            _playerView = playerView;
            _enemyView = enemyView;
            _playerHealthHandler = playerHealthHandler;
            _enemyHealthHandler = enemyHealthHandler;
            _playerSpawner = playerSpawner;
            _enemySpawner = enemySpawner;
            _playerDamage = _playerHealthHandler.DamagePlayer;
            _enemyDamage = _enemyHealthHandler.DamageEnemy;
            _playerView.CollisionStay += OnCollisionStay;
            _enemyHealthHandler.HealthChanger += OnEnemyHealthChanger;
            _enemyHealthHandler.DeathEvent += OnEnemyDeathEvent;
            _playerSpawner.PlayerSpawned += OnPlayerSpawned;
            _enemySpawner.EnemySpawned += OnEnemySpawned;
        }

        private void OnPlayerSpawned(object sender, PlayerView e)
        {
            _playerView = e;
            _playerView.CollisionStay += OnCollisionStay;
            _playerSpawner.PlayerSpawned += OnPlayerSpawned;
        }

        private void OnEnemySpawned(object sender, EnemyView e)
        {
            _enemyView = e;
            _enemyHealthHandler.HealthChanger += OnEnemyHealthChanger;
            _enemyHealthHandler.DeathEvent += OnEnemyDeathEvent;
            _enemySpawner.EnemySpawned += OnEnemySpawned;
        }
        private void OnCollisionStay(object sender, (GameObject, string) e)
        {
            if (e.Item2 == "Enemy")
            {
                _playerHealthHandler.ChangeCurrentHealth(- _enemyDamage * Time.deltaTime, 0.0f);
                _enemyHealthHandler.ChangeCurrentHealth(- _playerDamage * Time.deltaTime);
            }
        }
        private void OnEnemyDeathEvent(object sender, EventArgs e)
        {
            GameObject.Destroy(_enemyView.gameObject);
            _enemyHealthHandler.CurentHealth = 10;
            _enemySpawner.Spawn();
        }
        private void OnEnemyHealthChanger(object sender, float e)
        {
            _enemyHealthHandler.CurentHealth = e;
        }
        public void Dispose()
        {
            _playerView.CollisionStay -= OnCollisionStay;
            _enemyHealthHandler.HealthChanger -= OnEnemyHealthChanger;
            _enemyHealthHandler.DeathEvent -= OnEnemyDeathEvent;
            _playerSpawner.PlayerSpawned -= OnPlayerSpawned;
            _enemySpawner.EnemySpawned -= OnEnemySpawned;
        }
    }
}
