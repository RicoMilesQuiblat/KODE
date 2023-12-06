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
    public bool shouldUpdate = true;

    public GameObject playerCanvas;
    public GameObject monsterCanvas;

    

    public void StartDialogue(){
        Switch();
    }
    IEnumerator Switch(){

        mainBattleCamera.enabled = false;
        PlayerBattleCamera.enabled = true;
        MonsterBattleCamera.enabled = false;
        shouldUpdate = false;
        playerCanvas.SetActive(true);
        yield return new WaitUntil(() => shouldUpdate);
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
        yield return new WaitForSeconds(2f);
        prompt2.SetActive(true);
        yield return new WaitForSeconds(2f);
        prompts.SetActive(false);
        monsterCanvas.SetActive(true);
        MonsterBattleCamera.enabled = true;
        PlayerBattleCamera.enabled = false;
        shouldUpdate = false;
         yield return new WaitUntil(() => shouldUpdate);
         playerCanvas.SetActive(false);
        monsterCanvas.SetActive(false);
         MonsterBattleCamera.enabled = false;
         mainBattleCamera.enabled = true;
         toBattle.shouldUpdate = true;
    }
}
