using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AnimatiaTarget : MonoBehaviour {
	public float t;
	Quaternion startRotate, endRotate;
	bool counterOverload;
	float factorLR;
	int factorForward;

	void Start () {

		factorLR = Random.Range (1f + PlayerPrefs.GetFloat("SpeedTarget"), 2f + PlayerPrefs.GetFloat("SpeedTarget"));
		factorForward = Random.Range (150 + PlayerPrefs.GetInt("ScatterTarget"), 200 + PlayerPrefs.GetInt("ScatterTarget"));

	}


	void Update () {

		endRotate = Quaternion.Euler (transform.rotation.x, 180, transform.rotation.z);
		startRotate = Quaternion.Euler (transform.rotation.x, 0, transform.rotation.z);

		if (t <= 1 && !counterOverload)
		{
			t += 1.5f * Time.deltaTime * factorLR;
		}
		else counterOverload = true;

		if (t > 0 && counterOverload)
		{
			t -= 1.5f * Time.deltaTime * factorLR;
		}
		else counterOverload = false;

		transform.rotation = Quaternion.Lerp(startRotate, endRotate, t);

		transform.Translate (transform.forward * factorForward * Time.deltaTime);

	}
}
