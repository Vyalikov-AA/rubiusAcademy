using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts
{
    internal class ObjectSpawner
    {
        private GameObject _gameObject;
        private static readonly System.Random random = new();
        private readonly System.Random rndPos = random;
        public void Spawn(GameObject gameObject)
        {
            _gameObject = gameObject;
            _gameObject.transform.position = new Vector3(rndPos.Next(-50, 50), 4.0f, rndPos.Next(-50, 50));
            GameObject.Instantiate(_gameObject, _gameObject.transform);
        }
    }
}
