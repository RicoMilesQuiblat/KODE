using System.Collections;
using System.Collections.Generic;
using Unity.Jobs.LowLevel.Unsafe;
using UnityEngine;

public class SlimeSpawnController : MonoBehaviour
{
    public GameObject Scroll1;
    public GameObject Scroll2;
    public GameObject Scroll3;
    public GameObject Scroll4;
    public GameObject Scroll5;

    private List<GameObject> Scrolls = new List<GameObject>();
    private int journalCount;

    private void Start(){
        Scrolls.Add(Scroll1);
        Scrolls.Add(Scroll2);

        Scrolls.Add(Scroll3);

        Scrolls.Add(Scroll4);

        Scrolls.Add(Scroll5);

    }
    private void DestroyScroll(){
        for(int i = 0; i < journalCount; i++){
            Destroy(Scrolls[i]);
        }
    }
}
