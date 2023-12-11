using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class JournalController : MonoBehaviour
{
   public List<GameObject> pages = new List<GameObject>();
   public InGameUiController inGameUiController;
   private int currentPage = 0;

    public GameObject EmptyPage;
    public GameObject NonEmptyPage;
   public GameObject page1;
   public GameObject page2;
   public GameObject page3;
   public GameObject page4;
   public GameObject page5;
   public GameObject page6;
   public GameObject page7;
   public GameObject page8;
   public GameObject page9;
   public GameObject page10;
   public GameObject page11;
   public GameObject page12;

   private List<GameObject> allPages = new List<GameObject>();

   public bool firstCompletion = false;

    public InGameUiController InGameUiController
    {
        get => default;
        set
        {
        }
    }
    private void Start(){
        allPages.Add(page1);
        allPages.Add(page2);
        allPages.Add(page3);
        allPages.Add(page4);
        allPages.Add(page5);
        allPages.Add(page6);
        allPages.Add(page7);
        allPages.Add(page8);
        allPages.Add(page9);
        allPages.Add(page10);
        allPages.Add(page11);
        allPages.Add(page12);
    }
    public void DisplayPage(){
        Debug.Log(pages.Count);
        if(pages.Count == 0){
            NonEmptyPage.SetActive(false);
            EmptyPage.SetActive(true);
        }else{
            EmptyPage.SetActive(false);
            NonEmptyPage.SetActive(true);

        }
    }
    public void LoadPages(){
        
    }

    public int GetJournalCount(){
        return pages.Count;
    }
   public void NextPage(){
        int nextPage = currentPage + 1;
        if(nextPage >= pages.Count){
            Debug.Log("No next page");
        }else{
            pages[currentPage].SetActive(false);
            pages[nextPage].SetActive(true);
            currentPage = nextPage;
        }
   }

   public void PreviousPage(){
        int previousPage = currentPage - 1;

        if(previousPage < 0){
            Debug.Log("No previous Page");
        }else{
            pages[currentPage].SetActive(false);
            pages[previousPage].SetActive(true);
            currentPage = previousPage;
        }
   }

   public void AddPage(){
        pages.Add(allPages[pages.Count]);
   }

   public void QuitJournal(){
        inGameUiController.CloseJournal();
   }

}
