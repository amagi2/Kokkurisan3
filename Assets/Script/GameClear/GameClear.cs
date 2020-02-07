using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameClear : MonoBehaviour
{
    public GameObject Fade_Out;
    public GameObject Fade_In;
    [SerializeField]
    private GameObject new_score_text;
    [SerializeField]
    private GameObject score_1_text;
    [SerializeField]
    private GameObject score_2_text;
    [SerializeField]
    private GameObject score_3_text;
    public static float New_Score;
    private float Score_1;
    private float Score_2;
    private float Score_3;

    //FadeOutにてNextがTrueになったら次のシーンへ
    void Next_Scene()
    {
        if (Fade_Out.GetComponent<Fade_Out>().Next == true)
        {
            SceneManager.LoadScene("TitleScene");
        }
    }
    //スコア比較
    void Score_Comparison()
    {
        if (New_Score != 0)
        {
            if (Score_1 > New_Score || Score_1 == 0)
            {
                Score_3 = Score_2;
                Score_2 = Score_1;
                Score_1 = New_Score;
            }
            else if (Score_2 > New_Score || Score_2 == 0)
            {
                Score_3 = Score_2;
                Score_2 = New_Score;
            }
            else if (Score_3 > New_Score || Score_3 == 0)
            {
                Score_3 = New_Score;
            }
        }
    }
    void Score_UI()
    {
        Text Time_1_text = score_1_text.GetComponent<Text>();
        Time_1_text.text = "1." + Score_1 + "秒";

        Text Time_2_text = score_2_text.GetComponent<Text>();
        Time_2_text.text = "2." + Score_2 + "秒";

        Text Time_3_text = score_3_text.GetComponent<Text>();
        Time_3_text.text = "3." + Score_3 + "秒";

        Text Time_New_text = new_score_text.GetComponent<Text>();
        Time_New_text.text = New_Score + "秒";
    }
    void Score_Save()
    {
        PlayerPrefs.SetFloat("SCORE1", Score_1);
        PlayerPrefs.SetFloat("SCORE2", Score_2);
        PlayerPrefs.SetFloat("SCORE3", Score_3);
        PlayerPrefs.Save();
        New_Score = 0;
    }
    void Score_Load()
    {
        New_Score = Mathf.Floor(New_Score);
        Score_1 = PlayerPrefs.GetFloat("SCORE1", 0);
        Score_2 = PlayerPrefs.GetFloat("SCORE2", 0);
        Score_3 = PlayerPrefs.GetFloat("SCORE3", 0);
    }
    void Score_Del()
    {
        Score_1 = 0;
        Score_2 = 0;
        Score_3 = 0;
        PlayerPrefs.DeleteAll();
    }
    void Set_Score()
    {
        if(Fade_In.GetComponent<Fade_In>().Start == true)
        {
            new_score_text.gameObject.SetActive(true);
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        Score_Load();
        Score_Comparison();
        Score_UI();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            Score_Del();
        }
        if (Input.GetMouseButtonUp(0))
        {
            Score_Save();
            Fade_Out.gameObject.SetActive(true);
        }
        Next_Scene();
        Set_Score();
    }
}
