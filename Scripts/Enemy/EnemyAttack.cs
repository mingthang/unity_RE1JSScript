using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour {

    public Animator anim;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void OnTriggerStay(Collider col) {
        anim.SetBool("CanAttack", true);
        print("hit");
    }
    public void OnTriggerExit(Collider col) {
        anim.SetBool("CanAttack", false);
        print("you're safe");
    }

}
