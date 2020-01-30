using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    bool Up = false;
    public GameObject Fade;

    // SEを定義
    public AudioClip SE;
    AudioSource aud;

    void Next_Scene()
    {
        if (Fade.GetComponent<Fade_Out>().Next == true)
        {
            SceneManager.LoadScene("MovieScene");
        }
    }
    void Start()
    {
        Game_Controller.G_Switch = true;
    }

    // Update is called once per frame
    void Update()
    {
        Next_Scene();
        if (Up == false)
        {
            // クリックでSE発動
            if (Input.GetMouseButtonUp(0))
            {
                Up = true;
                aud = gameObject.GetComponent<AudioSource>();
                aud.PlayOneShot(SE);
                Debug.Log("音が鳴ってる筈です");
            }
        }
        

        // SE終了と同時にGameシーンへ遷移
        if (Up == true && !aud.isPlaying)
        {
            Fade.gameObject.SetActive(true);
        }
    }        
}
