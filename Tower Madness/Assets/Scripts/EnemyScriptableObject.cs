using UnityEngine;
[CreateAssetMenu(menuName = "Gameplay Scriptable Objects/Enemy ")]
public class EnemyScriptableObject : ScriptableObject
{
   public int Health;
   public float Speed;
   public float Damage;
   public int GoldScore;
}
