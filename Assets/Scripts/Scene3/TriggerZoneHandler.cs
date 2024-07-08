using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Scene3
{
    internal class TriggerZoneHandler
    {
        private TriggerZoneLava _triggerZone;
        private readonly PlayerDataScriptableObject _scriptableObjects;
        private readonly PlayerHealthHandlers _playerHealthHandler;
        private readonly PlayerSpawn _playerSpawn;

        public TriggerZoneHandler(  TriggerZoneLava triggerZone, 
                                    PlayerDataScriptableObject scriptableObjects, 
                                    PlayerHealthHandlers playerHealthHandler, 
                                    PlayerSpawn playerSpawn) 
        {
            _triggerZone = triggerZone;
            _scriptableObjects = scriptableObjects;
            _playerHealthHandler = playerHealthHandler;
            _playerSpawn = playerSpawn;
            _triggerZone.TriggerHappaned += OnTriggerHappaned;
            _playerHealthHandler.HealthChanger += OnPlayerHealthChanger;
            _playerHealthHandler.DeathEvent += OnPlayerDeathEvent;
        }

        private void OnTriggerHappaned(object sender, string e)
        {
            if (e == "Player")
            {
                _playerHealthHandler.ChangeCurrentHealth(_scriptableObjects.TriggerZoneDamage * Time.deltaTime);
                Debug.Log("Player on triger zone");
            }
        }
        private void OnPlayerHealthChanger(object sender, float e)
        {
            _scriptableObjects.PlayerHealthPoints = e;
        }
       private void OnPlayerDeathEvent(object sender, GameObject e)
        {
            GameObject.Destroy(e);
            _scriptableObjects.PlayerHealthPoints = 20;
            _playerSpawn.Spawn();
        }
    }
}
