using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using UnityEngine.SceneManagement;

public class Movie_controller: MonoBehaviour
{
    public GameObject SkipButton;//Skipボタン
    public GameObject Fade;
    bool Movie_Play = false;//動画の静止判定
    private static int Scene_Count_Movie;
    bool start = false;


    //Skipボタンを押したら    
    public void OnClick()
    {
        Fade.gameObject.SetActive(true);
    }

    void Start()
    {
        
    }

    void Update()
    {
        var videoPlayer = GetComponent<VideoPlayer>();
        if (videoPlayer.isPlaying && start == false)
        {
            start = true;
            Movie_Play = true;
        }
        //タップを離したら
        if (Input.GetMouseButtonUp(0))
        {
            if (videoPlayer.isPlaying)
            {
                videoPlayer.Pause();
                Movie_Play = false;
                SkipButton.gameObject.SetActive(true);
            }
            else if (!videoPlayer.isPlaying)
            {
                videoPlayer.Play();
                Movie_Play = true;
                SkipButton.gameObject.SetActive(false);
            }
        }
        if (!videoPlayer.isPlaying && Movie_Play == true)
        {
            Fade.gameObject.SetActive(true);
        }
    }
}
