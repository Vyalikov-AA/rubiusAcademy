using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UIElements;

public class PlayerMovements : MonoBehaviour
{
    [SerializeField] private PlayerDataScriptableObject scriptableObject;
    [SerializeField] private Transform TransformObject;
    [SerializeField] private string ButonForward, ButonBack, ButonLeft, ButonRight;

    private void Start()
    {
        /*TransformObject = transform;
        ButonForward = "w";
        ButonBack = "s";
        ButonLeft = "d";
        ButonRight = "a";*/
    }

    public void Update()
    {
        if (Input.GetKey(ButonForward))
        {
            Move(Vector3.forward);
        }
        if (Input.GetKey(ButonBack))
        {
            Move(Vector3.back);
        }
        if (Input.GetKey(ButonLeft))
        {
            Rotate(Vector3.down);
        }
        if (Input.GetKey(ButonRight))
        {
            Rotate(Vector3.up); ;
        }
    }
    private void Move(Vector3 _vector)
    {
        TransformObject.Translate(_vector * scriptableObject.SpeedMovements);
    }

    private void Rotate(Vector3 _vector)
    {
        TransformObject.Rotate(_vector * scriptableObject.SpeedRotations);
    }
}
