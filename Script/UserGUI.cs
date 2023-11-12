using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UserGUI : MonoBehaviour
{
    public int state;
    private int width = Screen.width / 5;
    private int height = Screen.height / 15;
    private GUIStyle titleStyle;
    private int guiScore;
    private int guiTime;
    private IUserAction action;
    // Start is called before the first frame update
    void Start()
    {
        state = 0;
        titleStyle = new GUIStyle();
        titleStyle.normal.textColor = Color.black;
        titleStyle.normal.background = null;
        titleStyle.fontSize = 50;
        titleStyle.alignment = TextAnchor.MiddleCenter;
        guiScore = 0;
        guiTime = 50;
        action = SSDirector.getInstance().currentSceneController as IUserAction;
    }

    // Update is called once per frame
    void OnGUI()
    {
        if (state == 0){
            GUI.Label(new Rect(Screen.width / 2 - width * 0.5f, Screen.height * 0.1f, width, height), "Hit UFO", titleStyle);
            bool button = GUI.Button(new Rect(Screen.width / 2 - width * 0.5f, Screen.height * 3 / 7, width, height), "Start");
            if(button){
                SSDirector.getInstance().currentSceneController.LoadResources ();
                state = 1;
           }
        }
        if (state == 1){
            GUI.Label(new Rect(Screen.width / 2,0,width,height),"Left Time: "+ guiTime.ToString());
            GUI.Label(new Rect(Screen.width / 2 - width,0,width,height),"Now Score: "+guiScore.ToString());
        }
        if(state == 2){
            GUI.Label(new Rect(Screen.width / 2 - width * 0.5f, Screen.height * 0.1f, width, height), "A Round Finish!", titleStyle);
            bool button = GUI.Button(new Rect(Screen.width / 2 - width * 0.5f, Screen.height * 3 / 7, width, height), "Next Round");
            if(button){
                action.Next();
           }
        }
        if(state == 3){
            GUI.Label(new Rect(Screen.width / 2 - width * 0.5f, Screen.height * 0.1f, width, height), "Final Score: "+ guiScore.ToString(), titleStyle);
            bool button = GUI.Button(new Rect(Screen.width / 2 - width * 0.5f, Screen.height * 3 / 7, width, height), "Reset");
            if(button){
                action.Reset();
            }
        }
    }

    public void UpdateScore(){
        guiScore = Singleton<ScoreController>.Instance.total_score;
    }
    public void UpdateTime(){
        guiTime = 50-(int)Singleton<RoundController>.Instance.total_time;
    }
}
