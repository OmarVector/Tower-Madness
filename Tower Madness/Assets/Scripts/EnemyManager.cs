using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

/// <summary>
/// This class managing enemies .
/// </summary>
public class EnemyManager : MonoBehaviour
{
    [Header("Enemies GameObject")] 
    [Tooltip("Basic Enemy prefab")] 
    [SerializeField]
    private GameObject basicEnemy;
    
    [Tooltip("Elite Enemy prefab")]
    [SerializeField] 
    private GameObject eliteEnemy;

    [Tooltip("Boss Enemy prefab")] 
    [SerializeField]
    private GameObject bossEnemy;

    private List<GameObject> BasicEnemyList = new List<GameObject>();
    private List<GameObject> EliteEnemyList = new List<GameObject>();
    private List<GameObject> BossEnemyList = new List<GameObject>();

    [Header("Enemies memory pool size")] 
    
    [Tooltip("Basic enemies pool size")]
    public int BasicEnemySize;
    
    [Tooltip("Elite enemies pool size")]
    public int EliteEnemySize;
    
    [Tooltip("Boss enemies pool size")]
    public int BossEnemySize;

    public float spaceBetweenEachEnemy;

    // Hard coding first wave enemies size //TODO 
    private void Awake()
    {
        BasicEnemySize = GameManager.gameManager.EnemyWaveSettings.EnemyWaves[0].BasicEnemyCount;
        EliteEnemySize = GameManager.gameManager.EnemyWaveSettings.EnemyWaves[0].EliteEnemyCount;
        BossEnemySize = GameManager.gameManager.EnemyWaveSettings.EnemyWaves[0].BossEnemyCount;
    }

    // Initializing Enemies Pool
    private void InitializeEnemyPool()
    {
        var BasicEnemyGrp = new GameObject("Basic Enemy Grp");
        var EliteEnemyGrp = new GameObject("Elite Enemy Grp");
        var BossEnemyGrp = new GameObject("Boss Enemy Grp");

        for (int i = 0; i < BasicEnemySize; ++i)
        {
            var Enemy = Instantiate(basicEnemy, transform.position, Quaternion.identity);
            Enemy.GetComponent<Enemy>().InitializeSettings();
            Enemy.transform.SetParent(BasicEnemyGrp.transform);

            BasicEnemyList.Add(Enemy);
        }

        for (int i = 0; i < EliteEnemySize; ++i)
        {
            var Enemy = Instantiate(eliteEnemy, transform.position, Quaternion.identity);
            Enemy.GetComponent<Enemy>().InitializeSettings();
            Enemy.transform.SetParent(EliteEnemyGrp.transform);

            EliteEnemyList.Add(Enemy);
        }

        for (int i = 0; i < BossEnemySize; ++i)
        {
            var Enemy = Instantiate(bossEnemy, transform.position, Quaternion.identity);
            Enemy.GetComponent<Enemy>().InitializeSettings();
            Enemy.transform.SetParent(BossEnemyGrp.transform);

            BossEnemyList.Add(Enemy);
        }
    }


    // Starting wave //TODO
    private void StartWave(int basicEnemyCount, int eliteEnemyCount, int bossEnemyCount, float basicEnemyInterval,
        float eliteEnemyInterval, float bossEnemyInterval)
    {
        StartCoroutine(CallBasicEnemy(basicEnemyCount, basicEnemyInterval));
        StartCoroutine(CallEliteEnemy(eliteEnemyCount, eliteEnemyInterval));
        StartCoroutine(CallBossEnemy(bossEnemyCount, bossEnemyInterval));
    }

    // Basic Enemy wave start
    private IEnumerator CallBasicEnemy(int count, float interval)
    {
        var dest = GameManager.gameManager.PlayerCastle.gameObject.transform.position;

        if (count > BasicEnemySize)
            throw new Exception("Enemy count is higher than the pool size");

        for (int i = 0; i < count; ++i)
        {
            BasicEnemyList[i].GetComponent<NavMeshAgent>().SetDestination(dest);
            yield return new WaitForSeconds(interval);
        }
    }

    // Elite Enemy wave start
    private IEnumerator CallEliteEnemy(int count, float interval)
    {
        var dest = GameManager.gameManager.PlayerCastle.gameObject.transform.position;

        if (count > BasicEnemySize)
            throw new Exception("Enemy count is higher than the pool size");

        for (int i = 0; i < count; ++i)
        {
            EliteEnemyList[i].GetComponent<NavMeshAgent>().SetDestination(dest);
            yield return new WaitForSeconds(interval);
        }
    }

    // Boss Enemy wave start
    private IEnumerator CallBossEnemy(int count, float interval)
    {
        var dest = GameManager.gameManager.PlayerCastle.gameObject.transform.position;

        if (count > BasicEnemySize)
            throw new Exception("Enemy count is higher than the pool size");

        for (int i = 0; i < count; ++i)
        {
            BossEnemyList[i].GetComponent<NavMeshAgent>().SetDestination(dest);
            yield return new WaitForSeconds(interval);
        }
    }


    // Start is called before the first frame update
    void Start()
    {
        InitializeEnemyPool();
        //TODO, adding interval for each enemy type
        StartWave(BasicEnemySize, EliteEnemySize, BossEnemySize, spaceBetweenEachEnemy,
            spaceBetweenEachEnemy, spaceBetweenEachEnemy);
        //StartCoroutine(EnableEnemy());
    }

    // Dupricated
    private IEnumerator EnableEnemy()
    {
        var dest = GameManager.gameManager.PlayerCastle.gameObject.transform.position;
        for (int i = 0; i < BasicEnemySize; ++i)
        {
            BasicEnemyList[i].GetComponent<NavMeshAgent>().SetDestination(dest);
            yield return new WaitForSeconds(spaceBetweenEachEnemy);
        }
    }
}