using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class Video_Controller : MonoBehaviour
{
    public GameObject SkipButton;   //SkipButton
    public GameObject Fade_Out;         //FadeOut
    public GameObject Fade_In;
    bool Movie_Play = false;        //動画の静止判定
    bool Get_Start = false;
    bool Movie_Start = false;

    void Standby_Video()
    {
        var videoPlayer = GetComponent<VideoPlayer>();
        videoPlayer.Pause();
    }

    void Start_Video()
    {
        if (Movie_Start == false)
        {
            if (Get_Start == false)
            {
                Get_Start = Fade_In.GetComponent<Fade_In>().Start;
            }
            else
            {
                Movie_Start = true;
                var videoPlayer = GetComponent<VideoPlayer>();
                videoPlayer.Play();
            }
        }
    }

    void Video()
    {
        var videoPlayer = GetComponent<VideoPlayer>();
        if (videoPlayer.isPlaying /*&& Video_Play == false*/)
        {
            //Video_Play = true;
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
            Fade_Out.gameObject.SetActive(true);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        Standby_Video();
    }

    // Update is called once per frame
    void Update()
    {
        Start_Video();
        Video();
    }
}
