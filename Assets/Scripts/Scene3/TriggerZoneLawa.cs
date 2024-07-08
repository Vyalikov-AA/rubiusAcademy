using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerZoneLava : MonoBehaviour
{
    public event EventHandler<string> TriggerHappaned;
    public event EventHandler<string> TriggerEnd;

    public void OnTriggerStay(Collider other)
    {
        TriggerHappaned?.Invoke(this, other.transform.tag);
    }
    public void OnTriggerExit(Collider other)
    {
        TriggerEnd?.Invoke(this, other.transform.tag);
    }
}
