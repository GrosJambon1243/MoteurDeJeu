using UnityEngine;

namespace Script
{
    public interface IWeaponLevelUp
    {
        void LevelUp(float Damage, float Speed, int ScaleModifier);
    }
}