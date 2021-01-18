using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class ChangeLevel : MonoBehaviour {

	public Button btnOk, btnCountTarget, btnSpeedTarget;
	int countTarget, speedFactor;
	public Text CountTargetText, speedText, dostigenieText;

	void Start () {
	
		dostigenieText.text = "Your reiting: " + PlayerPrefs.GetInt ("CountDeadTarget");


		btnOk.onClick.AddListener (delegate {

			SceneManager.LoadScene("GameLevel1Scene");
		
		});

		btnCountTarget.onClick.AddListener (delegate {
			countTarget += 5;
			if ((countTarget > 50) || (countTarget <= 0)){
				countTarget = 5;
			}
			CountTargetText.text = countTarget.ToString();
			PlayerPrefs.SetInt("CountTarget", countTarget);
		});

		btnSpeedTarget.onClick.AddListener (delegate {
			speedFactor++;

			if (speedFactor == 1){
				PlayerPrefs.SetFloat("SpeedTarget", 0f);
				PlayerPrefs.SetInt("ScatterTarget", 0);
				speedText.text = "normal";
			}
			if (speedFactor == 2){
				PlayerPrefs.SetFloat("SpeedTarget", 0.5f);
				PlayerPrefs.SetInt("ScatterTarget", 100);
				speedText.text = "master";			
			}
			if (speedFactor == 3){
				PlayerPrefs.SetFloat("SpeedTarget", 1.5f);
				PlayerPrefs.SetInt("ScatterTarget", 300);
				speedText.text = "GOD";
			}
			if (speedFactor >= 4){
				PlayerPrefs.SetFloat("SpeedTarget", -0.5f);
				PlayerPrefs.SetInt("ScatterTarget", -50);
				speedText.text = "noob";
				speedFactor = 0;
			}

		});
	
	}

}
