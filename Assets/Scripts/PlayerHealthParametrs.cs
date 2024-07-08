using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Assets.Scripts
{
    class PlayerHealthParametrs: IDisposable
    {
        private PlayerView _playerView;
        private readonly PlayerParametrsHandler _playerHealthHandler;
        private readonly PlayerSpawner _playerSpawner;

        public PlayerHealthParametrs(PlayerView playerView, 
                                    PlayerParametrsHandler playerHealthHandler,
                                    PlayerSpawner playerSpawner)
        {
            _playerView = playerView; 
            _playerHealthHandler = playerHealthHandler;
            _playerSpawner = playerSpawner;
            _playerView.CollisionHappaned += OnCollisionHappaned;
            _playerHealthHandler.HealthChanger += OnHealthChanger;
            _playerHealthHandler.DeathEvent += OnDeathEvent;
            _playerSpawner.PlayerSpawned += OnPlayerSpawned;
        }
        private void OnPlayerSpawned(object sender, PlayerView e)
        {
            _playerView = e;
            _playerView.CollisionHappaned += OnCollisionHappaned;
        }
        private void OnDeathEvent(object sender, EventArgs e)
        {
            GameObject.Destroy(_playerView.gameObject);
            _playerHealthHandler.CurentHealth = 20;
            _playerSpawner.Spawn();
        }

        private void OnHealthChanger(object sender, (float, float) e)
        {
            if (e.Item2 == 0.0f)
            {
                _playerHealthHandler.CurentHealth = e.Item1;
            }
            if (e.Item2 != 0.0f)
            {
                _playerHealthHandler.MaxHealth += e.Item2;
            }
            
        }

        private void OnCollisionHappaned(object sender, (GameObject, string) e)
        {
            if (e.Item2 == "IncreaseHealth")
            {
                _playerHealthHandler.ChangeCurrentHealth(1.0f, 0.0f);
                GameObject.Destroy(e.Item1);
            }
            if (e.Item2 == "DecreaseHealth")
            {
                _playerHealthHandler.ChangeCurrentHealth(-1.0f, 0.0f);
                GameObject.Destroy(e.Item1);
            }
            if (e.Item2 == "HealthUp")
            {
                _playerHealthHandler.ChangeCurrentHealth(0.0f, 1.0f);
                GameObject.Destroy(e.Item1);
            }
            if (e.Item2 == "HealthDown")
            {
                _playerHealthHandler.ChangeCurrentHealth(0.0f, -1.0f);
                GameObject.Destroy(e.Item1);
            }

        }
        public void Dispose()
        {
            _playerView.CollisionHappaned -= OnCollisionHappaned;
            _playerHealthHandler.HealthChanger -= OnHealthChanger;
            _playerHealthHandler.DeathEvent -= OnDeathEvent;
        }
    }

}
