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
        private readonly PlayerView _playerView;
        public PlayerCoinsScore(PlayerView playerView)
        {
            _playerView = playerView;
            _playerView.CollisionHappaned += OnCollisionHappaned;
        }

        private void OnCollisionHappaned(object sender, (GameObject, string) e)
        {
            if (e.Item2 == "Coin")
            {
                _playerView._scriptableObject.NumberOfCoins++;
            }
        }

        public void Dispose()
        {
            _playerView.CollisionHappaned -= OnCollisionHappaned;
        }
    }
}
