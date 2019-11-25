using TMPro;
using UnityEngine;

/// <summary>
/// Game manager script
/// </summary>
public class GameManager : MonoBehaviour
{
    [Header("Global UI Text")]
    [SerializeField] private TextMeshProUGUI scoreText;
    [SerializeField] private TextMeshProUGUI healthText;

    [Header("Towers Prefabs")]
    public GameObject AAGunTower;
    public GameObject RocketTower;
    public GameObject LaserTower;

    [Header("Towers Settings")]
    public TowerScriptableObject AAGunSettings;
    public TowerScriptableObject RocketSettings;
    public TowerScriptableObject LaserSettings;

    [Header("Waves Settings")] //TODO
    public EnemyWavesScriptableObjects EnemyWaveSettings;
    
    [Header("Player castle settings")]
    public PlayerCastleScriptableObject playerSettings;
    public PlayerCastle PlayerCastle;

    [Header("Global Settings")]
    [Tooltip("Global Coins")]
    public int globalCoins;
   
    [HideInInspector] public float WaveLength;

    // This is important to detect which Base Builder UI is currently active
    [HideInInspector] public TowerBaseBuilder ActiveBaseBuilder;
    
    [Tooltip("Global UI Icons")]
    public UiScriptableObject UiIcon;

    private int WaveNo; //TODO

    //single tone 
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