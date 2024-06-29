using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMPro;
using UnityEngine;

namespace Assets.Scripts
{
    internal class GetPosForObjectSpawn: MonoBehaviour
    {
        [SerializeField] private GameObject _enemyGameObject;
        [SerializeField] private GameObject _coinGameObject;
        [SerializeField] private GameObject _healthUpGameObject;
        [SerializeField] private GameObject _healthDownGameObject;
        [SerializeField] private Transform _enemyGameObjectTransform;
        [SerializeField] private Transform _coinGameObjectTransform;
        [SerializeField] private Transform _healthUpGameObjectTransform;
        [SerializeField] private Transform _healthDownGameObjectTransform;
        
        private Transform _objectTransform;

        System.Random rndPos = new System.Random();
        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Alpha1))
            {
                _objectTransform = _enemyGameObjectTransform;
                _objectTransform.position = new Vector3(rndPos.Next(-50, 50), 4.0f, rndPos.Next(-50, 50));
                new ObjectSpawn(_enemyGameObject, _objectTransform);
                Debug.Log("Spawn Enemy object");
            }
            if (Input.GetKeyDown(KeyCode.Alpha2))
            {
                _objectTransform = _coinGameObjectTransform;
                _objectTransform.position = new Vector3(rndPos.Next(-50,50), 4.0f, rndPos.Next(-50, 50));
                new ObjectSpawn(_coinGameObject, _objectTransform);
                Debug.Log("Spawn Coin object");
            }
            if (Input.GetKeyDown(KeyCode.Alpha3))
            {
                _objectTransform = _healthUpGameObjectTransform;
                _objectTransform.position = new Vector3(rndPos.Next(-50, 50), 4.0f, rndPos.Next(-50, 50));
                new ObjectSpawn(_coinGameObject, _objectTransform);
                Debug.Log("Spawn healthUp object");
            }
            if (Input.GetKeyDown(KeyCode.Alpha4))
            {
                _objectTransform = _healthDownGameObjectTransform;
                _objectTransform.position = new Vector3(rndPos.Next(-50, 50), 4.0f, rndPos.Next(-50, 50));
                new ObjectSpawn(_coinGameObject, _objectTransform);
                Debug.Log("Spawn healthDown object");
            }
        }

    }
}
