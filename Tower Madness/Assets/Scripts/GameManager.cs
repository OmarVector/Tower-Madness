using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI scoreText;
    [SerializeField] private TextMeshProUGUI healthText;
    [SerializeField] private EnemyManager enemyManger;

    public GameObject AAGunTower;
    public GameObject RocketTower;
    public GameObject LaserTower;

    public TowerScriptableObject AAGunSettings;
    public TowerScriptableObject RocketSettings;
    public TowerScriptableObject LaserSettings;

    public EnemyWavesScriptableObjects EnemyWaveSettings;

    public PlayerCastleScriptableObject playerSettings;

    public int globalCoins;
    public float WaveLength;
    public float WaveEnemyCount;

    public PlayerCastle PlayerCastle;

    [HideInInspector] public TowerBaseBuilder ActiveBaseBuilder;
    public UiScriptableObject UiIcon;

    private int WaveNo;

    public static GameManager gameManager;

    private void Awake()
    {
        if (gameManager == null)
            gameManager = this;
        else if (gameManager != this)
            Destroy(gameObject);

        scoreText.text = (globalCoins + playerSettings.StartingCoins).ToString();
        healthText.text = playerSettings.Health.ToString();
        DontDestroyOnLoad(gameObject);
    }

    public void SetGold(int amount)
    {
        globalCoins += amount;
        scoreText.text = globalCoins.ToString();
    }

    public void SetHealth(float amount)
    {
        healthText.text = amount.ToString();
    }
   
}