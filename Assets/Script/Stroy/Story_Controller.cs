﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using UnityEngine.SceneManagement;

public class Story_Controller : MonoBehaviour
{
    public GameObject Fade;         //FadeOut
    private int Get_Scene_Count;    //Game_ControllerのScene_Countを取得
    //VideoPlayer
    [SerializeField]
    private GameObject[] Video = new GameObject[7];
    [SerializeField]
    private GameObject Score_Con;

    //再生するVideoPlayerを決める
    void Play_Video()
    {
        Get_Scene_Count = Game_Controller.Scene_Count;
        Video[Get_Scene_Count].gameObject.SetActive(true);
    }
    //FadeOutにてNextがTrueになったら次のシーンへ
    void Next_Scene()
    {
        if (Fade.GetComponent<Fade_Out>().Next == true)
        {
            //スコア更新
            Score_Con.GetComponent<Score_Controller>().Add_Score();
            if (Get_Scene_Count != 6) SceneManager.LoadScene("GameScene");
            else
            {
                SceneManager.LoadScene("GameClear");
                Game_Controller.Scene_Count = 0;
            }
        }
    }

    void Start()
    {
        Play_Video();
    }

    void Update()
    {
        Next_Scene();
    }
}
