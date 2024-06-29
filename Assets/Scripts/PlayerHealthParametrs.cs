using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts
{
    class PlayerHealthParametrs: IDisposable
    {
        private readonly PlayerView _playerView;

        public PlayerHealthParametrs(PlayerView playerView)
        {
            _playerView = playerView;
            _playerView.CollisionHappaned += OnCollisionHappaned;

        }

        private void OnCollisionHappaned(object sender, (GameObject, string) e)
        {
            if (e.Item2 == "IncreaseHealth")
            {
                _playerView._scriptableObject.HealthPointsMax++;
                GameObject.Destroy(e.Item1);
            }
            if (e.Item2 == "DecreaseHealth" && _playerView._scriptableObject.HealthPointsMax > 1)
            {
                _playerView._scriptableObject.HealthPointsMax--;
                GameObject.Destroy(e.Item1);
            }
            if (e.Item2 == "HealthUp" && _playerView._scriptableObject.HealthPointsMax > _playerView._scriptableObject.HealthPoints)
            {
                _playerView._scriptableObject.HealthPoints++;
                GameObject.Destroy(e.Item1);
            }
            if (e.Item2 == "HealthDown")
            {
                _playerView._scriptableObject.HealthPoints--;
                GameObject.Destroy(e.Item1);
            }

        }
        public void Dispose()
        {
            _playerView.CollisionHappaned -= OnCollisionHappaned;
        }

    }
}
