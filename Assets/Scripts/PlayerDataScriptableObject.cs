using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "DataPlayer", menuName = "ScriptableObjects/DataPlayer", order = 1)]
public class PlayerDataScriptableObject : ScriptableObject
{
    public int NumberOfCoins;
    public float SpeedMovements;
    public float SpeedRotations;
    public float PlayerHealthPoints;
    public float PlayerHealthPointsMax;
    public float PlayerDamage;
    public float SpeedMovementsEnemy;
    public float EnemyDamage;
    public float EnemyHealthPoints;
    public float ColorChangeTime;
    public float TriggerZoneDamage;
}
