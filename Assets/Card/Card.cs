using System.Collections;
using UnityEngine;

public class Card : MonoBehaviour
{
    private GameObject prefabObject; 

    [SerializeField]
    private GameObject facePrefab, backPrefab; 

    private bool coroutineAllowed, facedUp;

    // Add an identifier for each card
    public string cardIdentifier;

    void Start()
    {
        prefabObject = Instantiate(backPrefab, transform.position, Quaternion.identity);
        prefabObject.transform.parent = transform;
        prefabObject.SetActive(true);
        backPrefab.SetActive(true);
        facePrefab.SetActive(false);
        coroutineAllowed = true;
        facedUp = false;
    }

    private void OnMouseDown()
    {
        if (coroutineAllowed)
        {
            StartCoroutine(RotateCard());
        }
    }

    private IEnumerator RotateCard()
    {
        coroutineAllowed = false;

        if (!facedUp)
        {
            for (float i = 0f; i <= 180f; i += 10f)
            {
                transform.rotation = Quaternion.Euler(0f, i, 0f);
                if (i == 90f)
                {
                    Destroy(prefabObject);
                    prefabObject = Instantiate(facePrefab, transform.position, Quaternion.identity);
                    prefabObject.transform.parent = transform;
                    prefabObject.SetActive(true);
                }
                yield return new WaitForSeconds(0.01f);
            }
        }
        else if (facedUp)
        {
            for (float i = 180f; i >= 0f; i -= 10f)
            {
                transform.rotation = Quaternion.Euler(0f, i, 0f);
                if (i == 90f)
                {
                    Destroy(prefabObject);
                    prefabObject = Instantiate(backPrefab, transform.position, Quaternion.identity);
                    prefabObject.transform.parent = transform;
                    prefabObject.SetActive(true);
                }
                yield return new WaitForSeconds(0.01f);
            }
        }
        backPrefab.SetActive(false);
        facePrefab.SetActive(true);
        if(facedUp) {
            backPrefab.SetActive(true);
            facePrefab.SetActive(false);
        } else {
            backPrefab.SetActive(false);
            facePrefab.SetActive(true);
        }
        coroutineAllowed = true;
        facedUp = !facedUp;

        // Output the identifier of the rotated card
        Debug.Log("Rotated Card: " + cardIdentifier);
    }
}
