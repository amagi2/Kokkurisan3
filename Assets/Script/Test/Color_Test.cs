using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Color_Test : MonoBehaviour
{
    [SerializeField]
    private Image image;
    private float a;

    void Color()
    {
        var color = image.color;
        color.a = a;
        image.color = color;
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
