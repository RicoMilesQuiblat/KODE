using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Reflection;
using UnityEditor;

public class GameAssets : MonoBehaviour
{
    private static GameAssets _i;
    
    public static GameAssets i{
        get{
            if(_i == null) {
                _i = Instantiate(Resources.Load<GameAssets>("GameAssets"));
            }
            return _i;
        }
    }
    
    [SerializeField]
    private Transform pfPopUp;

    public Transform PfPopUp => pfPopUp;
}
