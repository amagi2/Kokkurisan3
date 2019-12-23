using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin_Controller : MonoBehaviour
{
    private Vector3 Tap_Pos;//タップ座標
    private Vector3 WorldPointPos;//画面を起点とした世界座標
    public string Tap_Char;//選択した文字をゲームコントローラーに送る

    //コイン移動
    public void Move_Coin()
    {
        Touch t = Input.GetTouch(0);
        //タップ確認
        Tap_Pos = new Vector3(t.position.x, t.position.y, 0);
        WorldPointPos = Camera.main.ScreenToWorldPoint(Tap_Pos);
        //Z軸は固定
        WorldPointPos.z = 0;
        //コインをタップの座標に移動
        gameObject.transform.position = WorldPointPos;
    }

    //コインを定位置に戻す
    public void Return_Coin()
    {
        gameObject.transform.position = new Vector3(-3, -1, 0);
    }

    //重なってる間は名前を取得
    private void OnCollisionStay2D(Collision2D collision)
    {
        Tap_Char = collision.gameObject.name;
    }

    //離れたら空にする
    private void OnCollisionExit2D(Collision2D collision)
    {
        Null();
    }

    //Tap_Charを空にする
    public void Null()
    {
        Tap_Char = null;
    }

    //初期設定
    void Start()
    {
        Null();
    }

    void Update()
    {

    }
}
