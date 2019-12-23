using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Answer_Char : MonoBehaviour
{
    SpriteRenderer spriteRenderer;
    float Add_a = 0.05f;//透明度変更値
    float a;            //透明度

    //public bool Fade_Out;
    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        //Fade_Out = false;
    }

    //文字背景
    void UI()
    {
        var color = spriteRenderer.color;
        if (a < 1)
        {
            a += Add_a;
            color.a = a;
            spriteRenderer.color = color;
        }
    }

    // Update is called once per frame
    void Update()
    {
        UI();
    }
}
