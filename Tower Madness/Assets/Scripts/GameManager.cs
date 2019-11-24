using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject AAGunTower;
    public GameObject RocketTower;
    public GameObject LaserTower;

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

        DontDestroyOnLoad(gameObject);
    }
}