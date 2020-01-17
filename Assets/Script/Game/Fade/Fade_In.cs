using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Fade_In : MonoBehaviour
{
    [SerializeField]
    private Image image;//Fade

    private float Add_a = 0.04f;    //透明度変更値
    private float a = 1;            //透明度
    private float Add_Time = 0.02f; //時間
    private float Count_Time = 0;   //時間
    public bool Start = false;      //FadeInが終わったらゲーム(動画)を開始するための識別

    
    public void FadeIn()
    {
        if (Count_Time > 1)
        {
            Start = true;
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
        else
        {
            Count_Time += Add_Time;
        }
    }

    void Update()
    {
        FadeIn();
    }
}