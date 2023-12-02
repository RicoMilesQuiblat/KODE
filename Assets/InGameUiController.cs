using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InGameUiController : MonoBehaviour
{
    public GameObject tools;
    public GameObject journal;

    public void OpenJournal(){
        tools.SetActive(false);
        journal.SetActive(true);
    }

    public void CloseJournal(){
        journal.SetActive(false);
        tools.SetActive(true);
    }
}
