using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerZone : MonoBehaviour
{
    [SerializeField] private MeshRenderer _meshRenderer;
    public event EventHandler<(string, string)> TriggerHappaned;
    public event EventHandler<(string, string)> TriggerEnd;    
    public void OnTriggerEnter(Collider other)
    {
        TriggerHappaned?.Invoke(this, (other.transform.tag,this.transform.tag));
    }
    public void OnTriggerExit(Collider other)
    {
        TriggerEnd?.Invoke(this, (other.transform.tag, this.transform.tag));
    }
}
