using Assets;
using Assets.Scripts;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Aplicationlauncher : MonoBehaviour
{
    private PlayerCollisionConsoleHandler _playerCollisionConsoleHandler;
    private CoinDestroyOnCollectHandler _coinDestroyOnCollectHandler;
    private PlayerCoinsScore _playerCoinsScore;
    private PlayerHealthParametrs _playerHealthParametrs;
    private TakingDamage _takingDamageFromEnemy;
    private EnemyMovementsHandler _enemyMovementsHandler;
    private PlayerSpawner _playerSpawner;
    private EnemySpawner _enemySpawner;
    private PlayerParametrsHandler _playerHealthHandler;
    private EnemyParametrsHandler _enemyHealthHandler;
    private EnemyMovements _EnemyMovements;
    private ObjectSpawner _objectSpawner;
    private ObjectSpawnerHandler _objectSpawnerHandler;
    private ActionsWithTheScene _actionsWithTheScene;
    private ActionsWithTheSceneHandler _actionsWithTheSceneHandler;
    private CameraMovements _cameraMovements;
    private CameraMovementsHandler _cameraMovementsHandler;
    private PlayerMovements _playerMovements;
    private PlayerMovementsHandler _playerMovementsHandler;
    private MaterialChanger _materialChanger;
    private MaterialChangerHandler _materialChangerHandler;

    [SerializeField] private PlayerDataScriptableObject _scriptableObject;
    [SerializeField] private PlayerView _player;
    [SerializeField] private PlayerView _playerPrefab;
    [SerializeField] private EnemyView _enemyView;
    [SerializeField] private EnemyView _enemyViewPrefab;
    [SerializeField] private GameObject _cameraGameObject;
    [SerializeField] private InputButtonHandler _inputButtonHandler;

    private void Start()
    {
        _actionsWithTheScene = new ActionsWithTheScene();
        _objectSpawner = new ObjectSpawner();
        _objectSpawnerHandler = new ObjectSpawnerHandler(_inputButtonHandler, _objectSpawner);
        _actionsWithTheSceneHandler = new ActionsWithTheSceneHandler(_inputButtonHandler, _actionsWithTheScene);
        _enemySpawner = new EnemySpawner(_enemyViewPrefab);
        _playerSpawner = new PlayerSpawner(_playerPrefab);
        _EnemyMovements = new EnemyMovements();
        _coinDestroyOnCollectHandler = new CoinDestroyOnCollectHandler(_player, _playerSpawner);
        _playerCoinsScore = new PlayerCoinsScore(_player, _playerHealthHandler, _playerSpawner);
        _playerHealthHandler = new PlayerParametrsHandler(_scriptableObject);//_scriptableObject.PlayerHealthPoints, _scriptableObject.PlayerHealthPointsMax, _scriptableObject.PlayerDamage, _scriptableObject.SpeedMovements, _scriptableObject.NumberOfCoins);
        _enemyHealthHandler = new EnemyParametrsHandler(_scriptableObject);//_scriptableObject.EnemyHealthPoints, _scriptableObject.EnemyDamage, _scriptableObject.SpeedMovementsEnemy);
        _takingDamageFromEnemy = new TakingDamage(_player, _enemyView, _playerHealthHandler, _enemyHealthHandler, _playerSpawner, _enemySpawner);
        _playerHealthParametrs = new PlayerHealthParametrs(_player, _playerHealthHandler, _playerSpawner);
        _enemyMovementsHandler = new EnemyMovementsHandler(_player, _enemyView, _playerSpawner, _enemySpawner, _enemyHealthHandler, _EnemyMovements);
        _playerCollisionConsoleHandler = new PlayerCollisionConsoleHandler(_player, _playerSpawner);
        _cameraMovements = new CameraMovements(_cameraGameObject);
        _cameraMovementsHandler = new CameraMovementsHandler(_player, _inputButtonHandler, _cameraMovements, _playerSpawner);
        _playerMovements = new PlayerMovements();
        _playerMovementsHandler = new PlayerMovementsHandler(_player, _playerHealthHandler, _playerSpawner, _playerMovements, _inputButtonHandler);
        _materialChanger = new MaterialChanger();
        _materialChangerHandler = new MaterialChangerHandler(_player, _enemyView, _playerSpawner, _enemySpawner, _materialChanger);
    }
    private void OnDestroy()
    {
        _playerCollisionConsoleHandler.Dispose();
        _coinDestroyOnCollectHandler.Dispose();
        _playerCoinsScore.Dispose();
        _playerHealthParametrs.Dispose();
        _playerHealthHandler.Dispose();
        _enemyHealthHandler.Dispose();
        _takingDamageFromEnemy.Dispose();
        _enemyMovementsHandler.Dispose();
    }
}
