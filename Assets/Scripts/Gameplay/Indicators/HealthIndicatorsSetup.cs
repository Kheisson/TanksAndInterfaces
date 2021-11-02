using System.Linq;
using UnityEngine;

namespace Gameplay.Indicators
{
    public class HealthIndicatorsSetup : MonoBehaviour
    {
        #region Editor

        [SerializeField]
        private Object _healthIndicatorPrefabRef;
        
        [SerializeField]
        private RectTransform _parentTransform;

        [SerializeField]
        private Camera _transformationCamera;
        
        #endregion
        
        #region Methods

        private void Start()
        {
            AddHealthIndicators();
        }

        private void AddHealthIndicators()
        {
            var healthIndicatorTargets = FindObjectsOfType<MonoBehaviour>().OfType<IHealthIndicatorTarget>();
            foreach (var target in healthIndicatorTargets)
            {
                var healthIndicator = CreateHealthIndicator();
                healthIndicator.Attach(target, _transformationCamera);
            }
        }

        private HealthIndicator CreateHealthIndicator()
        {
            var indicatorInstance = (GameObject)Instantiate(_healthIndicatorPrefabRef, _parentTransform);
            return indicatorInstance.GetComponent<HealthIndicator>();
        }

        #endregion
    }
}