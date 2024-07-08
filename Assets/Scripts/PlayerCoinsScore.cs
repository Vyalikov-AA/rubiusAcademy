using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts
{
    internal class PlayerCoinsScore : IDisposable
    {
        private PlayerView _playerView;
        private readonly PlayerParametrsHandler _playerHealthHandler;
        private readonly PlayerSpawner _playerSpawner;
        public PlayerCoinsScore(PlayerView playerView, PlayerParametrsHandler playerParametrsHandler, PlayerSpawner playerSpawner)
        {
            _playerView = playerView;
            _playerHealthHandler = playerParametrsHandler;
            _playerSpawner = playerSpawner;
            _playerView.CollisionHappaned += OnCollisionHappaned;
            _playerSpawner.PlayerSpawned += OnPlayerSpawned;
        }
        private void OnPlayerSpawned(object sender, PlayerView e)
        {
            _playerView = e;
            _playerView.CollisionHappaned += OnCollisionHappaned;
            _playerSpawner.PlayerSpawned += OnPlayerSpawned;
        }
        private void OnCollisionHappaned(object sender, (GameObject, string) e)
        {
            if (e.Item2 == "Coin")
            {
                _playerHealthHandler.CountOfCoins++;
            }
        }

        public void Dispose()
        {
            _playerView.CollisionHappaned -= OnCollisionHappaned;
        }
    }
}
