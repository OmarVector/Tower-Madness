using UnityEngine;

public class RocketTowerController : Tower
{
    [Tooltip("Detection layer mask for sphere cast that fire to do area damage")] [SerializeField]
    private LayerMask enemyLayerMask;

    protected override bool HitEnemy(Transform target)
    {
        var raycastHits = Physics.SphereCastAll(target.position, 2f, Vector3.forward, 20, enemyLayerMask);

        if (raycastHits.Length > 1)
        {
            for (int i = 1; i < raycastHits.Length; ++i)
            {
                raycastHits[i].transform.gameObject.GetComponent<Enemy>().HitByTower(towerProperties.Damage);
            }
        }

        return target.GetComponent<Enemy>().HitByTower(towerProperties.Damage);
    }
}