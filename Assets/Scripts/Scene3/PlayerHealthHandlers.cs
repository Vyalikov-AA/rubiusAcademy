using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealthHandlers : MonoBehaviour
{
    private float _currentHealth;
    private float _maxHealth;
    private GameObject _gameObject;

    public event EventHandler<GameObject> DeathEvent;
    public event EventHandler<float> HealthChanger;

    public float CurentHealth => _currentHealth;

    public PlayerHealthHandlers(float curentHealth, float maxHealth)
    {
        _currentHealth = curentHealth;
        _maxHealth = maxHealth;
    }
    public void GetData(float curentHealth, float maxHealth)
    {
        _currentHealth = curentHealth;
        _maxHealth = maxHealth;
    }
    public void ChangeCurrentHealth(float delta)
    {
        _currentHealth = Mathf.Clamp(_currentHealth - delta, 0.0f, _maxHealth);
        HealthChanger?.Invoke(this, _currentHealth);
        if (_currentHealth <= 0.0f)
        {
            DeathEvent?.Invoke(this, _gameObject);
        }
    }
}
