using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollController : MonoBehaviour
{
    // Start is called before the first frame update

    public GameObject scroll;
    // Update is called once per frame
    public void DropScroll(Vector2 dropPosition){
        
            scroll.SetActive(true);
            scroll.transform.position = dropPosition;
            
        
    }
}