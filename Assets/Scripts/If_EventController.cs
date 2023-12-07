using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class If_EventController : MonoBehaviour
{
    public GameObject objectz;

    private void OnEnable()
    {
        Maze_IF_Anim.OnLeverStateChanged += HandleLeverStateChanged;
    }

    private void OnDisable()
    {
        Maze_IF_Anim.OnLeverStateChanged -= HandleLeverStateChanged;
    }

    private void HandleLeverStateChanged(bool isLeverOn)
    {
        objectz.SetActive(isLeverOn);
    }
}
