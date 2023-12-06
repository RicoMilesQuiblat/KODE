using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chapter2StartDialogueController : MonoBehaviour
{
    public Camera mainCamera;
    public Camera playerMiniCamera;

    public Camera timeMachineCamera;

    public bool shouldUpdate = false;

    public GameObject playerDialogue;

    public ObjectivesController objectivesController;

    public GameObject goblinsCutscene;

    public GameObject goblins;

    public GameObject BossBattle1;
    public GameObject BossBattle2;
    public GameObject footsteps;
    public GameObject boss2Collider;

    public void StartDialogues(){
        StartCoroutine(Switch());
    }

    private IEnumerator Switch(){
        BossBattle1.SetActive(false);
        BossBattle2.SetActive(true);
        footsteps.SetActive(true);
        boss2Collider.SetActive(true);
        mainCamera.enabled = false;
        playerMiniCamera.enabled = false;
        goblinsCutscene.SetActive(true);
        timeMachineCamera.enabled = true;
        yield return new WaitForSeconds(3f);
        timeMachineCamera.enabled = false;
        playerMiniCamera.enabled = true;
        playerDialogue.SetActive(true);
        shouldUpdate = false;
        yield return new WaitUntil(() => shouldUpdate);
        playerMiniCamera.enabled = false;
        mainCamera.enabled = true;
        playerDialogue.SetActive(false);
        objectivesController.ChangeObjective();
        goblinsCutscene.SetActive(false);
        goblins.SetActive(true);
        shouldUpdate = false;
    }
}
