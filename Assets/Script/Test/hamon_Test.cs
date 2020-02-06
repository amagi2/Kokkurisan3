using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class hamon_Test : MonoBehaviour
{
    [SerializeField]
    private SpriteRenderer sprite;
    [SerializeField]
    public GameObject game;
    [SerializeField]
    public GameObject game2;
    [SerializeField]
    public GameObject game3;

    private float Add_a = 0.015f;
    private float a = 1f;

    public bool Next = false;

    public void FadeOut()
    {
        var color = sprite.color;
        Transform transform = game.transform;
        Vector3 localScale = transform.localScale;
        localScale.x += Add_a;
        localScale.y += Add_a;
        a -= Add_a;
        color.a = a;
        sprite.color = color;
        transform.localScale = localScale;
        if (a < 0.8 && this.gameObject.name == "watermark")
        {
            game2.gameObject.SetActive(true);
        }
        if (a < 0.8 && this.gameObject.name == "watermark (1)")
        {
            game3.gameObject.SetActive(true);
        }
    }

    void Update()
    {
        FadeOut();
    }
}
