using System;
using Gameplay.Indicators;
using GizmoLab.Gameplay.Damagables;
using UnityEngine;

namespace GizmoLab.Gameplay.Components
{
    public class HealthComponent : MonoBehaviour, IDamagable, IHealthIndicatorTarget
    {
        #region Events

        public event Action BeforeDestroy; 
        
        #endregion
        
        #region Editor

        [SerializeField]
        [Range(1, 100)]
        private int _health = 100;

        [SerializeField]
        private Transform _indicatorPivot;
        
        #endregion

        #region Methods

        public void Damage(int damageAmount, Vector2 damageDirection)
        {
            _health -= damageAmount;
            if (_health <= 0)
            {
                BeforeDestroy?.Invoke();
                Destroy(gameObject);
            }
        }

        #endregion
        
        #region Properties

        public Vector3 IndicatorPivot => _indicatorPivot.position;
        
        public int Health => _health;

        #endregion
    }
}