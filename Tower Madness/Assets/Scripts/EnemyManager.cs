using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class EnemyManager : MonoBehaviour
{
    [Header("Enemies GameObject")] [SerializeField]
    private GameObject basicEnemy;

    [SerializeField] private GameObject eliteEnemy;
    [SerializeField] private GameObject bossEnemy;

    private List<GameObject> BasicEnemyList = new List<GameObject>();
    private List<GameObject> EliteEnemyList = new List<GameObject>();
    private List<GameObject> BossEnemyList = new List<GameObject>();

    [Header("Enemies memory pool size")] [Tooltip("Basic Enemy pool size")]
    public int BasicEnemySize;

    public int EliteEnemySize;
    public int BossEnemySize;

    public float spaceBetweenEachEnemy;

    private void Awake()
    {
        BasicEnemySize = GameManager.gameManager.EnemyWaveSettings.EnemyWaves[0].BasicEnemyCount;
        EliteEnemySize = GameManager.gameManager.EnemyWaveSettings.EnemyWaves[0].EliteEnemyCount;
        BossEnemySize = GameManager.gameManager.EnemyWaveSettings.EnemyWaves[0].BossEnemyCount;
    }

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


    public void StartWave(int basicEnemyCount, int eliteEnemyCount, int bossEnemyCount, float basicEnemyInterval,
        float eliteEnemyInterval, float bossEnemyInterval)
    {
        StartCoroutine(CallBasicEnemy(basicEnemyCount, basicEnemyInterval));
        StartCoroutine(CallEliteEnemy(eliteEnemyCount, eliteEnemyInterval));
        StartCoroutine(CallBossEnemy(bossEnemyCount, bossEnemyInterval));
    }

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
        StartWave(BasicEnemySize, EliteEnemySize, BossEnemySize, spaceBetweenEachEnemy,
            spaceBetweenEachEnemy, spaceBetweenEachEnemy);
        //StartCoroutine(EnableEnemy());
    }

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