using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Detection : MonoBehaviour
{
    // Start is called before the first frame update
    public List<Collider2D> detectedObj = new List<Collider2D>();

   public Collider2D col;

    void Start()
    {
        col.GetComponent<Collider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnTriggerEnter2D(Collider2D collider){
        if(collider.gameObject.tag == "Player"){

        detectedObj.Add(collider);
        }
    }

    void OnTriggerExit2D(Collider2D collider){
        if(collider.gameObject.tag == "Player"){

            detectedObj.Remove(collider);
        }
    }
    }

