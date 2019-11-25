using UnityEngine;

// TO create new one, just right click on any folder and check "GamePlay ScriptableObjects->Enemy
[CreateAssetMenu(menuName = "Gameplay Scriptable Objects/Enemy ")]
public class EnemyScriptableObject : ScriptableObject
{
   [Tooltip("Health of the enemy")]
   public int Health;
   
   [Tooltip("How fast is moving toward player castle")] 
   public float Speed;
   
   [Tooltip("Damage it does to the player castle")]
   public float Damage;
   
   [Tooltip("Min gold amount drop when it die")]
   public int GoldLowRange;
   
   [Tooltip("Max gold amount drop when it die")]
   public int GoldHighRange;
}
