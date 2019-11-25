using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

/// <summary>
/// This enemy class,could be extended to be a parent class ,
/// Here, For each enemy type gameobject, should has its own Scriptable object to initialize its properties.
/// </summary>
public class Enemy : MonoBehaviour
{
    [Tooltip("Scriptable Object for Enemy properties")]
    [SerializeField] private EnemyScriptableObject enemySettings;
    
    [Tooltip("Health bar sprite")]
    [SerializeField] private Image healthBar;

    // Struct that hold enemy properties
    public struct EnemyProperties
    {
        public int Health;
        public float Damage;
        public int GoldLowRange;
        public int GoldHighRange;
    }

    [HideInInspector] public EnemyProperties enemyProperties;

    // Initializing enemy properties , called on Awake 
    public void InitializeSettings()
    {
        enemyProperties.Health = enemySettings.Health;
        enemyProperties.Damage = enemySettings.Damage;
        enemyProperties.GoldLowRange = enemySettings.GoldLowRange;
        enemyProperties.GoldHighRange = enemySettings.GoldHighRange;

        GetComponent<NavMeshAgent>().speed = enemySettings.Speed;
    }


    //TODO Memory Pooling
    // its called when enemy hit by the tower. the function return true if enemy die, we need this boolean so we can kick the enemy out from tower range later.
    public bool HitByTower(int damage)
    {
        enemyProperties.Health -= damage;

        healthBar.fillAmount = (float) enemyProperties.Health / enemySettings.Health;
        if (enemyProperties.Health <= 0)
        {
            var amount = Random.Range(enemyProperties.GoldLowRange, enemyProperties.GoldHighRange);
            GameManager.gameManager.SetGold(amount);
                
            Destroy(gameObject); //TODO , should return to bool 
            return true;
        }

        return false;
    }
}