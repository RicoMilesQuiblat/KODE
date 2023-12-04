using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneSwitcher : MonoBehaviour
{
    // Start is called before the first frame update

    public GameObject loadingScreen;
   public Slider slider;

    
    
    public void SwitchScene(){
        StartCoroutine(Loading());
    }

    IEnumerator Loading(){
        slider.value = 0f;
        float timer = 0f;
        loadingScreen.SetActive(true);
        while(timer < 5f){
            timer += Time.deltaTime;
            slider.value = timer;
            yield return null;
        }

        SceneManager.LoadScene("InputOutput", LoadSceneMode.Single);
    }
}
