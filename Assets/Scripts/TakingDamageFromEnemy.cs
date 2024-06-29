using Unity.VisualScripting;
using UnityEngine;

namespace Assets.Scripts
{
    internal class TakingDamageFromEnemy
    {
        private readonly PlayerView _playerView;

        public TakingDamageFromEnemy(PlayerView playerView)
        {
            _playerView = playerView;
            _playerView.CollisionHappaned += OnCollisionHappaned;
            _playerView.CollisionStay += OnCollisionStay;
        }

        private void OnCollisionHappaned(object sender, (GameObject, string) e)
        {
            if (e.Item2 == "Enemy")
            {
                _playerView._scriptableObject.HealthPoints -= _playerView._scriptableObject.EnemyDamage;// * Time.deltaTime;
            }
        }
        private void OnCollisionStay(object sender, (GameObject, string) e)
        {
            if (e.Item2 == "Enemy")
            {
                _playerView._scriptableObject.HealthPoints -= _playerView._scriptableObject.EnemyDamage * Time.deltaTime;
            }
        }

        public void Dispose()
        {
            _playerView.CollisionHappaned -= OnCollisionHappaned;
            _playerView.CollisionStay -= OnCollisionStay;
        }
    }
}
