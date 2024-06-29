using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerView : MonoBehaviour
{
    [SerializeField] private GameObject _gameObject;
    public PlayerDataScriptableObject _scriptableObject;
    public event EventHandler<(GameObject, string)> CollisionHappaned;
    public event EventHandler<(GameObject, string)> CollisionStay;

    private void OnCollisionEnter(Collision collision)
    {
        CollisionHappaned?.Invoke(this, (collision.gameObject, collision.transform.tag));
    }
    private void OnCollisionStay(Collision collision)
    {
        CollisionStay?.Invoke(this, (collision.gameObject, collision.transform.tag));
    }
    private void Update()
    {
        if (_scriptableObject.HealthPoints <= 0)
        {
            Destroy(_gameObject);
            _scriptableObject.HealthPoints = 10;
            Instantiate(_gameObject);
        }
    }
}

