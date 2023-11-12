using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UFOActionManager : SSActionManager
{
    private Vector3[] spawn;

    // Start is called before the first frame update
    new void Start()
    {
        spawn = new Vector3[]{
            new Vector3(5,1f,5),
            new Vector3(-5,1f,5),
            new Vector3(5,1f,-5),
            new Vector3(-5,1f,-5),
        };
    }

    // Update is called once per frame
    new void Update()
    {
        base.Update();
    }

    public void setMove(GameObject ufo, float speedfactor){
        int spawnindex = Random.Range(0,4);
        UnityEngine.Vector3 velocity = Vector3.zero;
        switch(spawnindex){
            case 0:
                velocity = new UnityEngine.Vector3(
                    Random.Range(-3,-1)*speedfactor,Random.Range(3,6),Random.Range(-3,-1)*speedfactor
                );
                break;
            case 1:
                velocity = new UnityEngine.Vector3(
                    Random.Range(1,3)*speedfactor,Random.Range(3,6),Random.Range(-3,-1)*speedfactor
                );
                break;
            case 2:
                velocity = new UnityEngine.Vector3(
                    Random.Range(-3,-1)*speedfactor,Random.Range(3,6),Random.Range(1,3)*speedfactor
                );
                break;
            case 3:
                velocity = new UnityEngine.Vector3(
                    Random.Range(1,3)*speedfactor,Random.Range(3,6),Random.Range(1,3)*speedfactor
                );
                break;    
        }
        FlyAction fly = FlyAction.GetFlyAction(velocity, spawn[spawnindex]+new Vector3(Random.Range(-1,1),0,Random.Range(-1,1)));
        RunAction(ufo, fly);
    }
}
