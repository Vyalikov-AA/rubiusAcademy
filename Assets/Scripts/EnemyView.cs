using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyView : MonoBehaviour
{
    [SerializeField] private GameObject _gameObject;
    [SerializeField] private MeshRenderer _meshRenderer;
    public MeshRenderer MeshRendererEnemy => _meshRenderer;

    public event EventHandler<(GameObject, string)> TriggerStay;

    public GameObject EnemyGameObject => _gameObject;
    public MeshRenderer EnemyMeshRenderer => _meshRenderer;

    private void OnTriggerStay(Collider other)
    {
        TriggerStay?.Invoke(this, (other.gameObject, other.transform.tag));
    }
}