using UnityEngine;

namespace GizmoLab.Gameplay.Projectiles
{
    public interface IProjectile
    {
        public void Fire(Vector2 initialPosition, Vector2 direction);
    }
}
