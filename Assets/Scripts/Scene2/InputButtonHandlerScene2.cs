using Assets.Scripts.Scene2;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.SceneManagement;
using UnityEngine;
using UnityEngine.SceneManagement;
using static UnityEditor.Experimental.GraphView.GraphView;

public class InputButtonHandlerScene2 : MonoBehaviour
{
    [SerializeField] private GameObject _prefabRedCube;
    [SerializeField] private GameObject _prefabBlueCube;
    public GameObject GameObjectRedCube => _prefabRedCube;
    public GameObject GameObjectBlueCube => _prefabBlueCube;
    public event EventHandler<ButtonPress> ButtonPressed;
    public enum ButtonPress
    {
        ButonRedCube,
        ButonBlueCube,
        ButtonRestartLvl,
        ButtonLoadNextLvl
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            ButtonPressed?.Invoke(this, ButtonPress.ButonRedCube);
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            ButtonPressed?.Invoke(this, ButtonPress.ButonBlueCube);
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            ButtonPressed?.Invoke(this, ButtonPress.ButtonRestartLvl);
        }
        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            ButtonPressed?.Invoke(this, ButtonPress.ButtonLoadNextLvl);
        }
    }
}
