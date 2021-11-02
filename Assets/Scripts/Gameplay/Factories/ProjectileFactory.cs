using GizmoLab.Gameplay.Projectiles;
using UnityEngine;

namespace GizmoLab.Gameplay.Factories
{
    public class ProjectileFactory : MonoBehaviour
    {
        #region Editor

        [SerializeField]
        private Object _projectilePrefabRef;

        #endregion
        
        #region Methods

        public IProjectile Create()
        {
            var projectileInstance = (GameObject)Instantiate(_projectilePrefabRef);
            return projectileInstance.GetComponent<IProjectile>();
        }

        #endregion
    }
}