using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Fade_UI : MonoBehaviour
{
    [SerializeField]
    private Image image;

    //変更時はFade_Outも
    private float Add_a = 0.04f;
    private float a = 0;
    private float Add_Time = 0.02f; //時間
    private float Count_Time = 0;   //時間
    private bool FadeIn = true;


    private void FadeUI_In()
    {
        var color = image.color;
        if (Count_Time > 1)
        {
            if (a < 1 && FadeIn == true)
            {
                a += Add_a * 25;
                color.a = a;
                image.color = color;
            }
            else
            {
                FadeIn = false;
            }
        }
        else
        {
            Count_Time += Add_Time;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        FadeUI_In();
    }
}
