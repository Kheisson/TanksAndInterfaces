using System;
using Gameplay.Indicators;
using GizmoLab.Gameplay.Damagables;
using UnityEngine;

namespace GizmoLab.Gameplay.Components
{
    public class HealthComponent : MonoBehaviour, IDamagable
    {
        #region Editor

        [SerializeField]
        [Range(1, 100)]
        private int _health = 100;

        #endregion

        #region Methods

        public void Damage(int damageAmount, Vector2 damageDirection)
        {
            _health -= damageAmount;
            if (_health <= 0)
            {
                Destroy(gameObject);
            }
        }

        #endregion
        
        #region Properties

        public int Health => _health;

        #endregion
    }
}