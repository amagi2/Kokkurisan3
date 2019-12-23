using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Fade_Out : MonoBehaviour
{
    [SerializeField]
    private Image image;

    private float Add_a = 0.01f;
    private float a = 0;

    public void FadeOut()
    {
        var color = image.color;
        if (a < 1)
        {
            a += Add_a;
            color.a = a;
            image.color = color;
        }
        if (a > 1)
        {
            SceneManager.LoadScene("TitleScene");
            //SceneManager.LoadScene("MovieScene");
        }
    }
    
    void Update()
    {
        FadeOut();
    }
}
