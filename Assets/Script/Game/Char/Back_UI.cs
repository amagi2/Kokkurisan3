using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Back_UI : MonoBehaviour
{
    SpriteRenderer spriteRenderer;  //Order in Layer取得用

    private float Add_a = 0.05f;//透明度変更値
    private float a;            //透明度
    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    //文字背景
    public void UI()
    {
        var color = spriteRenderer.color;
        if (a < 1)
        {
            a += Add_a;
            color.a = a;
            spriteRenderer.color = color;
        }
    }
    public void DeleteUI()
    {
        var color = spriteRenderer.color;
        a = 0;
        color.a = a;
        spriteRenderer.color = color;
    }

    // Update is called once per frame
    void Update()
    {

    }
}
