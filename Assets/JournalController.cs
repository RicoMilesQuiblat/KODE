using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JournalController : MonoBehaviour
{
   public List<GameObject> pages = new List<GameObject>();
   public InGameUiController inGameUiController;
   private int currentPage = 0;

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

   public void QuitJournal(){
        inGameUiController.CloseJournal();
   }

}
