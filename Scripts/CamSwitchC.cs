using System.Collections;
using System.Collections.Generic;
using UnityEngine;




public class CamSwitchC : MonoBehaviour {
	
	public GameObject camFwd;
	public GameObject camFwdBG;
	public GameObject camBwd;
	public GameObject camBwdBG;


	void OnTriggerEnter (Collider col) {
		if (col.tag == "Player") {
			camFwd.SetActive (true);
			camBwd.SetActive (false);
			camFwdBG.SetActive (true);
			camBwdBG.SetActive (false);
		}
	}
}
