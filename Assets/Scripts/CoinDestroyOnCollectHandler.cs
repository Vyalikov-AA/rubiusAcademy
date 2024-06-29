using System;
using UnityEngine;

namespace Assets.Scripts
{
    class CoinDestroyOnCollectHandler : IDisposable
    {
        private readonly PlayerView _playerView;

        public CoinDestroyOnCollectHandler(PlayerView playerView)
        {
            _playerView = playerView;
            _playerView.CollisionHappaned += OnCollisionHappaned;
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
        }
    }
}
