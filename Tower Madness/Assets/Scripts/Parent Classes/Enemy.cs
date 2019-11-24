using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;


public class Enemy : MonoBehaviour
{
    [SerializeField] private EnemyScriptableObject enemySettings;
    [SerializeField] private Image healthBar;

    public struct EnemyProperties
    {
        public int Health;
        public float Damage;
        public int GoldLowRange;
        public int GoldHighRange;
    }

    [HideInInspector] public EnemyProperties enemyProperties;

    // In case we need to override it later on.
    public void InitializeSettings()
    {
        enemyProperties.Health = enemySettings.Health;
        enemyProperties.Damage = enemySettings.Damage;
        enemyProperties.GoldLowRange = enemySettings.GoldLowRange;
        enemyProperties.GoldHighRange = enemySettings.GoldHighRange;

        GetComponent<NavMeshAgent>().speed = enemySettings.Speed;
    }


    //TODO Memory Pooling
    public bool HitByTower(int damage)
    {
        enemyProperties.Health -= damage;

        healthBar.fillAmount = (float) enemyProperties.Health / enemySettings.Health;
        if (enemyProperties.Health <= 0)
        {
            GameManager.gameManager.globalCoins +=
                Random.Range(enemyProperties.GoldLowRange, enemyProperties.GoldHighRange);
            Destroy(gameObject);
            return true;
        }


        return false;
    }
}