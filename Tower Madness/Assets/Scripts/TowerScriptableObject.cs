using UnityEngine;

[CreateAssetMenu(menuName = "Gameplay Scriptable Objects/Tower ")]
public class TowerScriptableObject : ScriptableObject
{
   public int Price;
   public float Range;
   public float ShootIntervals;
   public int Damage;
   public ParticleSystem weaponParticleSystem;
   public ParticleSystem hittingTargetParticleSystem;
}
