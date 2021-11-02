using System.Linq;
using UnityEngine;

namespace Gameplay.Indicators
{
    public class CooldownIndicatorsSetup : MonoBehaviour
    {
        #region Editor

        [SerializeField]
        private Object _cooldownIndocatorPrefabRef;
        
        [SerializeField]
        private RectTransform _parentTransform;

        [SerializeField]
        private Camera _transformationCamera;
        
        #endregion
        
        #region Methods

        private void Start()
        {
            AddCooldownIndicators();
        }

        private void AddCooldownIndicators()
        {
            var cooldownIndicatorTargets = FindObjectsOfType<MonoBehaviour>().OfType<ICooldownIndicatorTarget>();
            foreach (var target in cooldownIndicatorTargets)
            {
                var cooldownIndicator = CreateCooldownIndicator();
                cooldownIndicator.Attach(target, _transformationCamera);
            }
        }

        private CooldownIndicator CreateCooldownIndicator()
        {
            var indicatorInstance = (GameObject)Instantiate(_cooldownIndocatorPrefabRef, _parentTransform);
            return indicatorInstance.GetComponent<CooldownIndicator>();
        }

        #endregion
    }
}