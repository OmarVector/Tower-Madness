using UnityEngine;


public class PlayerCastle : MonoBehaviour
{
    [SerializeField] private PlayerCastleScriptableObject playerSettings;

    [HideInInspector] public float Health;
    [HideInInspector] public int StartedCoins;

    void InitializeSettings()
    {
        Health = GameManager.gameManager.playerSettings.Health;
        StartedCoins = GameManager.gameManager.PlayerCastle.StartedCoins;
    }

    private void Awake()
    {
        InitializeSettings();
    }

    private void OnTriggerEnter(Collider enemy)
    {
        //TODO
        Health -= enemy.gameObject.GetComponent<Enemy>().enemyProperties.Damage;
        GameManager.gameManager.SetHealth(Health);
        // Debug.Log(Health);
    }
}