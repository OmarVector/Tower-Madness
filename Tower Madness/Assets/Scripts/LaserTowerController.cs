using System.Collections;
using UnityEngine;

public class LaserTowerController : Tower
{
    [SerializeField] private LineRenderer lineRender;

    public override void Awake()
    {
        lineRender.SetPosition(0, transform.position);
        base.Awake();
    }
    

    protected override bool HitEnemy(Transform target)
    {
        Debug.Log(lineRender.positionCount);
        
        lineRender.SetPosition(1, target.transform.localPosition);
        lineRender.enabled = true;
        
        Invoke(nameof(EnableLineRender), 0.05f);

        Debug.Log(towerProperties.Damage);
       
        return target.GetComponent<Enemy>().HitByTower(towerProperties.Damage);
    }

    private void EnableLineRender()
    {
        lineRender.enabled = false;
    }
}