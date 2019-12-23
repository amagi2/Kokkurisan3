
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Fade_Out_Stroy : MonoBehaviour
{
    [SerializeField]
    private Image image;

    private float Add_a = 0.05f;
    private float a = 0;
    public bool Next_Game = true;
    private static int Scene_Count_Movie;

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
            if (Next_Game == true)
            {
                SceneManager.LoadScene("GameScene");
            }
            else
            {
                SceneManager.LoadScene("GameClear");
            }
        }
    }
    private void Start()
    {
        Scene_Count_Movie += 1;
        if (Scene_Count_Movie == 2/*7*/)
        {
            Next_Game = false;
            Scene_Count_Movie = 0;
        }
    }

    void Update()
    {
        FadeOut();
    }
}
