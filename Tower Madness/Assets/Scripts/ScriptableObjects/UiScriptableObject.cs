using UnityEngine;

// TO create new one, just right click on any folder and check "GamePlay ScriptableObjects->UI Elements"
[CreateAssetMenu(menuName = "Gameplay Scriptable Objects/UI Elements ")]
public class UiScriptableObject : ScriptableObject
{
    [Tooltip("AAGun tower image sprite")]
    public Sprite AAGunTowerIcon;
    
    [Tooltip("Laser tower image sprite")]
    public Sprite LaserTowerIcon;
    
    [Tooltip("Flame tower image sprite")]
    public Sprite FlameTowerIcon;
    
    [Tooltip("Rocket tower image sprite")]
    public Sprite RocketTowerIcon;
    
    [Tooltip("Gold image sprite for global UI")]
    public Sprite GoldIcon;
    
    [Tooltip("Health image sprite for global UI")]
    public Sprite HealthIcon;
}
