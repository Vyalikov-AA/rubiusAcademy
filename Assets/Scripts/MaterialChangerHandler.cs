using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts
{
    internal class MaterialChangerHandler: IDisposable
    {
        private PlayerView _playerView;
        private EnemyView _enemyView;
        private readonly PlayerSpawner _playerSpawner;
        private readonly EnemySpawner _enemySpawner;
        private readonly MaterialChanger _materialChanger;
        public MaterialChangerHandler(  PlayerView playerView, 
                                        EnemyView enemyView, 
                                        PlayerSpawner playerSpawner, 
                                        EnemySpawner enemySpawner,
                                        MaterialChanger materialChanger) 
        {
            _playerView = playerView;
            _enemyView = enemyView;
            _playerSpawner = playerSpawner;
            _enemySpawner = enemySpawner;
            _materialChanger = materialChanger;
            _materialChanger.ColorPlayer = _playerView.MeshRendererPlayer.material.color;
            _materialChanger.ColorEnemy = _enemyView.MeshRendererEnemy.material.color;
            _playerSpawner.PlayerSpawned += OnPlayerSpawned;
            _enemySpawner.EnemySpawned += OnEnemySpawned;
            _playerView.CollisionStay += OnCollisionStay;
            _playerView.CollisionExit += OnCollisionExit;
        }
        private void OnCollisionStay(object sender, (UnityEngine.GameObject, string) e)
        {
            if (e.Item2 == "Enemy")
            {
                _materialChanger.ChangeColor(_playerView.MeshRendererPlayer, _enemyView.EnemyMeshRenderer);                
            }
        }
        private void OnCollisionExit(object sender, (GameObject, string) e)
        {
            if (e.Item2 == "Enemy")
            {
                _materialChanger.BackColor(_playerView.MeshRendererPlayer, _enemyView.EnemyMeshRenderer);
            }
        }
        private void OnEnemySpawned(object sender, EnemyView e)
        {
            _enemyView = e;
            _materialChanger.BackColor(_playerView.MeshRendererPlayer, _enemyView.EnemyMeshRenderer);
            _enemySpawner.EnemySpawned += OnEnemySpawned;
        }
        private void OnPlayerSpawned(object sender, PlayerView e)
        {
            _playerView = e;
            _materialChanger.BackColor(_playerView.MeshRendererPlayer, _enemyView.EnemyMeshRenderer);
            _playerSpawner.PlayerSpawned += OnPlayerSpawned;
            _playerView.CollisionStay += OnCollisionStay;
            _playerView.CollisionExit += OnCollisionExit;
        }

        public void Dispose()
        {
            _playerSpawner.PlayerSpawned -= OnPlayerSpawned;
            _enemySpawner.EnemySpawned -= OnEnemySpawned;
            _playerView.CollisionStay -= OnCollisionStay;
            _playerView.CollisionExit -= OnCollisionExit;
        }
    }
}
