﻿using UnityEngine;

namespace GizmoLab.Gameplay.Components
{
    public class RecoverableHealthComponent : MonoBehaviour
    {
        #region Editor

        [SerializeField]
        [Range(1, 100)]
        private int _health = 100;

        [SerializeField]
        [Range(1, 25)]
        private int _reconverHealthPortion = 10;
        
        [SerializeField]
        [Range(0.5f, 10f)]
        private float _recoverPeriodInSeconds = 2f;
        
        #endregion

        #region Methods

        private void Start()
        {
            InvokeRepeating(nameof(RecoverHealth), 0, _recoverPeriodInSeconds);
        }

        private void OnDestroy()
        {
            CancelInvoke(nameof(RecoverHealth));
        }

        public void Damage(int damageAmount, Vector2 damageDirection)
        {
            _health -= damageAmount;
            if (_health <= 0)
            {
                Destroy(gameObject);
            }
        }

        private void RecoverHealth()
        {
            _health = Mathf.Min(100, _health + _reconverHealthPortion);
        }

        #endregion
        
        #region Properties

        public int Health => _health;

        #endregion
    }
}