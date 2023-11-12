using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreController : MonoBehaviour
{
    public int total_score;
    public int now_score;
    public int score_to_next;
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("ScoreController Start!");
        now_score = 0;
        score_to_next = 50;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AddScore(GameObject ufo){
        int add_score;
        int.TryParse(ufo.name,out add_score);
        now_score += add_score;
        total_score += add_score;
        if(now_score >= score_to_next){
            Singleton<FirstController>.Instance.Brake();
        }
        Singleton<UserGUI>.Instance.UpdateScore();
    } 
}
