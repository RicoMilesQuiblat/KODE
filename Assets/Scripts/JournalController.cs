using System.Collections;
using System.Collections.Generic;
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
        if(pages.Count == 0){
            pages.Add(page1);
        }else if(pages.Count == 1){
            pages.Add(page2);
        }
   }

   public void QuitJournal(){
        inGameUiController.CloseJournal();
   }

}
