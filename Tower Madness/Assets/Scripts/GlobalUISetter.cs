using UnityEngine;
using UnityEngine.UI;

public class GlobalUISetter : MonoBehaviour
{
   [SerializeField] private Image goldIcon;
   [SerializeField] private Image healthIcon;

   private void Awake()
   {
      goldIcon.sprite = GameManager.gameManager.UiIcon.GoldIcon;
      healthIcon.sprite = GameManager.gameManager.UiIcon.HealthIcon;

   }
}
