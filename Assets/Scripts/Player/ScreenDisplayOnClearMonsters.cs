using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenDisplayOnClearMonsters : MonoBehaviour
{
    public GameObject deathScreen; // Assign your death screen prefab in the Inspector
    private EnemyAreaManager enemyAreaManager;

    void Start()
    {
        // Find the EnemyAreaManager in the scene
        enemyAreaManager = FindObjectOfType<EnemyAreaManager>();
        if (enemyAreaManager == null)
        {
            Debug.LogError("EnemyAreaManager not found in the scene.");
        }
    }

    void Update()
    {
        // Check if there are no enemies left
        if (enemyAreaManager != null && !enemyAreaManager.HasEnemies)
        {
            // Show the death screen
            if (deathScreen != null)
            {
                deathScreen.SetActive(true);
                // You can also add additional logic here to handle the death screen
            }
        }
        else
        {
            // Hide the death screen if enemies are present or if the EnemyAreaManager is not found
            if (deathScreen != null)
            {
                deathScreen.SetActive(false);
                // You can also add additional logic here to hide the death screen
            }
        }
    }
}
