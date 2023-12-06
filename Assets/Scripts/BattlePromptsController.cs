using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class BattlePromptsController : MonoBehaviour
{
    public TextMeshProUGUI text;


    public void ChangeText(){
        text.fontSize = 75f;
    }
}
