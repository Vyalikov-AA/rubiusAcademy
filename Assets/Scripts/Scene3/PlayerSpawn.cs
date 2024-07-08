using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpawn : MonoBehaviour
{
    private GameObject _gameObject;
    private static readonly System.Random random = new();
    private readonly System.Random rndPos = random;
    private readonly PlayerView _playerView;
    private readonly EnemyView _enemyMovements;

    private void Start()
    {
        _gameObject = gameObject;
    }
    public void Spawn()
    {
        _gameObject.transform.position = new Vector3(rndPos.Next(-50, 50), 4.0f, rndPos.Next(-50, 50));
        Instantiate(_gameObject, _gameObject.transform);
    }
}
