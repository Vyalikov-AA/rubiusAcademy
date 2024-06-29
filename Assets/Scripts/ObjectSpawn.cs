using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UIElements;


internal class ObjectSpawn: MonoBehaviour
{
    private Vector3 _position;
    System.Random rndPos = new System.Random();
     public ObjectSpawn(GameObject _gameObject, Transform _transform)
    {
        Instantiate(_gameObject, _transform);
    }
}
