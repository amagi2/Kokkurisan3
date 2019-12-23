using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Time_Controller : MonoBehaviour
{
    public GameObject Time_Ui;
    float Set_Time = 30;
    float Time_Num;
    float time;

    void Time_UI()
    {
        if (Time_Num >= 1)
        {
            time += Time.deltaTime;
            Time_Num = Set_Time - time;
            Time_Num = Mathf.Floor(Time_Num);
            Text Time_text = Time_Ui.GetComponent<Text>();
            Time_text.text = "残り時間 " + Time_Num;
        }
        else
        {
            SceneManager.LoadScene("GameOverScene");
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        Time_Num = Set_Time + 1;
    }

    // Update is called once per frame
    void Update()
    {
        Time_UI();

    }
}
