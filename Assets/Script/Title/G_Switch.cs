using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class G_Switch : MonoBehaviour
{
    public void OnClick()
    {
        Game_Controller.G_Switch = false;
        Debug.Log("aaaa");
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
