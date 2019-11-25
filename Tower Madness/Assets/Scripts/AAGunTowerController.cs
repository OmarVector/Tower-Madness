using UnityEngine;

public class AAGunTowerController : Tower
{
   // AAGun is very simple , it just lock on target and does the damage.
   protected override bool HitEnemy(Transform target)
   {
      return target.GetComponent<Enemy>().HitByTower(towerProperties.Damage);
   }
}
