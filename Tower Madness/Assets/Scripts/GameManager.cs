using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI scoreText;
    
    public GameObject AAGunTower;
    public GameObject RocketTower;
    public GameObject LaserTower;

    public TowerScriptableObject AAGunSettings;
    public TowerScriptableObject RocketSettings;
    public TowerScriptableObject LaserSettings;

    public int globalCoins;
    public float WaveLength;
    public float WaveEnemyCount;

    public PlayerCastle PlayerCastle;

   [HideInInspector] public TowerBaseBuilder ActiveBaseBuilder;
    public UiScriptableObject UiIcon;

    public static GameManager gameManager;

    private void Awake()
    {
        if (gameManager == null)
            gameManager = this;
        else if (gameManager != this)
            Destroy(gameObject);

        scoreText.text = globalCoins.ToString();
        DontDestroyOnLoad(gameObject);
    }

    public void SetGold(int amount)
    {
        globalCoins += amount;
        scoreText.text = globalCoins.ToString();
    }
}