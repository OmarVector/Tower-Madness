using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;


public class Tower : MonoBehaviour
{
    [SerializeField] private TowerScriptableObject towerSetting;
    [SerializeField] private ParticleSystem weaponParticles;
    [SerializeField] private ParticleSystem hittingTargetParticles;

    [Inject] private PlayerCastle playerCastle;

    private bool isFiring;


    public struct TowerProperties
    {
        public int Price;
        public float Range;
        public float FireRate;
        public int Damage;
    }

    [HideInInspector] public TowerProperties towerProperties;
    private List<GameObject> EnemiesInRange = new List<GameObject>();

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
    }

    public virtual void Awake()
    {
        InitializeSettings();
    }


    public void OnTriggerEnter(Collider other)
    {
        EnemiesInRange.Add(other.gameObject);
        // Debug.Log("Enemy added");
        if (!isFiring)
        {
            StartCoroutine(CheckEnemyInRange());
            isFiring = true;
        }
    }

    public void OnTriggerExit(Collider other)
    {
        EnemiesInRange.Remove(other.gameObject);
        // Debug.Log(EnemiesInRange.Count);
    }

    public IEnumerator CheckEnemyInRange()
    {
        var castlePosition = GameManager.gameManager.PlayerCastle.gameObject.transform.position;

        while (EnemiesInRange.Count > 0)
        {
            var distance = 1000;
            var index = 0;
            for (var i = 0; i < EnemiesInRange.Count; ++i)
            {
                if (EnemiesInRange[i] == null)
                {
                    EnemiesInRange.RemoveAt(i);
                    continue;
                }

                var x = (int) Vector3.Distance(castlePosition, EnemiesInRange[i].transform.position);
                if (distance > x)
                {
                    distance = x;
                    index = i;
                }
            }

            if (weaponParticles != null)
                weaponParticles.Play();

            if (index < EnemiesInRange.Count && hittingTargetParticles != null)
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

        if (weaponParticles != null)
            weaponParticles.Stop();
        if (hittingTargetParticles != null)
            hittingTargetParticles.Stop();
        
        isFiring = false;
    }


    // return true when enemy die.
    protected virtual bool HitEnemy(Transform target)
    {
        return false;
    }
}