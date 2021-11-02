using UnityEngine;

namespace GizmoLab.Gameplay.Damagables
{
    public interface IDamagable
    {
        void Damage(int damageAmount, Vector2 damageDirection);
    }
}
