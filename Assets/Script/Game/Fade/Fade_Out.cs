using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Fade_Out : MonoBehaviour
{
    [SerializeField]
    private Image image;

    private float Add_a = 0.04f;
    private float a = 0;
    private float Add_Time = 0.02f; //時間
    private float Count_Time = 0;   //時間

    public bool Next = false;

    public void FadeOut()
    {
        var color = image.color;
        if (Count_Time > 0)
        {
            if (a < 1)
            {
                a += Add_a;
                color.a = a;
                image.color = color;
            }
            if (a >= 1)
            {
                Next = true;
            }
        }
        else
        {
            Count_Time += Add_Time;
        }
        
    }
    
    void Update()
    {
        FadeOut();
    }
}
