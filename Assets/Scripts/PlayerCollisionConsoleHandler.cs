using System;
using System.Collections.Generic;
//using System.Diagnostics;
using UnityEngine;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts
{
    class PlayerCollisionConsoleHandler : IDisposable
    {
        private PlayerView _playerView;
        private readonly PlayerSpawner _playerSpawner;


        public PlayerCollisionConsoleHandler(PlayerView playerView, PlayerSpawner playerSpawner)
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
            Debug.Log($"Collision happaned with tag {e.Item1}");
        }

        public void Dispose()
        {
            _playerView.CollisionHappaned -= OnCollisionHappaned;
            _playerSpawner.PlayerSpawned -= OnPlayerSpawned;
        }
    }
}