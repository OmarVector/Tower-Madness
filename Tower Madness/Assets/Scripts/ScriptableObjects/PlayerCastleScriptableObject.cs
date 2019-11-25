using UnityEngine;

// TO create new one, just right click on any folder and check "GamePlay ScriptableObjects->Player Castle Settings"
[CreateAssetMenu(menuName = "Gameplay Scriptable Objects/Player Castle Settings ")]
public class PlayerCastleScriptableObject : ScriptableObject
{
   [Tooltip("Castle total health")]
   public int Health;
   
   [Tooltip("Initial Gold amount where the game start with")]
   public int StartingCoins;
}
