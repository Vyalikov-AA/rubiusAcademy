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
        private readonly PlayerView _playerView;


        public PlayerCollisionConsoleHandler(PlayerView playerView)
        {
            _playerView = playerView;
            _playerView.CollisionHappaned += OnCollisionHappaned;
        }

        private void OnCollisionHappaned(object sender, (GameObject, string) e)
        {
            Debug.Log($"Collision happaned with tag {e.Item1}");
        }

        public void Dispose()
        {
            _playerView.CollisionHappaned -= OnCollisionHappaned;
        }
    }
}