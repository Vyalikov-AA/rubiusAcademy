using Assets.Scripts.Scene2;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ApLauncher : MonoBehaviour
{
    [SerializeField] private TriggerZone[] _triggerZone;
    [SerializeField] private CubesScriptableObjects _scriptableObjects;
    [SerializeField] private InputButtonHandlerScene2 _inputButtonHandler;
    
    private SpawnCubes _spawnCubes;
    private SpawnCubesHandler _spawnCubesHandler;
    private TriggerZoneHandler _triggerZoneHandler;
    private CubeCountHandler _countHandler;
    private ActionsWithScene2 _actionsWithScene2;
    private ActionsWithScene2Handler _actionsWithScene2Handler;
    private void Start()
    {
        _countHandler = new CubeCountHandler(_scriptableObjects);
        _spawnCubes = new SpawnCubes();
        _actionsWithScene2 = new ActionsWithScene2();
        _actionsWithScene2Handler = new ActionsWithScene2Handler(_inputButtonHandler, _actionsWithScene2, _countHandler);
        _triggerZoneHandler = new TriggerZoneHandler(_triggerZone, _countHandler);
        _spawnCubesHandler = new SpawnCubesHandler(_inputButtonHandler, _spawnCubes, _countHandler);
    }
}
