using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MazePopsOff : MonoBehaviour
{
    [SerializeField] private GameObject toTurnOff;
    
    public void turnOff(){
        toTurnOff.SetActive(false);
    }
}
