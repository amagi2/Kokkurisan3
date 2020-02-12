using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Game_Controller : MonoBehaviour
{
    public GameObject Coin;     //Coin_Controller
    public GameObject Paper;    //文字盤
    public GameObject Game_SE;  //SE
    public GameObject Arrow;    //コイン上の矢印
    public GameObject Fade;     //FadeOut
    public GameObject Time_Con; //TimeController
    [SerializeField]
    private GameObject[] Movie = new GameObject[6];//VideoPlayer達
    [SerializeField]
    private GameObject Score_Con;
    [SerializeField]
    private GameObject Time_10;
    [SerializeField]
    private GameObject Time_1;

    private string Tap_Object;  //タップ先のオブジェクト(のタグ)
    private string Tap_Name;    //タップ先のオブジェクトの名前
    private string Get_Char;    //Coin_Controllerから文字を受け取る

    [SerializeField]
    private GameObject[] Question = new GameObject[18]; //問題（オブジェクト）
    [SerializeField]
    private GameObject[] Char = new GameObject[18];     //答え（表示）

    private int Q_Num;//問題（設定）

    //答え（文字盤と照合する用）
    private string[] Answer ={
        /*0*/"A","I","U","E","O",       /*4*/
        /*5*/"KA","KI","KU","KE","KO",  /*9*/
        /*10*/"SA","SI","SU","SE","SO", /*14*/
        /*15*/"TA","TI","TU","TE","TO", /*19*/
        /*20*/"NA","NI","NU","NE","NO", /*24*/
        /*25*/"HA","HI","HU","HE","HO", /*29*/
        /*30*/"MA","MI","MU","ME","MO", /*34*/
        /*35*/"YA","YU","YO",           /*37*/
        /*38*/"RA","RI","RU","RE","RO", /*42*/
        /*43*/"WA","WO","N"             /*45*/
    };

    //答え（設定）
    private int[] A_Num ={
        11,2,37,    //し、う、よ
        6,45,35,    //き、ん、や
        4,11,26,    //お、し、ひ
        8,7,15,     //け、く、た
        18,11,14,   //て、し、そ
        2,1,11      //う、い、し
    };

    //透過関連
    SpriteRenderer spriteRenderer;

    [SerializeField]
    private GameObject[] Life = new GameObject[3];  //LifeのUI
    private int life;                               //残りLife

    public static int Scene_Count = 0;//シーン何回目か

    bool G_SE = true;

    //動くゴキブリ
    [SerializeField]
    private GameObject[] G = new GameObject[15];
    [SerializeField]
    private GameObject G_Group;
    [SerializeField]
    private GameObject G_Group2;

    //文字上のゴキブリ
    [SerializeField]
    private GameObject[] Char_G = new GameObject[6];

    //霧関連
    [SerializeField]
    private GameObject Mist;    //霧
    private Vector3 Save_Pos;   //座標用比較座標セーブ

    [SerializeField]
    private GameObject Blood;

    //ゴキブリリアルスイッチ
    public static bool G_Switch = true;

    //問題設定
    void Answer_Set()
    {
        //何シーンか確認、シーンに合った問題をランダムで選ぶ
        //ついでに動画もセットする
        //ついでにギミックも...
        //制限時間も......
        //3問目廃止処理
        if (Scene_Count == 3) Scene_Count++;
        //テスト用
        //Scene_Count = 6;
        Debug.Log(G_Switch);
        switch (Scene_Count)
        {
            case 1:
                Q_Num = Random.Range(0, 3);
                Movie[0].gameObject.SetActive(true);
                GetComponent<Time_Controller>().Set_Time = 30;
                break;
            case 2:
                Q_Num = Random.Range(3, 6);
                Movie[1].gameObject.SetActive(true);
                GetComponent<Time_Controller>().Set_Time = 20;
                break;
            case 3:
                Q_Num = Random.Range(6, 9);
                Movie[2].gameObject.SetActive(true);
                GetComponent<Time_Controller>().Set_Time = 20;
                break;
            case 4:
                Q_Num = Random.Range(9, 12);
                Movie[3].gameObject.SetActive(true);
                //霧
                GetComponent<Time_Controller>().Set_Time = 20;
                Mist.gameObject.SetActive(true);
                break;
            case 5:
                Q_Num = Random.Range(12, 15);
                Movie[4].gameObject.SetActive(true);
                //血
                Blood.gameObject.SetActive(true);
                GetComponent<Time_Controller>().Set_Time = 20;
                break;
            case 6:
                Q_Num = Random.Range(15, 18);
                Movie[5].gameObject.SetActive(true);
                //ゴキブリ
                if (G_Switch != true)
                {
                    G_Group.gameObject.SetActive(true);
                    for (int i = 0; i <= 6; i++)
                    {
                        Char_G[i].gameObject.SetActive(true);
                    }
                }
                else
                {
                    for (int i = 7; i <= 13; i++)
                    {
                        Char_G[i].gameObject.SetActive(true);
                    }
                    G_Group2.gameObject.SetActive(true);
                }
                GetComponent<Time_Controller>().Set_Time = 20;
                break;
        }
        //選んだ問題を表示する
        Question[Q_Num].gameObject.SetActive(true);
        Time_10.SetActive(true);
        Time_1.SetActive(true);
    }


    //タップ
    void Tap()
    {
        //タップを認識
        if (Input.touchCount > 0)//タッチ数が１以上の時
        {
            /*タップした座標を確認する処理*/
            //タッチの個数確認
            Touch t = Input.GetTouch(0);

            Vector3 touchPint_screen = new Vector3(t.position.x, t.position.y, 0);
            //カメラ(画面)を基準に座標を設定する
            Vector3 touchPint_world = Camera.main.ScreenToWorldPoint(touchPint_screen);
            Collider2D tap = Physics2D.OverlapPoint(touchPint_world);

            //画面に触れたとき
            if (Input.GetMouseButtonDown(0))
            {
                //念のため初期化してから
                Tap_Object = null;
                //タップしたもののTAGを取得
                Tap_Object = tap.gameObject.tag;
                Tap_Name = tap.gameObject.name;
                //霧用の座標取得
                Save_Pos = touchPint_screen;
            }

            //コインだったら
            if (Tap_Object == "Coin")
            {
                //SE
                if (G_SE)
                {
                    Game_SE.GetComponent<Game_SE>().Paper_SE();
                    G_SE = false;
                }
                //文字盤表示してコインを動かす
                Paper.gameObject.SetActive(true);
                Arrow.gameObject.SetActive(false);
                Coin.GetComponent<Coin_Controller>().Move_Coin();
            }
            //Gだったら
            if (Tap_Object == "G")
            {
                switch (Tap_Name)
                {
                    case "G (0)":
                        G[0].GetComponent<G_Controller>().G_Die();
                        Game_SE.GetComponent<Game_SE>().G_Die_SE();
                        break;
                    case "G (1)":
                        G[1].GetComponent<G_Controller>().G_Die();
                        Game_SE.GetComponent<Game_SE>().G_Die_SE();
                        break;
                    case "G (2)":
                        G[2].GetComponent<G_Controller>().G_Die();
                        Game_SE.GetComponent<Game_SE>().G_Die_SE();
                        break;
                    case "G (3)":
                        G[3].GetComponent<G_Controller>().G_Die();
                        Game_SE.GetComponent<Game_SE>().G_Die_SE();
                        break;
                    case "G (4)":
                        G[4].GetComponent<G_Controller>().G_Die();
                        Game_SE.GetComponent<Game_SE>().G_Die_SE();
                        break;
                    case "G (5)":
                        G[5].GetComponent<G_Controller>().G_Die();
                        Game_SE.GetComponent<Game_SE>().G_Die_SE();
                        break;
                    case "G (6)":
                        G[6].GetComponent<G_Controller>().G_Die();
                        Game_SE.GetComponent<Game_SE>().G_Die_SE();
                        break;
                    case "G (7)":
                        G[7].GetComponent<G_Controller>().G_Die();
                        Game_SE.GetComponent<Game_SE>().G_Die_SE();
                        break;
                    case "G (8)":
                        G[8].GetComponent<G_Controller>().G_Die();
                        Game_SE.GetComponent<Game_SE>().G_Die_SE();
                        break;
                    case "G (9)":
                        G[9].GetComponent<G_Controller>().G_Die();
                        Game_SE.GetComponent<Game_SE>().G_Die_SE();
                        break;
                    case "G (10)":
                        G[10].GetComponent<G_Controller>().G_Die();
                        Game_SE.GetComponent<Game_SE>().G_Die_SE();
                        break;
                    case "G (11)":
                        G[11].GetComponent<G_Controller>().G_Die();
                        Game_SE.GetComponent<Game_SE>().G_Die_SE();
                        break;
                    case "G (12)":
                        G[12].GetComponent<G_Controller>().G_Die();
                        Game_SE.GetComponent<Game_SE>().G_Die_SE();
                        break;
                    case "G (13)":
                        G[13].GetComponent<G_Controller>().G_Die();
                        Game_SE.GetComponent<Game_SE>().G_Die_SE();
                        break;
                    case "G (14)":
                        G[14].GetComponent<G_Controller>().G_Die();
                        Game_SE.GetComponent<Game_SE>().G_Die_SE();
                        break;
                }
            }
            //Char_Gだったら
            else if (Tap_Object == "Char_G")
            {
                switch (Tap_Name)
                {
                    case "Char_G (0)":
                        Char_G[0].GetComponent<Char_G_Controller>().G_Die();
                        Game_SE.GetComponent<Game_SE>().G_Die_SE();
                        break;
                    case "Char_G (1)":
                        Char_G[1].GetComponent<Char_G_Controller>().G_Die();
                        Game_SE.GetComponent<Game_SE>().G_Die_SE();
                        break;
                    case "Char_G (2)":
                        Char_G[2].GetComponent<Char_G_Controller>().G_Die();
                        Game_SE.GetComponent<Game_SE>().G_Die_SE();
                        break;
                    case "Char_G (3)":
                        Char_G[3].GetComponent<Char_G_Controller>().G_Die();
                        Game_SE.GetComponent<Game_SE>().G_Die_SE();
                        break;
                    case "Char_G (4)":
                        Char_G[4].GetComponent<Char_G_Controller>().G_Die();
                        Game_SE.GetComponent<Game_SE>().G_Die_SE();
                        break;
                    case "Char_G (5)":
                        Char_G[5].GetComponent<Char_G_Controller>().G_Die();
                        Game_SE.GetComponent<Game_SE>().G_Die_SE();
                        break;
                    case "Char_G (6)":
                        Char_G[6].GetComponent<Char_G_Controller>().G_Die();
                        Game_SE.GetComponent<Game_SE>().G_Die_SE();
                        break;
                    case "Char_G (7)":
                        Char_G[7].GetComponent<Char_G_Controller>().G_Die();
                        Game_SE.GetComponent<Game_SE>().G_Die_SE();
                        break;
                    case "Char_G (8)":
                        Char_G[8].GetComponent<Char_G_Controller>().G_Die();
                        Game_SE.GetComponent<Game_SE>().G_Die_SE();
                        break;
                    case "Char_G (9)":
                        Char_G[9].GetComponent<Char_G_Controller>().G_Die();
                        Game_SE.GetComponent<Game_SE>().G_Die_SE();
                        break;
                    case "Char_G (10)":
                        Char_G[10].GetComponent<Char_G_Controller>().G_Die();
                        Game_SE.GetComponent<Game_SE>().G_Die_SE();
                        break;
                    case "Char_G (11)":
                        Char_G[11].GetComponent<Char_G_Controller>().G_Die();
                        Game_SE.GetComponent<Game_SE>().G_Die_SE();
                        break;
                    case "Char_G (12)":
                        Char_G[12].GetComponent<Char_G_Controller>().G_Die();
                        Game_SE.GetComponent<Game_SE>().G_Die_SE();
                        break;
                    case "Char_G (13)":
                        Char_G[13].GetComponent<Char_G_Controller>().G_Die();
                        Game_SE.GetComponent<Game_SE>().G_Die_SE();
                        break;
                }
            }
            //霧だったら
            else if (Tap_Object == "Mist")
            {
                //新しい座標と比べる
                if (Save_Pos.x > touchPint_screen.x + 100 ||
                    Save_Pos.x < touchPint_screen.x - 100 ||
                    Save_Pos.y > touchPint_screen.y + 100 ||
                    Save_Pos.y < touchPint_screen.y - 100 ||
                    Save_Pos.x > touchPint_screen.x + 70 && Save_Pos.y > touchPint_screen.y + 70 ||
                    Save_Pos.x > touchPint_screen.x + 70 && Save_Pos.y < touchPint_screen.y - 70 ||
                    Save_Pos.x < touchPint_screen.x - 70 && Save_Pos.y > touchPint_screen.y + 70 ||
                    Save_Pos.x < touchPint_screen.x - 70 && Save_Pos.y < touchPint_screen.y - 70)
                {
                    //一定以上であれば少し霧の透明度を下げる
                    Mist.GetComponent<Mist_Controller>().Mist_Delete();
                }
                //今の座標を保存
                Save_Pos = touchPint_screen;
            }
            //血だったら
            else if (Tap_Object == "Blood")
            {
                //新しい座標と比べる
                if (Save_Pos.x > touchPint_screen.x + 100 ||
                    Save_Pos.x < touchPint_screen.x - 100 ||
                    Save_Pos.y > touchPint_screen.y + 100 ||
                    Save_Pos.y < touchPint_screen.y - 100 ||
                    Save_Pos.x > touchPint_screen.x + 70 && Save_Pos.y > touchPint_screen.y + 70 ||
                    Save_Pos.x > touchPint_screen.x + 70 && Save_Pos.y < touchPint_screen.y - 70 ||
                    Save_Pos.x < touchPint_screen.x - 70 && Save_Pos.y > touchPint_screen.y + 70 ||
                    Save_Pos.x < touchPint_screen.x - 70 && Save_Pos.y < touchPint_screen.y - 70)
                {
                    Blood.GetComponent<Blood_Controller>().Blood_Delete();
                }
                //今の座標を保存
                Save_Pos = touchPint_screen;
            }

            //画面から離したとき
            if (Input.GetMouseButtonUp(0))
            {
                //文字盤をしまってコインを戻す
                Paper.gameObject.SetActive(false);
                Arrow.gameObject.SetActive(true);
                Coin.GetComponent<Coin_Controller>().Return_Coin();

                //コインと重なってたObjectを確認する
                Get_Char = Coin.GetComponent<Coin_Controller>().Tap_Char;
                G_SE = true;


                //合ってたら
                if (Get_Char == Answer[A_Num[Q_Num]])
                {
                    Answer_True();
                }
                //違ったら
                else if (Get_Char != null && Get_Char != Answer[A_Num[Q_Num]])
                {
                    Answer_False();
                }
            }
            Coin.GetComponent<Coin_Controller>().Null();
        }
    }

    void Answer_True()
    {
        //SE
        Game_SE.GetComponent<Game_SE>().Char_SE();
        GetComponent<Time_Controller>().Time_Stopper = true;

        //文字の表示
        Char[Q_Num].gameObject.SetActive(true);
        Get_Char = null;
        //スコア更新
        Score_Con.GetComponent<Score_Controller>().Add_Score();
        //FadeOut
        Fade.gameObject.SetActive(true);
    }
    void Answer_False()
    {
        //SE
        Game_SE.GetComponent<Game_SE>().Life_SE();

        //ライフ減らす
        life -= 1;
        Life[life].gameObject.SetActive(false);
        Get_Char = null;

        //ライフがなくなったら
        if (life == 0)
        {
            //シーンカウント初期化
            Scene_Count = 0;
            //スコアの初期化
            Score_Con.GetComponent<Score_Controller>().Del_Score();
            //ゲームオーバーへ
            SceneManager.LoadScene("GameOverScene");
        }
    }

    void Next_Scene()
    {
        if (Fade.GetComponent<Fade_Out>().Next == true)
        {
            SceneManager.LoadScene("StoryScene");
        }
    }

    void Time_Over()
    {
        if (Time_Con.GetComponent<Time_Controller>().Time_Over == true)
        {
            Scene_Count = 0;
            //スコアの初期化
            Score_Con.GetComponent<Score_Controller>().Del_Score();
            SceneManager.LoadScene("GameOverScene");
        }
    }

    //初期設定
    void Start()
    {
        life = 3;
        Scene_Count += 1;
        Answer_Set();
        //G_Spawn();
        spriteRenderer = Char[Q_Num].GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        Next_Scene();
        Time_Over();
        Tap();
    }
}
