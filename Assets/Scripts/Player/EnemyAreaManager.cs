using System;
using UnityEngine;

public class EnemyAreaManager : MonoBehaviour
{
    private int enemyCount = 0;
    public bool HasEnemies => enemyCount > 0;
    public event Action OnAllEnemiesCleared;

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.CompareTag("enemy"))
        {
            enemyCount++;
        }
    }

    private void OnTriggerExit2D(Collider2D collider)
    {
        if (collider.CompareTag("enemy"))
        {
            enemyCount--;
            if (enemyCount <= 0)
            {
                // Trigger the event
                OnAllEnemiesCleared?.Invoke();
            }
        }
    }
}
