using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering;

public class ScreenDisplayOnClearMonsters : MonoBehaviour
{
    public GameObject PopScreen; 
    [SerializeField] private EnemyAreaManager enemyAreaManager; 
    private bool isActive = false;
    [SerializeField] private GameObject CameraToTurnOff;
    [SerializeField] private GameObject CameraToTurnOn;
    [SerializeField] private bool camSwitch = false;

    public EnemyAreaManager EnemyAreaManager
    {
        get => default;
        set
        {
        }
    }

    void Update()
    {
        if (enemyAreaManager != null && !enemyAreaManager.HasEnemies)
        {   
            if (PopScreen != null && !isActive && camSwitch){
                PopScreen.SetActive(true);
                isActive = true;
                CameraToTurnOff.SetActive(false);
                CameraToTurnOn.SetActive(true);
            }       
            else if (PopScreen != null && !isActive)
            {
                PopScreen.SetActive(true);
                isActive = true;
            }
        }
        else
        {
        }
    }
}
