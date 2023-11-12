using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.Search;
using UnityEngine;

public class FirstController : MonoBehaviour, ISceneController, IUserAction {

	public UFOActionManager actionManager;
	public RoundController roundController;
	public ScoreController scoreController;
	public UFOFactory ufoFactory;

	public bool isgameover;
	public bool isnext;
	public Camera cam;
	public GameObject ground;

	// the first scripts
	void Awake () {
		SSDirector director = SSDirector.getInstance ();
		director.setFPS (60);
		director.currentSceneController = this;
		Debug.Log ("awake FirstController!");
		//actionManager = gameObject.AddComponent<CCActionManager>();
	}
	 
	// loading resources for first scence
	public void LoadResources () {
		Debug.Log("Hello there!");
		ground = Instantiate<GameObject>(
            Resources.Load<GameObject> ("prefabs/ground"),
            Vector3.zero, Quaternion.identity);
		ground.name = "ground";
		roundController = gameObject.AddComponent<RoundController>();
		ufoFactory = gameObject.AddComponent<UFOFactory>();
		actionManager = gameObject.AddComponent<UFOActionManager>();
		scoreController = gameObject.AddComponent<ScoreController>();
		isgameover = false;
		isnext = false;
		Debug.Log("Hello there2!");
	}
	
	public void Pause () {
		throw new System.NotImplementedException ();
	}

	public void Resume () {
		throw new System.NotImplementedException ();
	}

	#region IUserAction implementation
	public void GameOver () {
		isgameover = true;
		roundController.ongame = false;
		roundController.total_time = 0;
		roundController.time = 0;
		Singleton<UserGUI>.Instance.state = 3;
	}

	public void Brake() {
		isnext = true;
		roundController.ongame = false;
		roundController.time = 0;
		roundController.total_time = 0;
		scoreController.now_score = 0;
		Singleton<UserGUI>.Instance.state = 2;
	}

	public void Next(){
		isnext = false;
		roundController.round++;
		roundController.ongame = true;
		roundController.time = 0;
		roundController.total_time = 0;
		Singleton<UserGUI>.Instance.state = 1;
	}
	public void Reset() {
		Debug.Log("Reset!");
		isgameover = false;
		isnext = false;
		roundController.ongame = true;
		roundController.round = 1;
		roundController.time = 0;
		roundController.ongame = true;
		scoreController.now_score = 0;
		scoreController.total_score = 0;
		Singleton<UserGUI>.Instance.state = 1;
	}
	#endregion


	// Use this for initialization
	void Start () {
		//give advice first
	}
	
	// Update is called once per frame
	void Update () {
		//give advice first
		if (!isgameover &&  !isnext && Input.GetButtonDown("Fire1")) {
			Vector3 mp = Input.mousePosition;
			Camera ca;
			if (cam != null ) ca = cam.GetComponent<Camera> (); 
			else ca = Camera.main;
			Ray ray = ca.ScreenPointToRay(Input.mousePosition);
			RaycastHit hit;
			if (Physics.Raycast(ray, out hit)) {
				if(hit.collider.gameObject != null && hit.collider.gameObject.name != "ground"){
					GameObject ufo = hit.collider.gameObject;
					ufoFactory.FreeUFO(ufo);
					scoreController.AddScore(ufo);
				}
			}
		}
	}

}
