using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using UnityEngine.SceneManagement;

public class Movie_Controller : MonoBehaviour
{
    public GameObject Fade;         //FadeOut
    public void OnClick()
    {
        //FadeOut
        Fade.gameObject.SetActive(true);

    }
    //FadeOutにてNextがTrueになったら次のシーンへ
    void Next_Scene()
    {
        if (Fade.GetComponent<Fade_Out>().Next == true)
        {
            SceneManager.LoadScene("StoryScene");
        }
    }

    void Start()
    {

    }

    void Update()
    {
        Next_Scene();
    }
}
