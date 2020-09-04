#pragma strict

var camBool : Camera;
var cam2Bool : Camera;
var cam2BGBool : Camera;
var camBGBool : Camera;

function OnTriggerStay(col: Collider) {
	if( col.tag == "Player" ) {
		camBool.enabled = true;
		cam2Bool.enabled = false;
		camBGBool.enabled = true;
		cam2BGBool.enabled = false;
	}
}

function OnTriggerExit(col: Collider) {
	camBool.enabled = false;
	camBGBool.enabled = false;
}
