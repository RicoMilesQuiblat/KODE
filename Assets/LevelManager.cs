using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.Video;

public class LevelManager : MonoBehaviour
{
    public string sceneName;
    public GameObject loadingScreen;
    public VideoPlayer videoPlayer;

    public Slider slider;
    // Start is called before the first frame update
    void Start()
    {
        if(videoPlayer != null){
            videoPlayer.loopPointReached += changeScene;
        }
        
    }

    // Update is called once per frame

    public void changeScene(VideoPlayer vp)
    {
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
        SceneManager.LoadScene(sceneName);
    }
    
}
