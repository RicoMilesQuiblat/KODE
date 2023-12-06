using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenDisplayOnClearMonsters : MonoBehaviour
{
    public GameObject PopScreen; // Assign your death screen prefab in the Inspector
    [SerializeField] private EnemyAreaManager enemyAreaManager; // Serialized field for the EnemyAreaManager
    private bool isActive = false;

    public EnemyAreaManager EnemyAreaManager
    {
        get => default;
        set
        {
        }
    }

    void Update()
    {
        // Check if there are no enemies left in the specified area
        if (enemyAreaManager != null && !enemyAreaManager.HasEnemies)
        {
            // Show the death screen
            if (PopScreen != null && !isActive)
            {
                PopScreen.SetActive(true);
                isActive = true;
                // You can also add additional logic here to handle the death screen
            }
        }
        else
        {
            // Handle the case when enemies are still present or no area manager is set
        }
    }
}
