using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Scene2
{
    internal class SpawnCubes
    {
        private Transform _transform;
        private static readonly System.Random random = new();
        private readonly System.Random rndPos = random;
        public void Spawn(GameObject gameObject)
        {
            _transform = gameObject.transform;
            _transform.position = new Vector3(rndPos.Next(-25, 0), 2.0f, rndPos.Next(-25, 25));
            GameObject.Instantiate(gameObject, _transform);

        }
    }
}
