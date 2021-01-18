using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ControlTimer : MonoBehaviour {
	
	public Text txtTime;
	int h, m, CountDeadTarget;
	float s;
	string hours, minutes, seconds;

	void Update () {
		s += 1 * Time.deltaTime;

		if (s >= 60) {
			s = 0;
			m++;
		}
		if (m > 59) {
			m = 0;
			h++;
		}
		if (h == 24) {
			h = 0;
		}

		if (s < 10) {
			seconds = "0" + s.ToString ("F0");
		} else {
			seconds = s.ToString ("F0");
		}

		if (m < 10) {
			minutes = "0" + m;
		} else {
			minutes = m.ToString ("F0");
		}

		if (h < 10) {
			hours = "0" + h;
		} else {
			hours = h.ToString ("F0");
		}

		txtTime.text = hours + ":" + minutes + ":" + seconds;
	}
}
