using System;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;


public class TowerBaseBuilder : MonoBehaviour
{
    [SerializeField] private RectTransform buildingCanvas;
    [SerializeField] private Image AAGunIcon;
    [SerializeField] private Image LaserIcon;
    [SerializeField] private Image RocketIcon;

    private Camera mainCamera;

    private void Awake()
    {
        AAGunIcon.sprite = GameManager.gameManager.UiIcon.AAGunTowerIcon;
        LaserIcon.sprite = GameManager.gameManager.UiIcon.LaserTowerIcon;
        RocketIcon.sprite = GameManager.gameManager.UiIcon.RocketTowerIcon;
    }

    // Start is called before the first frame update
    void Start()
    {
        buildingCanvas.DOScale(0, 0);
        mainCamera = Camera.main;
        buildingCanvas.GetComponent<Canvas>().worldCamera = mainCamera;
    }


    public void LoadBuildingCanvas()
    {
        if (GameManager.gameManager.ActiveBaseBuilder != null)
        {
            GameManager.gameManager.ActiveBaseBuilder.CloseBuildingCanvas();
        }

        if (GameManager.gameManager.ActiveBaseBuilder == this)
        {
            GameManager.gameManager.ActiveBaseBuilder = null;
            CloseBuildingCanvas();
            return;
        }

        buildingCanvas.DOScale(1, 0.2f);
        buildingCanvas.LookAt(mainCamera.transform);


        GameManager.gameManager.ActiveBaseBuilder = this;
    }

    public void CloseBuildingCanvas()
    {
        buildingCanvas.DOScale(0, 0.2f);
    }

    public void BuildAAGunTower()
    {
        
    }
}



















