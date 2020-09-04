#pragma strict

var camBool : Camera;
var camBGBool : Camera;
var cam2Bool : Camera;
var cam2BGBool : Camera;
var cam3Bool : Camera;
var cam3BGBool : Camera;

function OnTriggerStay(col: Collider) {
	if( col.tag == "Player" ) {
		camBool.enabled = true;
		cam2Bool.enabled = false;
		camBGBool.enabled = true;
		cam2BGBool.enabled = false;
		cam2BGBool.enabled = false;
		cam3Bool.enabled = false;
	}
}

function OnTriggerExit(col: Collider) {
	camBool.enabled = false;
	camBGBool.enabled = false;
}
