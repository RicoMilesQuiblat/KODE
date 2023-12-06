using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleCameraController : MonoBehaviour
{
    public Camera mainBattleCamera;
    public Camera PlayerBattleCamera;
    public Camera MonsterBattleCamera;

    public GameObject prompts;
    public GameObject prompt1;
    public GameObject prompt2;
    public ToBattle toBattle;
    public bool shouldUpdate = false;

    public GameObject playerCanvas;
    public GameObject monsterCanvas;

    public Animator animator;
    public TextMesh text;

    public ToBattle ToBattle
    {
        get => default;
        set
        {
        }
    }

    public void StartDialogue(){
       Debug.Log( "gagogagoagaogo");
        StartCoroutine(Switch());
        
    }

    
    IEnumerator Switch(){
        mainBattleCamera.enabled = false;
        PlayerBattleCamera.enabled = true;
        MonsterBattleCamera.enabled = false;
        shouldUpdate = false;
        playerCanvas.SetActive(true);
        yield return new WaitUntil(() => shouldUpdate);
        Debug.Log( "gagogagoagaogo");
        MonsterBattleCamera.enabled = true;
        PlayerBattleCamera.enabled = false;
        shouldUpdate = false;
        playerCanvas.SetActive(false);
        monsterCanvas.SetActive(true);
        yield return new WaitUntil(() => shouldUpdate);
        MonsterBattleCamera.enabled = false;
        PlayerBattleCamera.enabled = false;
        mainBattleCamera.enabled = true;
        playerCanvas.SetActive(false);
        monsterCanvas.SetActive(false);
        prompts.SetActive(true);
        prompt1.SetActive(true);
        prompt2.SetActive(true);
        // animator.Play("zoomIn");
        yield return new WaitForSeconds(8f);
        
        prompts.SetActive(false);
        monsterCanvas.SetActive(true);
        MonsterBattleCamera.enabled = true;
        PlayerBattleCamera.enabled = false;
        shouldUpdate = false;
         yield return new WaitUntil(() => shouldUpdate);
         yield return new WaitUntil(() => Input.GetMouseButtonDown(0));
         playerCanvas.SetActive(false);
        monsterCanvas.SetActive(false);
         MonsterBattleCamera.enabled = false;
         shouldUpdate = false;
        toBattle.shouldUpdate = true;
         toBattle.Initialize();
    }
}
