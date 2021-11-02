using GizmoLab.Gameplay.Damagables;
using UnityEngine;

namespace GizmoLab.Gameplay.Projectiles
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class PixelProjectile : MonoBehaviour, IProjectile
    {
        #region Editor

        [SerializeField]
        private Rigidbody2D _rb;

        [SerializeField]
        [Range(0.1f, 5f)]
        private float _speed;

        [SerializeField]
        [Range(5f, 25f)]
        private float _maxDistance;

        [SerializeField]
        [Range(1, 100)]
        private int _damageToApply;
        
        #endregion

        #region Fields

        private Vector2 _startPosition;

        private Vector2 _direction;

        #endregion
        
        #region Methods
        
        public void Fire(Vector2 initialPosition, Vector2 direction)
        {
            _startPosition = initialPosition;
            _direction = direction;
            transform.position = _startPosition;
        }

        private void FixedUpdate()
        {
            FlyForward();
            ValidateMaxDistance();
        }

        private void FlyForward()
        {
            _rb.velocity = _direction * _speed;
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            var damagable = other.GetComponent<IDamagable>();

            if (damagable == null)
                return;

            damagable.Damage(_damageToApply, _direction);
            Destroy(gameObject);
        }

        private void ValidateMaxDistance()
        {
            if (Vector3.Distance(_startPosition, transform.position) > _maxDistance)
            {
                Destroy(gameObject);
            }
        }

        #endregion
    }
}