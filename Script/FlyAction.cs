using System.Collections;
using System.Collections.Generic;
using UnityEditor.Callbacks;
using UnityEngine;

public class FlyAction : SSAction
{
    private Vector3 velocity;
    private Vector3 spawnpos;
    private Rigidbody rb;
    // Start is called before the first frame update
    public static FlyAction GetFlyAction(Vector3 velocity, Vector3 spawnpos){
        FlyAction action = ScriptableObject.CreateInstance<FlyAction> ();
        action.velocity = velocity;
        action.spawnpos = spawnpos;
        return action;
    }
    public override void Start()
    {
        gameobject.transform.position = spawnpos;
        gameobject.SetActive(true);
        rb = gameobject.GetComponent<Rigidbody>();
        //rb.MovePosition(spawnpos);
        rb.velocity = velocity;
    }

    public override void Update()
    {
        if(gameobject.transform.position.y <= 0){
            Debug.Log(gameobject.transform.position.y);
            Singleton<UFOFactory>.Instance.FreeUFO(gameobject);
            this.destory = true;
        }
    }

}
