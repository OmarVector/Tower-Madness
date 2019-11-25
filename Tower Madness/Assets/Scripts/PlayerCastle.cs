using UnityEngine;

/// <summary>
/// Player castle script. can be extended for more advanced behavior , like firing on enemies themselves.
/// </summary>
public class PlayerCastle : MonoBehaviour
{
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
    }
}