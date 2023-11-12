using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;

public class RoundController : MonoBehaviour
{
    public int round;
    private float shootdelay;
    
    public float time;
    public float total_time;

    public bool ongame;
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("RoundController Start!");
        round = 1;
        shootdelay = 2;
        ongame = true;
        time = 0;
        total_time = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if(ongame){
            time += Time.deltaTime;
            total_time += Time.deltaTime;
            if(time > 1)
                Singleton<UserGUI>.Instance.UpdateTime();
            if(time > shootdelay){
                int times = Random.Range(1, 5);
                for (int i = 0;i<times;i++)
                    createUFO();
                time = 0;
            }
            if(total_time > 50){
                Singleton<FirstController>.Instance.GameOver();
            }
        }
    }

    public void createUFO(){
        UFOData data = new UFOData();
        data.size = Random.Range(2,5);
        int color = Random.Range(0,3);
        switch(color){
            case 0:
                data.color = "Red";break;
            case 1:
                data.color = "Blue";break;
            case 2:
                data.color = "White";break;
        }
        data.mass = Random.Range(1,2);
        float speedfactor = (float)Random.Range(1 + (float)(0.5*round < 3.5 ? 0.5*round : 3.5),5);
        data.score = (int)(speedfactor * 5 / data.size);
        GameObject ufo = Singleton<UFOFactory>.Instance.GetUFO(data);
        Singleton<UFOActionManager>.Instance.setMove(ufo,speedfactor);
    }
}
