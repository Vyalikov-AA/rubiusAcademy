using Assets.Scripts.Scene3;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AplicationLauncher : MonoBehaviour
{
    [SerializeField] private PlayerDataScriptableObject _scriptableObjects;
    [SerializeField] private TriggerZoneLava _triggerZone;
    [SerializeField] private PlayerHealthHandlers _playerHealthHandler;
    [SerializeField] private PlayerSpawn _playerSpawn;

    // Start is called before the first frame update
    void Start()
    {
        _playerHealthHandler.GetData(_scriptableObjects.PlayerHealthPoints, _scriptableObjects.PlayerHealthPointsMax);
        new Assets.Scripts.Scene3.TriggerZoneHandler(_triggerZone, _scriptableObjects, _playerHealthHandler, _playerSpawn);
    }
}
