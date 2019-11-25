using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// script that setting up global UI icons
/// </summary>
public class GlobalUISetter : MonoBehaviour
{
    [Header("Global UI Icon reference")]
    [Tooltip("Gold reference")]
    [SerializeField]
     private Image goldIcon;

    [Tooltip("Health reference")]
    [SerializeField]
     private Image healthIcon;

    private void Start()
    {
        SetIcons();
    }

    // setting reference's icon to match our theme that is stored at UIIcon scriptable object 
    private void SetIcons()
    {
        goldIcon.sprite = GameManager.gameManager.UiIcon.GoldIcon;
        healthIcon.sprite = GameManager.gameManager.UiIcon.HealthIcon;
    }
}