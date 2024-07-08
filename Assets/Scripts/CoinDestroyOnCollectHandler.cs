using System;
using UnityEngine;

namespace Assets.Scripts
{
    class CoinDestroyOnCollectHandler : IDisposable
    {
        private PlayerView _playerView;
        private readonly PlayerSpawner _playerSpawner;

        public CoinDestroyOnCollectHandler(PlayerView playerView, PlayerSpawner playerSpawner)
        {
            _playerView = playerView;
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
            if(e.Item2 == "Coin")
            {
                GameObject.Destroy(e.Item1);
            }
        }

        public void Dispose()
        {
            _playerView.CollisionHappaned -= OnCollisionHappaned;
            _playerSpawner.PlayerSpawned -= OnPlayerSpawned;
        }
    }
}
