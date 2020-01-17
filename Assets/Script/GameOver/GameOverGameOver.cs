using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverGameOver : MonoBehaviour
{
    public GameObject Fade;

    //FadeOutにてNextがTrueになったら次のシーンへ
    void Next_Scene()
    {
        if (Fade.GetComponent<Fade_Out>().Next == true)
        {
            SceneManager.LoadScene("TitleScene");
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonUp(0))
        {
            Fade.gameObject.SetActive(true);
        }
        Next_Scene();
    }
}
