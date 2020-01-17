using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Mist_Controller : MonoBehaviour
{
    [SerializeField]
    private SpriteRenderer sprite;
    private float Del_a = 0.04f;
    private float Add_a = 0.01f;
    private float a = 1;

    public void Mist_Delete()
    {
        if (a > 0)
        {
            var color = sprite.color;
            a -= Del_a;
            color.a = a;
            sprite.color = color;
        }
    }
    public void Mist_Add()
    {
        if (a < 1)
        {
            var color = sprite.color;
            a += Add_a;
            color.a = a;
            sprite.color = color;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Mist_Add();
    }
}
