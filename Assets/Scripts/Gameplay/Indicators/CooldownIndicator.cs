using UnityEngine;
using UnityEngine.UI;

namespace Gameplay.Indicators
{
    public class CooldownIndicator : MonoBehaviour
    {
        #region Editor

        [SerializeField]
        private RectTransform _selfTransform;

        [SerializeField]
        private Slider _cooldownBar;

        [SerializeField]
        private CanvasGroup _canvasGroup;
        
        #endregion

        #region Fields

        private ICooldownIndicatorTarget _target;

        private Camera _transformationsCamera;
        
        #endregion
        
        #region Methods

        public void Attach(ICooldownIndicatorTarget target, Camera transformationsCamera)
        {
            _target = target;
            _transformationsCamera = transformationsCamera;
            _target.BeforeDestroy += OnBeforeDestroy;
        }

        private void Update()
        {
            if (_target == null)
            {
                return;
            }

            FollowTarget();
            UpdateCooldownBar();
            UpdateVisibility();
        }

        private void OnBeforeDestroy()
        {
            _target.BeforeDestroy -= OnBeforeDestroy;
            _target = null;
            _transformationsCamera = null;
            Destroy(gameObject);
        }

        private void UpdateVisibility()
        {
            _canvasGroup.alpha = _target.IsInCooldown ? 1 : 0;
        }

        private void FollowTarget()
        {
            _selfTransform.anchoredPosition = _transformationsCamera.WorldToScreenPoint(_target.IndicatorPivot);
        }

        private void UpdateCooldownBar()
        {
            _cooldownBar.value = _target.InverseCooldownProgress;
        }
        
        #endregion
    }
}