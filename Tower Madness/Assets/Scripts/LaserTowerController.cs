using UnityEngine;

public class LaserTowerController : Tower
{
    [Tooltip("LineRender for laser effect")]
    [SerializeField] private LineRenderer lineRender;

    public override void Awake()
    {
        lineRender.SetPosition(0, transform.position);
        base.Awake();
    }
    

    protected override bool HitEnemy(Transform target)
    {
        lineRender.SetPosition(1, target.transform.localPosition);
        lineRender.enabled = true;
        
        Invoke(nameof(EnableLineRender), 0.05f); // for laser fire effect, I found 0.5 is best value, hard coded for testing purpose
       
        return target.GetComponent<Enemy>().HitByTower(towerProperties.Damage);
    }

    private void EnableLineRender()
    {
        lineRender.enabled = false;
    }
}