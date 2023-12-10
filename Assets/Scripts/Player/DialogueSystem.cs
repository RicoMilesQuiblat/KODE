using UnityEngine;
using TMPro; // Import the TextMeshPro namespace
using System.Collections;
using Cinemachine;

public class DialogueSystem : MonoBehaviour
{
    [SerializeField] private CinemachineVirtualCamera virtualCamera;
    [SerializeField] private GameObject player;
    [SerializeField] private GameObject enemy;
    [SerializeField, TextArea] private string dialogueScript;
    [SerializeField] private TMP_Text playerDialogueText; 
    [SerializeField] private TMP_Text enemyDialogueText; 
    [SerializeField] private Camera mainCamera;
    [SerializeField] private Camera changeToCamera;
    [SerializeField] private Canvas dialogueCanvas;
    [SerializeField] private bool isBattleMode;
    [SerializeField] private Collider2D dialogueTriggerArea; 
    [SerializeField] private string playerTag = "Player"; 
    private bool dialogueTriggered = false;

    private float defaultOrthoSize = 8f;
    private float zoomOrthoSize = 4f;
    private string[] dialogueParts;
    private int currentPart = 0;
    private float typingSpeed = 0.02f;

    private void Start()
    {
        dialogueCanvas.gameObject.SetActive(false);
        
        dialogueParts = dialogueScript.Split(new string[] { "##" }, System.StringSplitOptions.RemoveEmptyEntries);

        for (int i = 0; i < dialogueParts.Length; i++)
        {
            dialogueParts[i] = dialogueParts[i].Trim();
        }
    }
    private void Update()
    {
        
    }

    private IEnumerator ProcessDialogue()
    {
        playerDialogueText.gameObject.SetActive(false);
        enemyDialogueText.gameObject.SetActive(false);

        foreach (string part in dialogueParts)
        {
            string currentLine = part.Trim();

            
            bool isPlayerSpeaking = currentLine.StartsWith(">");
            TMP_Text targetTextComponent = isPlayerSpeaking ? playerDialogueText : enemyDialogueText;
            GameObject targetCharacter = isPlayerSpeaking ? player : enemy;

            playerDialogueText.gameObject.SetActive(isPlayerSpeaking);
            enemyDialogueText.gameObject.SetActive(!isPlayerSpeaking);

            FocusOnCharacter(targetCharacter, zoomOrthoSize);

            
            currentLine = currentLine.Substring(1).Trim();

            
            yield return StartCoroutine(TypeDialogue(currentLine, targetTextComponent));
        }

        EndDialogue();
    }

    private void EndDialogue()
    {
       
        playerDialogueText.gameObject.SetActive(false);
        enemyDialogueText.gameObject.SetActive(false);
        dialogueCanvas.gameObject.SetActive(false);

        
        if (isBattleMode)
        {
            SwitchToBattleCamera();
        }
        else
        {
            ResetCameraFocus();
        }
    }



    private void FocusOnCharacter(GameObject character, float orthoSize)
    {
        Debug.Log("Focusing on character: " + character.name);
        virtualCamera.Follow = character.transform;
        virtualCamera.m_Lens.OrthographicSize = orthoSize;
    }


    
    private IEnumerator TypeDialogue(string line, TMP_Text dialogueText)
{
    dialogueText.text = "";
    bool skip = false; 


    yield return new WaitForSeconds(0.3f);

    foreach (char letter in line)
    {
        if (Input.GetMouseButtonDown(0))
        {
            skip = true; 
        }

        if (!skip)
        {
            dialogueText.text += letter;
            yield return new WaitForSeconds(typingSpeed); 
        }
        else
        {
            dialogueText.text = line; 
            break; 
        }
    }

   
    dialogueText.text = line;


    yield return new WaitForSeconds(0.3f);
    while (!Input.GetMouseButtonDown(0))
    {
        yield return null;
    }
}





    private void SwitchToBattleCamera()
    {
        mainCamera.enabled = false;
        changeToCamera.enabled = true;
        changeToCamera.orthographicSize = defaultOrthoSize;
    }

    private void ResetCameraFocus()
    {
        FocusOnCharacter(player, defaultOrthoSize);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag(playerTag) && !dialogueTriggered)
        {
            Debug.Log("Starting dialogue due to trigger.");
            dialogueTriggered = true; 
            dialogueTriggerArea.enabled = false; 
            StartDialogue();
        }
    }




    private void StartDialogue()
    {
        if (dialogueCanvas == null)
        {
            Debug.LogError("Dialogue Canvas is not assigned.");
            return;
        }

        dialogueCanvas.gameObject.SetActive(true);
        StartCoroutine(ProcessDialogue()); 
    }





}
