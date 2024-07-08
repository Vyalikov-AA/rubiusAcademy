using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UIElements;

namespace Assets.Scripts
{
    internal class PlayerParametrsHandler: IDisposable
    {
        private float _currentHealth;
        private float _maxHealth;
        private readonly float _damage;
        private readonly float _speed;
        private readonly float _rotate;
        private float _countOfCoins;

        public event EventHandler DeathEvent;
        public event EventHandler<(float, float)> HealthChanger;

        public float CurentHealth
        {
            get => _currentHealth;
            set => _currentHealth = value;
        }
        public float MaxHealth
        {
            get => _maxHealth;
            set => _maxHealth = value;
        }
        public float CountOfCoins
        {
            get => _countOfCoins;
            set => _countOfCoins = value;
        }
        public float DamagePlayer => _damage;
        public float SpeedPlayer => _speed;
        public float RotatePlayer => _rotate;

        public PlayerParametrsHandler(PlayerDataScriptableObject scriptableObject)//float curentHealth, float maxHealth, float damage, float speed, float rotate, float coins)
        {
            _currentHealth = scriptableObject.PlayerHealthPoints;
            _maxHealth = scriptableObject.PlayerHealthPointsMax;
            _damage = scriptableObject.PlayerDamage;
            _speed = scriptableObject.SpeedMovements;
            _rotate = scriptableObject.SpeedRotations;
            _countOfCoins = scriptableObject.NumberOfCoins;
            /*_maxHealth = maxHealth;
            _damage = damage;
            _speed = speed;
            _countOfCoins = coins;*/
        }
        public void ChangeCurrentHealth(float delta1, float delta2)
        {
            _currentHealth = Mathf.Clamp(_currentHealth + delta1, 0.0f, _maxHealth + delta2);
            HealthChanger?.Invoke(this, (_currentHealth, delta2));
            if ((_damage + delta1) <= 0.5f)
            {
                Debug.Log($" PlayerHealth = " + _currentHealth);
            }
            if (_currentHealth <= 0.0f)
            {
                DeathEvent?.Invoke(this, EventArgs.Empty);
            }
        }

        public void Dispose()
        {            
            _ = _currentHealth;
            _ = _maxHealth;
            _ = _damage;
            _ = _speed;
        }
    }
}
