using UnityEngine;
using UnityEngine.UI;

namespace Gameplay.Indicators
{
    public class HealthIndicator : MonoBehaviour
    {
        #region Editor

        [SerializeField]
        private RectTransform _selfTransform;

        [SerializeField]
        private Slider _healthBar;
        
        #endregion

        #region Fields

        private IHealthIndicatorTarget _target;

        private Camera _transformationCamera;

        #endregion
        
        #region Methods

        public void Attach(IHealthIndicatorTarget target, Camera transformationCamera)
        {
            _target = target;
            _transformationCamera = transformationCamera;
            _target.BeforeDestroy += OnBeforeDestroy;
        }

        private void Update()
        {
            if (_target == null)
            {
                return;
            }

            FollowTarget();
            UpdateHealthBar();
        }

        private void FollowTarget()
        {
            _selfTransform.anchoredPosition = _transformationCamera.WorldToScreenPoint(_target.IndicatorPivot);
        }

        private void OnBeforeDestroy()
        {
            _target.BeforeDestroy -= OnBeforeDestroy;
            _target = null;
            _transformationCamera = null;
            Destroy(gameObject);
        }

        private void UpdateHealthBar()
        {
            _healthBar.value = _target.Health;
        }

        #endregion
    }
}