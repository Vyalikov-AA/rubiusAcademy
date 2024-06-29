using Assets.Scripts;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Aplicationlauncher : MonoBehaviour
{
    private PlayerCollisionConsoleHandler _playerCollisionConsoleHandler;
    private CoinDestroyOnCollectHandler _coinDestroyOnCollectHandler;
    private PlayerCoinsScore _playerCoinsScore;
    private PlayerHealthParametrs _playerHealthParametrs;
    private TakingDamageFromEnemy _takingDamageFromEnemy;
    private GetPosForObjectSpawn _getPosForObjectSpawn;

    [SerializeField] private PlayerDataScriptableObject _scriptableObject;
    [SerializeField] private PlayerView _player;
    [SerializeField] private GameObject _gameObject;

    

    private void Start()
    {
        _playerCollisionConsoleHandler = new PlayerCollisionConsoleHandler(_player);
        _coinDestroyOnCollectHandler = new CoinDestroyOnCollectHandler(_player);
        _playerCoinsScore = new PlayerCoinsScore(_player);
        _playerHealthParametrs = new PlayerHealthParametrs(_player);
        _takingDamageFromEnemy = new TakingDamageFromEnemy(_player);
        _getPosForObjectSpawn = new GetPosForObjectSpawn();
    }
    private void OnDestroy()
    {
        _playerCollisionConsoleHandler.Dispose();
        _coinDestroyOnCollectHandler.Dispose();
        _playerCoinsScore.Dispose();
        _playerHealthParametrs.Dispose();
        _takingDamageFromEnemy.Dispose();
    }
}
