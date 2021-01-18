using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class InstantietGameObj : MonoBehaviour {
	public Button PausePlay, toMainMenu, NewGame;
	public Camera camera;
	public RaycastHit hit;
	public GameObject target, PanelG_O;
	public	GameObject[] obj;// = new List<GameObject>();// = new GameObject[5];
	public Transform terain;
	public Text txtCount;
	int CountDeadTarget;
	bool flag, flagForBtn;
	ChangeLevel dostup;

	void Awake(){
		obj = new GameObject[PlayerPrefs.GetInt("CountTarget")];
	}

	void Start(){
		Debug.LogError (PlayerPrefs.GetInt("CountTarget"));

		obj [0] = Instantiate (target, new Vector3 (Random.Range (85, 285), 0, Random.Range (85, 285)), new Quaternion (0, 0, 0, 0), terain);

		dostup = FindObjectOfType<ChangeLevel> ();

		StartCoroutine (TimeRespaunetarget());

		toMainMenu.onClick.AddListener (delegate {
			
			SceneManager.LoadScene("MainMenu");
	
		});

		NewGame.onClick.AddListener (delegate {
		
			SceneManager.LoadScene("GameLevel1Scene");
		
		});

		PausePlay.onClick.AddListener (delegate {
		
			flagForBtn = !flagForBtn;

			if (flagForBtn == true){
			
				Time.timeScale = 0;

				PausePlay.transform.GetChild(0).GetComponent<Text>().text = "Play";
				for (int i = 0; i < obj.Length; i++){
					obj [i].SetActive (false);
				}
				/*
				obj [0].SetActive (false);
				obj [1].SetActive (false);
				obj [2].SetActive (false);
				obj [3].SetActive (false);
				obj [4].SetActive (false);
*/
}
			else {
			
				Time.timeScale = 1;

				PausePlay.transform.GetChild(0).GetComponent<Text>().text = "Pause";
				for (int i = 0; i < obj.Length; i++){
					obj [i].SetActive (true);
				}
				/*
				obj [0].SetActive (true);
				obj [1].SetActive (true);
				obj [2].SetActive (true);
				obj [3].SetActive (true);
				obj [4].SetActive (true);
				*/
			}
		});

	}

	void Update() {

		if (Input.GetMouseButtonDown (0)) {

			if (Physics.Raycast (camera.ScreenPointToRay (Input.mousePosition), out hit, 500)) {

				if (hit.transform.gameObject.layer == 9) {

					for (int i = 0; i < obj.Length; i++){
						if (Vector3.Distance (hit.transform.position, obj [i].transform.position) <= 25) {
							Destroy (obj [i]);
							CountDeadTarget++;

							StartCoroutine (TimeRespaunetarget ());
						}
					}

					/*
					if (Vector3.Distance (hit.transform.position, obj [0].transform.position) <= 25) {
		
						Destroy (obj [0]);
						CountDeadTarget++;
					
						StartCoroutine (TimeRespaunetarget ());
					
					} else {
					
						if (Vector3.Distance (hit.transform.position, obj [1].transform.position) <= 25) {
						
							Destroy (obj [1]);
							CountDeadTarget++;
						
							StartCoroutine (TimeRespaunetarget ());
							
						} else {

							if (Vector3.Distance (hit.transform.position, obj [2].transform.position) <= 25) {
							
								Destroy (obj [2]);
								CountDeadTarget++;
							
								StartCoroutine (TimeRespaunetarget ());
							
							} else {
							
								if (Vector3.Distance (hit.transform.position, obj [3].transform.position) <= 25) {
								
									Destroy (obj [3]);
									CountDeadTarget++;
						
									StartCoroutine (TimeRespaunetarget ());
								
								} else {
								
									if (Vector3.Distance (hit.transform.position, obj [4].transform.position) <= 25) {
									
										Destroy (obj [4]);
										CountDeadTarget++;

										StartCoroutine (TimeRespaunetarget ());
									}
								}
							}
						}
					}
					*/
				}
			}
		}
			
					/// Count Dead Target \\\
					txtCount.text = "Count: " + CountDeadTarget.ToString ();

		if ((CountDeadTarget % 10) == 0 && flag == false ){

			StartCoroutine (TimeRespaunetarget ());
		//	flag = false;
		}
		for (int i = 0; i < obj.Length; i++){
			if (obj [i].transform.position.z >= 500) {
				
				for (int j = 0; j < obj.Length; j++) {
					PanelG_O.SetActive (true);
						obj [j].SetActive (false);
				}
				if (PlayerPrefs.GetInt ("CountDeadTarget") < CountDeadTarget) {
					PlayerPrefs.SetInt ("CountDeadTarget", CountDeadTarget);
				}
			}
			/*
			obj [0].SetActive (false);
			obj [1].SetActive (false);
			obj [2].SetActive (false);
			obj [3].SetActive (false);
			obj [4].SetActive (false);
*/

		}
				}
		
	IEnumerator TimeRespaunetarget(){

		flag = true;
	//	int x = Random.Range (85, 285);
	//	int z = Random.Range (85, 285);

		// obj = Instantiate (target, new Vector3 (x, 0, z), new Quaternion (0, 0, 0, 0), terain);
		yield return new WaitForSeconds (3);

		StartCoroutine (TimeRespaunetarget());

		for (int i = 0; i < obj.Length; i++) {
			int x = Random.Range (85, 285);
			int z = Random.Range (85, 285);
			if ((obj [i] == null) && (flag == true)) {
				Debug.LogError (i);
			obj [i] = Instantiate (target, new Vector3 (x, 0, z), new Quaternion (0, 0, 0, 0), terain);
				flag = false;
			} 

		}
			



		/*
		if (obj [0] == null) {

			obj [0] = Instantiate (target, new Vector3 (x, 0, z), new Quaternion (0, 0, 0, 0), terain);

		} else {

			if (obj [1] == null) {

				obj [1] = Instantiate (target, new Vector3 (x, 0, z), new Quaternion (0, 0, 0, 0), terain);
			
			} else {

				if (obj [2] == null) {
				
					obj [2] = Instantiate (target, new Vector3 (x, 0, z), new Quaternion (0, 0, 0, 0), terain);
				
				} else {
				
					if (obj [3] == null) {
				
						obj [3] = Instantiate (target, new Vector3 (x, 0, z), new Quaternion (0, 0, 0, 0), terain);
				
					} else {
				
						if (obj [4] == null) {
				
							obj [4] = Instantiate (target, new Vector3 (x, 0, z), new Quaternion (0, 0, 0, 0), terain);
							}
						}	
					}	
				}	
			}
*/
		yield break;
	}
}
