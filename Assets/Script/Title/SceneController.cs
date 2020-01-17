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

    private void Next_Scene()
    {

    }

    // Update is called once per frame
    void Update()
    {
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
