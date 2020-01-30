using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Score_Controller : MonoBehaviour
{
    private float score;
    private void Add_Time()
    {
        score += Time.deltaTime;
    }
    public void Add_Score()
    {
        GameClear.New_Score += score;
    }
    public void Del_Score()
    {
        GameClear.New_Score = 0;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Add_Time();
    }
}
