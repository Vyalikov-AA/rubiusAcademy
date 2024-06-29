using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyMovements : MonoBehaviour
{
    [SerializeField] private PlayerDataScriptableObject scriptableObject;
    [SerializeField] private Transform _transformPlayer;
    [SerializeField] private Transform _transformEnemy;

    // Update is called once per frame
    void Update()
    {
        if (_transformPlayer)
        {
            Vector3 delta = _transformPlayer.position - _transformEnemy.position;
            delta.Normalize();
            float moveSpeed = scriptableObject.SpeedMovementsEnemy * Time.deltaTime;
            transform.position = transform.position + (delta * moveSpeed);
        }
    }
}
