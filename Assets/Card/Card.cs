using System.Collections;
using UnityEngine;
using System.Collections.Generic;
using Unity.VisualScripting;

public class Card : MonoBehaviour
{
    private GameObject prefabObject; 

    [SerializeField]
    private GameObject facePrefab, backPrefab; 

    private bool coroutineAllowed, facedUp;
    public string cardIdentifier;
    static int ctr = 0;
    static string temp;
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
        if (coroutineAllowed && ctr < 2 && !facedUp) 
        {
            if(string.IsNullOrEmpty(temp)) {
                temp = cardIdentifier;
            }
            ctr++;
            Debug.Log(ctr);
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

        Debug.Log("Rotated Card: " + cardIdentifier);

        if(ctr >= 2) { 
            yield return new WaitForSeconds(1f);
            if(temp == "1" && cardIdentifier == "3"  || temp == "3" && cardIdentifier == "1"
            || temp == "2" && cardIdentifier == "6" || temp == "6" && cardIdentifier == "2"
            || temp == "9" && cardIdentifier == "10" || temp == "10" && cardIdentifier == "9"
            || temp == "4" && cardIdentifier == "5" || temp == "5" && cardIdentifier == "4"
            || temp == "7" && cardIdentifier == "8"|| temp == "8" && cardIdentifier == "7") {
                temp = "";
                ctr = 0;
                deleteCards();
            } else {
                FlipBackAllCards();
            }
        }
    }
    private static void FlipBackAllCards()
    {
        Card[] allCards = GameObject.FindObjectsOfType<Card>();

        foreach (Card card in allCards)
        {
            if (card.facedUp)
            {
                card.StartCoroutine(card.FlipBack());
            }
        }
    }

    private static void deleteCards()
    {
        Card[] allCards = GameObject.FindObjectsOfType<Card>();

        foreach (Card card in allCards)
        {
            if (card.facedUp)
            {
                Destroy(card.gameObject); // Destroy the GameObject associated with the Card script
            }
        }
    }

    private IEnumerator FlipBack()
    {
        coroutineAllowed = false;

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

        backPrefab.SetActive(true);
        facePrefab.SetActive(false);

        coroutineAllowed = true;
        facedUp = false;
        
        Debug.Log("Flipped Back Card: " + cardIdentifier);
        temp = "";
        ctr = 0;
    }
}