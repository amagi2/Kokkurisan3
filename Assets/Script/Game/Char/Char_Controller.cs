using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Char_Controller : MonoBehaviour
{
    [SerializeField]
    private GameObject charObject;//文字
    [SerializeField]
    private GameObject Back_UI;//文字背景  

    //コインが重なったら
    private void OnCollisionStay2D(Collision2D collision)
    {
        charObject.GetComponent<Char>().Scale();
        charObject.GetComponent<Char>().Move();
        charObject.GetComponent<Char>().Layer();
        Back_UI.GetComponent<Back_UI>().UI();
        //コインから指輪離したら
        if (Input.GetMouseButtonUp(0))
        {
            charObject.GetComponent<Char>().ReScale();
            charObject.GetComponent<Char>().ReMove();
            charObject.GetComponent<Char>().ReLayer();
            Back_UI.GetComponent<Back_UI>().DeleteUI();
        }
    }

    //コインが離れたら
    private void OnCollisionExit2D(Collision2D collision)
    {       
        charObject.GetComponent<Char>().ReScale();
        charObject.GetComponent<Char>().ReMove();
        charObject.GetComponent<Char>().ReLayer();
        Back_UI.GetComponent<Back_UI>().DeleteUI();
    }



    void Start()
    {

    }

    void Update()
    {
        
    }
}
