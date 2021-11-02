using GizmoLab.Gameplay.Components;
using GizmoLab.Gameplay.Factories;
using GizmoLab.Infrastructure;
using UnityEngine;

namespace GizmoLab.Gameplay.Wehicles
{
    [RequireComponent(typeof(Animator))]
    [RequireComponent(typeof(Rigidbody2D))]
    public class Tank : MonoBehaviour
    {
        #region Consts

        private const string FIRE_TRIGGER_NAME = "fire";

        #endregion
        
        #region Editor

        [SerializeField]
        private Animator _animator;

        [SerializeField]
        private Rigidbody2D _rb;
        
        [SerializeField]
        [Range(0.1f, 2f)]
        private float _moveSpeed;

        [SerializeField]
        [Range(0.1f, 2f)]
        private float _turnSpeed;

        [SerializeField]
        private Transform _firePosition;

        [SerializeField]
        private ProjectileFactory _projectilFactory;

        [SerializeField]
        private CooldownComponent _cooldownComponent;
        
        #endregion

        #region Fields

        private int _fireTriggerHash;
        
        #endregion
        
        #region Methods

        private void Awake()
        {
            _fireTriggerHash = Animator.StringToHash(FIRE_TRIGGER_NAME);
        }

        private void FixedUpdate()
        {
            Move(InputManager.GetMovementInput());
            Rotate(InputManager.GetRotationInput());
        }

        private void Update()
        {
            if (InputManager.IsFireRequested())
            {
                Fire();
            }
        }

        private void Rotate(float rotationInput)
        {
            transform.RotateAround(transform.position, Vector3.back, rotationInput * _turnSpeed);
        }

        private void Move(float moveInput)
        {
            _rb.velocity = transform.up * _moveSpeed * moveInput;
        }

        private void Fire()
        {
            if (_cooldownComponent.IsInCooldown)
            {
                return;
            }

            var projectile = _projectilFactory.Create();
            projectile.Fire(_firePosition.position, transform.up);

            _animator.SetTrigger(_fireTriggerHash);
            _cooldownComponent.Begin();
        }

        #endregion
    }
}