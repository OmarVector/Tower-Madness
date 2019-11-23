using UnityEngine;

public class AAGunTowerController : Tower
{
   protected override bool HitEnemy(Transform target)
   {
      return target.GetComponent<Enemy>().HitByTower(towerProperties.Damage);
   }
}
