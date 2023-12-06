using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartController : MonoBehaviour
{
    public GameObject goblins;
    public GameObject bossBattle1;
    public GameObject bossBattle2;

    public GameObject footsteps;
    public GameObject Boss2Collider;

    // Start is called before the first frame update
    void Start()
    {
        goblins.SetActive(false);
        bossBattle1.SetActive(true);
        bossBattle2.SetActive(false);
        footsteps.SetActive(false);
        Boss2Collider.SetActive(false);
        
    }

}
