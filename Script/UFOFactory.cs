using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using UnityEngine;

struct Rule {

}

public class UFOFactory : MonoBehaviour
{
    private List<GameObject> uselist;
    private List<GameObject> freelist;
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("UFOFactory Start!");
        uselist = new List<GameObject>();
        freelist = new List<GameObject>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public GameObject GetUFO(UFOData data){
        GameObject ufo = null;
        bool found = false;
        if(freelist.Count != 0){
            foreach (GameObject o in freelist){
                if(o.tag == data.color){
                    ufo = o;
                    freelist.Remove(ufo);
                    found = true;
                    break;
                }
            }
        }
        if(found == false){
            ufo = Instantiate<GameObject>(
                Resources.Load<GameObject>("prefabs/" + data.color),
                Vector3.up,Quaternion.Euler(0,0,180f));
        }
        ufo.tag = data.color;
        ufo.name = data.score.ToString();
        ufo.GetComponent<Rigidbody>().mass = data.mass;
        ufo.transform.localScale = new Vector3(data.size,data.size,data.size);
        uselist.Add(ufo);
        return ufo;
    }

    public void FreeUFO(GameObject ufo){
        foreach(GameObject o in uselist){
            if(o.GetInstanceID() == ufo.GetInstanceID()){
                o.SetActive(false);
                uselist.Remove(o);
                freelist.Add(o);
                break;
            }
        }
    }
}
