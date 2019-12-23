using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Fade_In : MonoBehaviour
{
    [SerializeField]
    private Image image;

    private float Add_a = 0.005f;
    private float a = 1;

    
    public void FadeIn()
    {
        var color = image.color;
        if (a > 0)
        {
            a -= Add_a;
            color.a = a;
            image.color = color;
        }
        if (a < 0)
        {
            image.gameObject.SetActive(false);
        }
    }

    void Update()
    {
        FadeIn();
    }
}