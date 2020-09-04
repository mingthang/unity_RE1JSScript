using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankControl : MonoBehaviour
{
    public GameObject leonObject;

    public float horizontalMoving;
    public float verticalMoving;
    public float walkSpeed;
    public float rotateSpeed;


    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        // Walking FWD , BWD , Sprint


		if (Input.GetButton ("Horizontal") || Input.GetButton ("Vertical")) {
			horizontalMoving = Input.GetAxis ("Horizontal") * Time.deltaTime * rotateSpeed;
			verticalMoving = Input.GetAxis ("Vertical") * Time.deltaTime * walkSpeed;
			leonObject.transform.Rotate (0, horizontalMoving, 0);
			leonObject.transform.Translate (0, 0, verticalMoving);
			if (Input.GetKeyDown (KeyCode.LeftShift)) {
				walkSpeed = 1.25f;
			}
			if (Input.GetKeyUp (KeyCode.LeftShift)) {
				walkSpeed = 0.5f;
			}

		} else {
			walkSpeed = 0.5f;
		}
		if (Input.GetKey(KeyCode.K)) {
			walkSpeed = 0f;
		}
	}
}
