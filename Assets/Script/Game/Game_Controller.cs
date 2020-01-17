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

    private string Tap_Object;  //タップ先のオブジェクト(のタグ)
    private string Tap_Name;    //タップ先のオブジェクトの名前
    private string Get_Char;    //Coin_Controllerから文字を受け取る

    [SerializeField]
    private GameObject[] Question = new GameObject[18]; //問題（オブジェクト）
    [SerializeField]
    private GameObject[] Char = new GameObject[18];     //答え（表示）

    private int Q_Num;//問題（設定）

    //答え（選択）
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
        11,2,37//し、う、よ
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
    private string[] G_Name = { "G (0)", "G (1)", "G (2)", "G (3)", "G (4)", "G (5)", "G (6)", "G (7)", "G (8)", "G (9)", "G (10)", "G (11)", "G (12)", "G (13)", "G (14)" };
    private int G_Num;

    //文字上のゴキブリ
    [SerializeField]
    private GameObject[] Char_G = new GameObject[15];
    private string[] Char_G_Name = { "Char_G (0)", "Char_G (1)", "Char_G (2)", "Char_G (3)", "Char_G (4)", "Char_G (5)", "Char_G (6)", "Char_G (7)", "Char_G (8)", "Char_G (9)", "Char_G (10)", "Char_G (11)", "Char_G (12)", "Char_G (13)", "Char_G (14)" };
    private int Char_G_Num;

    //霧関連
    [SerializeField]
    private GameObject Mist;    //霧
    private Vector3 Save_Pos;   //座標用比較座標セーブ


    //ゴキブリ召喚
    void G_Spawn()
    {
        for (int a = (Scene_Count) * 5 - 1; a > -1; a--) 
        {
            G[a].gameObject.SetActive(true);
        }
    }

    //問題設定
    void Answer_Set()
    {
        //何シーンか確認、シーンに合った問題をランダムで選ぶ
        switch (Scene_Count)
        {
            case 1:
                Q_Num = Random.Range(0, 3);
                break;
            case 2:
                Q_Num = Random.Range(3, 6);
                break;
            case 3:
                Q_Num = Random.Range(6, 9);
                break;
            case 4:
                Q_Num = Random.Range(9, 12);
                break;
            case 5:
                Q_Num = Random.Range(12, 15);
                break;
            case 6:
                Q_Num = Random.Range(15, 18);
                break;
        }
        //選んだ問題を表示する
        Question[Q_Num].gameObject.SetActive(true);
    }


    //タップ
    void Tap()
    {
        //タップを認識
        if (Input.touchCount > 0)//タッチ数が１以上の時
        {
            //タップした座標を確認する処理
            //タッチの個数確認
            Touch t = Input.GetTouch(0);

            Vector3 touchPint_screen = new Vector3(t.position.x, t.position.y, 0);
            //カメラ(画面)を基準に座標を設定する
            Vector3 touchPint_world = Camera.main.ScreenToWorldPoint(touchPint_screen);
            Collider2D tap = Physics2D.OverlapPoint(touchPint_world);

            //画面に触れたとき
            if (Input.GetMouseButtonDown(0))
            {
                Tap_Object = null;
                //タップしたもののTAGを取得
                Tap_Object = tap.gameObject.tag;
                Tap_Name = tap.gameObject.name;
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
                for (G_Num = 0; G_Num < 15; G_Num++)
                {
                    if (Tap_Name == G_Name[G_Num])
                    {
                        G[G_Num].GetComponent<G_Controller>().G_Die();
                        Game_SE.GetComponent<Game_SE>().G_Die_SE();
                    }
                }
            }
            //Char_Gだったら
            else if (Tap_Object == "Char_G")
            {
                
                for (Char_G_Num = 0; Char_G_Num < 15; Char_G_Num++)
                {
                    if (Tap_Name == Char_G_Name[Char_G_Num])
                    {
                        Char_G[Char_G_Num].GetComponent<Char_G_Controller>().G_Die();
                        Game_SE.GetComponent<Game_SE>().G_Die_SE();
                    }
                }
            }
            //霧だったら
            else if (Tap_Object == "Mist")
            {
                Debug.Log("みすと");
                
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
                    /*ミストで下げる*/
                    Debug.Log("Misuto!!!");
                }
                //今の座標を保存
                Save_Pos = touchPint_screen;
            }
            //なんかだったら

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

        //文字の表示
        Char[Q_Num].gameObject.SetActive(true);
        Get_Char = null;
        //6問目が終わったら初期化
        if (Scene_Count == 6)
        {
            Scene_Count = 0;
        }
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

    //初期設定
    void Start()
    {
        life = 3;
        Scene_Count += 1;
        Answer_Set();
        G_Spawn();
        spriteRenderer = Char[Q_Num].GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        Next_Scene();
        Tap();
    }
}
