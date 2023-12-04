using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TipPopout : MonoBehaviour
{
    private TextMeshPro textMesh;
    private float disappearTimer;
    private Color textColor;
    private Color initialColor; // Store the initial color

    public static TipPopout Create(Vector3 position, string tip, float textSize, Color color)
    {
        Transform TipPopupTransform = Instantiate(GameAssets.i.PfPopUp, position, Quaternion.identity);
        TipPopout tipPopup = TipPopupTransform.GetComponent<TipPopout>();
        tipPopup.setup(tip, textSize, color);

        return tipPopup;
    }

    private void Awake()
    {
        textMesh = transform.GetComponent<TextMeshPro>();
    }

    public void setup(string Tip, float textSize, Color color)
    {
        textMesh.SetText(Tip);
        textMesh.fontSize = textSize;
        initialColor = color; // Set the initial color
        disappearTimer = 1f;
    }

    private void Start()
    {
        textMesh.color = initialColor; // Set the color here
        textColor = initialColor; // Use the initial color
        Debug.Log("TipPopout color set to: " + initialColor);
    }

    private void Update()
    {
        float moveYSpeed = 20f;
        transform.position += new Vector3(0, moveYSpeed) * Time.deltaTime / 4;

        disappearTimer -= Time.deltaTime;
        if (disappearTimer < 0)
        {
            float disappearSpeed = 3f;
            textColor.a -= disappearSpeed * Time.deltaTime;
            textMesh.color = textColor;
            if (textColor.a < 0)
            {
                Destroy(gameObject);
            }
        }
    }
}