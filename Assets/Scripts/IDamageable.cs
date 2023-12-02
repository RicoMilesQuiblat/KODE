using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IDamageable {
    public float Health {set; get;}

    void GetHit();
}