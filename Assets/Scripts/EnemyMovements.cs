using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts
{
    internal class EnemyMovements
    {
        private EnemyParametrsHandler _enemyHealthHandler;
        private PlayerView _playerView;
        private EnemyView _enemyView;
        public EnemyMovements()
        {
        }
        public void Move(PlayerView playerView, EnemyView enemyView, EnemyParametrsHandler enemyHealthHandler)
        {
            _playerView = playerView;
            _enemyView = enemyView;
            _enemyHealthHandler = enemyHealthHandler;
            Vector3 delta = _playerView.transform.position - _enemyView.transform.position;
            delta.Normalize();
            float moveSpeed = _enemyHealthHandler.SpeedEnemy * Time.deltaTime;
            _enemyView.transform.position += delta * moveSpeed;
        }

    }
}
