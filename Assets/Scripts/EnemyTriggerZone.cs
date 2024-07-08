using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTriggerZone : MonoBehaviour
{
    //public event EventHandler<(GameObject, string)> TriggerStay;
    public void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Player enter triggers");            
        }
    }
}
