using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenuScript : MonoBehaviour {

	public Button btnChuesLevels, btnOptions, btnQuit;

	void Start () {

		btnChuesLevels.onClick.AddListener (delegate {
		
			SceneManager.LoadScene("ChuesLevel");
		
		});

		btnOptions.onClick.AddListener (delegate {
		
			SceneManager.LoadScene("Options");
		
		});

		btnQuit.onClick.AddListener (delegate {

			Application.Quit();
		
		});
	}

}
