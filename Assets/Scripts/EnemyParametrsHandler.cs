using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts
{
    internal class EnemyParametrsHandler: IDisposable
    {
        private float _currentHealth;
        private readonly float _damage;
        private readonly float _speed;

        public event EventHandler DeathEvent;
        public event EventHandler<float> HealthChanger;

        public float CurentHealth
        {
            get => _currentHealth;
            set => _currentHealth = value;
        }
        public float DamageEnemy => _damage;
        public float SpeedEnemy => _speed;

        public EnemyParametrsHandler(PlayerDataScriptableObject scriptableObject)//float curentHealth, float damage, float speed)
        {
            _currentHealth = scriptableObject.EnemyHealthPoints;
            _damage = scriptableObject.EnemyDamage;
            _speed = scriptableObject.SpeedMovementsEnemy;
            /*
            _currentHealth = curentHealth;
            _damage = damage;
            _speed = speed;*/
        }
        public void ChangeCurrentHealth(float delta)
        {
            if (_currentHealth > 0.0f)
            {
                _currentHealth += delta;                
                HealthChanger?.Invoke(this, _currentHealth);
                if ((_damage + delta) <= 0.5f)
                {
                    Debug.Log($" EnemyHealth = " + _currentHealth);
                }
            }
            if (_currentHealth <= 0.0f)
            {
                Debug.Log($" EnemyHealth death");
                DeathEvent?.Invoke(this, EventArgs.Empty);
            }
        }

        public void Dispose()
        {
            _ = _currentHealth;
        }
    }
}
