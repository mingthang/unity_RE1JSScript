#pragma strict

var cam01 : Camera;
var cam02 : Camera;
var cam01BG : Camera;
var cam02BG : Camera;

public var walkedIn : boolean = false;

function Start () {
}

function OnTriggerStay(Col: Collider) {
	cam01.GetComponent.<Camera>().enabled = true;
	cam01BG.GetComponent.<Camera>().enabled = true;
	cam02BG.GetComponent.<Camera>().enabled = false;
	cam02.GetComponent.<Camera>().enabled = false;
}

function OnTriggerExit(Col: Collider) {
	cam01.GetComponent.<Camera>().enabled = false;
	cam01BG.GetComponent.<Camera>().enabled = false;
	cam02BG.GetComponent.<Camera>().enabled = true;
	cam02.GetComponent.<Camera>().enabled = true;
}


function Update () {

}
