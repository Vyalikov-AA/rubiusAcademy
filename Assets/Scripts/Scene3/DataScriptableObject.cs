using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "DataScene", menuName = "ScriptableObjects/DataScene", order = 3)]
public class DataScriptableObject : ScriptableObject
{
    public float SpeedMovements;
    public float SpeedRotations;
    public float PlayerHealthPoints;
    public float PlayerHealthPointsMax;
    public float TriggerZoneDamage;
}
