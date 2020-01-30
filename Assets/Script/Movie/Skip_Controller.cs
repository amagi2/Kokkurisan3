using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using UnityEngine.SceneManagement;

public class Skip_Controller : MonoBehaviour
{
    public GameObject Fade;         //FadeOut
    public void OnClick()
    {
        //FadeOut
        Fade.gameObject.SetActive(true);

    }

    void Start()
    {

    }

    void Update()
    {

    }
}
