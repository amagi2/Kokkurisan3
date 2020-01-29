using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Test_Controller : MonoBehaviour
{
    private string Tap_Object;  //タップ先のオブジェクト(のタグ)
    private string Tap_Name;    //タップ先のオブジェクトの名前
    

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
                Debug.Log(Tap_Object);
                Tap_Name = tap.gameObject.name;
                Debug.Log(Tap_Name);
            }
        }
    }

    

    //初期設定
    void Start()
    {
        
    }

    void Update()
    {
        Tap();
    }
}
