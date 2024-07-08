using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts
{
    internal class PlayerSpawner
    {
        private readonly PlayerView _playerViewPrefab;
        private PlayerView _currentView;

        public event EventHandler<PlayerView> PlayerSpawned;

        public PlayerSpawner(PlayerView playerView)
        {
            _playerViewPrefab = playerView;
        }

        public void Spawn()
        {
            _currentView = GameObject.Instantiate(_playerViewPrefab);
            PlayerSpawned?.Invoke(this, _currentView);
        }
    }
}
