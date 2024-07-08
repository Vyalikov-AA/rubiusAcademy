using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "CountOfCube", menuName = "ScriptableObjects/CountOfCube", order = 2)]
public class CubesScriptableObjects : ScriptableObject
{
    public int CountOfCubeRed;
    public int CountOfCubeBlue;
    public int CountOfCubeInRedZone;
    public int CountOfCubeInBlueZone;
}
