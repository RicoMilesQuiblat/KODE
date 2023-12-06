using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TipPopout : MonoBehaviour
{
    private TextMeshPro textMesh;
    private float moveYSpeed = 20f;
    private float disappearTimer;
    private Color textColor;
    private Color initialColor; // Store the initial color

    // Adjust this variable to control how long the tip remains visible
    public float timeToDisappear = 1f;

    public static TipPopout Create(Vector3 position, string tip, float textSize, Color color, float timeToDisappear)
{
    Transform TipPopupTransform = Instantiate(GameAssets.i.PfPopUp, position, Quaternion.identity);
    TipPopout tipPopup = TipPopupTransform.GetComponent<TipPopout>();
    tipPopup.setup(tip, textSize, color, timeToDisappear);

    return tipPopup;
}


    private void Awake()
    {
        textMesh = transform.GetComponent<TextMeshPro>();
    }

    public void setup(string Tip, float textSize, Color color, float timeToDisappear)
    {
        textMesh.SetText(Tip);
        textMesh.fontSize = textSize;
        initialColor = color; // Set the initial color
        this.timeToDisappear = timeToDisappear; // Set the disappear timer based on the parameter
        disappearTimer = timeToDisappear; // Set the disappear timer initially
    }


    private void Start()
    {
        textMesh.color = initialColor; // Set the color here
        textColor = initialColor; // Use the initial color
        Debug.Log("TipPopout color set to: " + initialColor);
    }

    private void Update()
    {
        // Move along the Y-axis
        transform.position += new Vector3(0, moveYSpeed) * Time.deltaTime / 4;

        // Decrease the disappear timer
        disappearTimer -= Time.deltaTime;

        // Check if the disappear timer has reached zero
        if (disappearTimer <= 0)
        {
            Destroy(gameObject); 
        }
    }
}
