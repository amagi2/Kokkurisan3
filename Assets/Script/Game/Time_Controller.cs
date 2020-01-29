using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Time_Controller : MonoBehaviour
{
    public GameObject Time_Ui;      //UI表示用(テスト)
    public　float Set_Time;            //制限時間
    float Time_Num;                 //残り時間
    float time;                     //経過時間
    public bool Time_Over = false;  //タイムオーバー判定用
    private Sprite sprite_10;        //画像
    private Sprite sprite_1;        //画像
    public bool Time_Stopper = false;//正解時時間を止める

    [SerializeField]
    private Image image_10; //時間表示　10の桁
    [SerializeField]
    private Image image_1;  //時間表示　1の桁

    private float Check_Time_10;//時間確認　10の桁
    private float Check_Time_1; //時間確認　1の桁


    void Time_UI()
    {
        if (Time_Stopper != true)
        {
            if (Time_Num >= 1)
            {
                //経過時間を取得
                time += Time.deltaTime;
                //制限時間から引いて残り時間を取得
                Time_Num = Set_Time - time;
                //整数にする
                Time_Num = Mathf.Floor(Time_Num);
                Check_Time_10 = Mathf.Floor(Time_Num / 10);
                Check_Time_1 = Time_Num - (Check_Time_10 * 10);
                //時間に合わせて画像を変更してく 10の桁
                switch (Check_Time_10)
                {
                    case 0:
                        sprite_10 = Resources.Load<Sprite>("0");
                        break;
                    case 1:
                        sprite_10 = Resources.Load<Sprite>("1");
                        break;
                    case 2:
                        sprite_10 = Resources.Load<Sprite>("2");
                        break;
                    case 3:
                        sprite_10 = Resources.Load<Sprite>("3");
                        break;
                }
                image_10.sprite = sprite_10;
                //時間に合わせて画像を変更してく 1の桁
                switch (Check_Time_1)
                {
                    case 0:
                        sprite_1 = Resources.Load<Sprite>("0");
                        break;
                    case 1:
                        sprite_1 = Resources.Load<Sprite>("1");
                        break;
                    case 2:
                        sprite_1 = Resources.Load<Sprite>("2");
                        break;
                    case 3:
                        sprite_1 = Resources.Load<Sprite>("3");
                        break;
                    case 4:
                        sprite_1 = Resources.Load<Sprite>("4");
                        break;
                    case 5:
                        sprite_1 = Resources.Load<Sprite>("5");
                        break;
                    case 6:
                        sprite_1 = Resources.Load<Sprite>("6");
                        break;
                    case 7:
                        sprite_1 = Resources.Load<Sprite>("7");
                        break;
                    case 8:
                        sprite_1 = Resources.Load<Sprite>("8");
                        break;
                    case 9:
                        sprite_1 = Resources.Load<Sprite>("9");
                        break;
                }
                image_1.sprite = sprite_1;
                //UIで表示する(テスト)
                //Text Time_text = Time_Ui.GetComponent<Text>();
                //Time_text.text = "残り時間 " + Time_Num;
            }
            else
            {
                Time_Over = true;
            }
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        Set_Time += 1.5f;
        Time_Num = Set_Time;
    }

    // Update is called once per frame
    void Update()
    {
        Time_UI();
    }
}
