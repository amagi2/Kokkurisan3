using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Blood_Controller : MonoBehaviour
{
    [SerializeField]
    private SpriteRenderer sprite;
    private float Del_a = 0.005f;
    private float a = 1;

    public void Blood_Delete()
    {
        if (a > 0)
        {
            var color = sprite.color;
            a -= Del_a;
            color.a = a;
            sprite.color = color;
        }else if (a <= 0)
        {
            Destroy(this.gameObject);
        }
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
