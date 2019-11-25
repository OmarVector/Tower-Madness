using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// This is Tower parent class where each tower controller is inherit from it.
/// </summary>

public class Tower : MonoBehaviour
{
    [Tooltip("Tower Setting scriptable object that hold all properties for the tower")]
    [SerializeField] private TowerScriptableObject towerSetting;
    
    [Tooltip("Particles that will be played when tower start to fire")]
    [SerializeField] private ParticleSystem weaponParticles;
    
    [Tooltip("Particles that will be played when hitting an enemy target")]
    [SerializeField] private ParticleSystem hittingTargetParticles;

    // checking if the tower is firing or idle.
    private bool isFiring;


    // struct that hold properties of the tower at runtime.
    public struct TowerProperties
    {
        public int Price;
        public float Range;
        public float FireRate;
        public int Damage;
    }

    [HideInInspector] public TowerProperties towerProperties;
    
    //List of enemies that will be in range to check who is the nearest to the castle.
    private List<GameObject> EnemiesInRange = new List<GameObject>();

    // Initializing tower properties, called at Awake
    void InitializeSettings()
    {
        towerProperties.Price = towerSetting.Price;
        towerProperties.Range = towerSetting.Range;
        towerProperties.FireRate = towerSetting.ShootIntervals;
        towerProperties.Damage = towerSetting.Damage;

        if (weaponParticles != null)
            weaponParticles.Play();
        if (hittingTargetParticles != null)
            hittingTargetParticles.Play();

        GetComponent<SphereCollider>().radius = towerProperties.Range;
        SetTowerToIdle();
    }

    public virtual void Awake()
    {
        InitializeSettings();
    }

    // Once enemy enter the tower range, its added to the list of EnemiesInRange
    public void OnTriggerEnter(Collider other)
    {
        EnemiesInRange.Add(other.gameObject);
        // Debug.Log("Enemy added");
        if (!isFiring)
        {
            StartCoroutine(CheckClosestEnemy()); // checking closest enemy to the castle to hit it
            isFiring = true;
        }
    }

    // Kicking out any enemy from EnemiesInRange once they leave the trigger volume.
    public void OnTriggerExit(Collider other)
    {
        EnemiesInRange.Remove(other.gameObject);
    }

    // checking which enemy is close to the castle.
    public IEnumerator CheckClosestEnemy()
    {
        // caching castle location.
        var castlePosition = GameManager.gameManager.PlayerCastle.gameObject.transform.position;

        while (EnemiesInRange.Count > 0)
        {
            var distance = 1000;
            var index = 0;
            for (var i = 0; i < EnemiesInRange.Count; ++i)
            {
                if (EnemiesInRange[i] == null) // its important to check this , when enemy share two tower ranges, it may be called by one while it still references by the 2nd one.
                {
                    EnemiesInRange.RemoveAt(i);
                    continue;
                }

                var x = (int) Vector3.Distance(castlePosition, EnemiesInRange[i].transform.position);
                if (distance > x)
                {
                    distance = x;
                    index = i; // setting index of the target.
                }
            }

            if (weaponParticles != null)
                weaponParticles.Play();

            if (index < EnemiesInRange.Count && hittingTargetParticles != null && EnemiesInRange[index] != null) // check of the particles should be removed, but its just for debugging. //TODO
            {
                hittingTargetParticles.gameObject.transform.position = EnemiesInRange[index].transform.position;
                hittingTargetParticles.Play();
            }

            if (index < EnemiesInRange.Count && EnemiesInRange[index] != null)
            {
                if (HitEnemy(EnemiesInRange[index].transform))
                    EnemiesInRange.RemoveAt(index);
            }


            yield return new WaitForSeconds(towerProperties.FireRate);
        }

        // once the corotine is finished, setting tower to idle
        SetTowerToIdle();
    }

    // just in case if we wanted to override it for each tower to add more styles or effects. like heat or smoke cool down..etc
    protected virtual void SetTowerToIdle()
    {
        if (weaponParticles != null)
            weaponParticles.Stop();
        if (hittingTargetParticles != null)
            hittingTargetParticles.Stop();
        
        isFiring = false;
    }

    // return true when enemy die.
    protected virtual bool HitEnemy(Transform target) // it will be override for each tower type depends on their behavior.
    {
        return false;
    }
}