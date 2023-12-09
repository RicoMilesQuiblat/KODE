using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering;
using Cinemachine;


public class ScreenDisplayOnClearMonsters : MonoBehaviour
{
    [SerializeField] private GameObject block;
    [SerializeField] private GameObject cloud;
    public GameObject PopScreen; 
    [SerializeField] private EnemyAreaManager enemyAreaManager; 
    private bool isActive = false;
    [SerializeField] private GameObject CameraToEdit;
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
        if (!isActive)
        {
            if (PopScreen != null)
            {
                PopScreen.SetActive(true);
                cloud.SetActive(false);
                block.SetActive(false);
            }

            if (camSwitch && CameraToEdit != null)
            {
                var cinemachineCamera = CameraToEdit.GetComponent<CinemachineVirtualCamera>();
                if (cinemachineCamera != null)
                {
                    cinemachineCamera.m_Lens.OrthographicSize = 12;
                }
            }

            isActive = true;
        }       
    }
}

}
