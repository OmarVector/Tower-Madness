using UnityEngine;


public class PlayerCastle : MonoBehaviour
{
    [SerializeField] private PlayerCastleScriptableObject playerSettings;
  
    [HideInInspector] public int Health;
    [HideInInspector] public int StartedCoins;

    void InitializeSettings()
    {
        Health = playerSettings.Health;
        StartedCoins = playerSettings.StartingCoins;
    }
    
    private void Awake()
    {
       InitializeSettings();
    }

    private void OnTriggerEnter(Collider enemy)
    {
        //TODO
        Health -= 100;
       // Debug.Log(Health);
    }

 
}
