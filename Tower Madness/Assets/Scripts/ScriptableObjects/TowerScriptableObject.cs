using UnityEngine;

// TO create new one, just right click on any folder and check "GamePlay ScriptableObjects->Tower"
[CreateAssetMenu(menuName = "Gameplay Scriptable Objects/Tower ")]
public class TowerScriptableObject : ScriptableObject
{
   [Tooltip("Tower's Cost")]
   public int Price;
   
   // it sets the collision sphere radius.
   [Tooltip("Tower Fire Range")]
   public float Range;
   
   [Tooltip("Attack rates per sec")]
   public float ShootIntervals;
   
   [Tooltip("Tower's Damage to enemy")]
   public int Damage;
   
   //TODO
   public ParticleSystem weaponParticleSystem;
   public ParticleSystem hittingTargetParticleSystem;
}
