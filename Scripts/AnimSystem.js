#pragma strict

var aimIsReady = false;
var bulletSpeed : float = 1100;
var bullet : GameObject;
var rate : float = 1f;
var bulletHolder : GameObject;
var muzzleFlash : GameObject;
var bulletAudio : AudioSource;
private var rateTime : float;
private var isReloading = false;
var reloadAudio : AudioSource;
var clip : GameObject;

//Beretta
var maxAmmo : int = 15;
private var currentAmmo : int;
public var reloadTime : float = 1f;



function Start () {
	GetComponent.<Animation>().wrapMode = WrapMode.Loop;
	GetComponent.<Animation>()["StartAiming"].wrapMode = WrapMode.ClampForever;
	GetComponent.<Animation>()["StartThinking"].wrapMode = WrapMode.Once;
	GetComponent.<Animation>()["Shoot"].wrapMode = WrapMode.Once;
	GetComponent.<Animation>()["Reload"].wrapMode = WrapMode.Once;
	GetComponent.<Animation>()["Shoot"].layer = 1;
	GetComponent.<Animation>()["Reload"].layer = 1;
	bulletAudio = GetComponent.<AudioSource>();
	reloadAudio = GetComponent.<AudioSource>();
	currentAmmo = maxAmmo;
}

function Update () {

	if(isReloading) {
	return;
	}

	if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.D)) {
		GetComponent.<Animation>().CrossFade("Walking");
			if (Input.GetKey(KeyCode.LeftShift) && Input.GetAxis("Vertical") != 0) {
			GetComponent.<Animation>().CrossFade("Sprinting");
		}
			if (Input.GetAxis("Vertical") == 0){
			GetComponent.<Animation>().CrossFade("Walking");
		}
	}

	else {
		GetComponent.<Animation>().CrossFade("Idle");
	}

	if (Input.GetKey(KeyCode.S)) {
		GetComponent.<Animation>().CrossFade("WalkingBwd");
	}

	if (Input.GetKey(KeyCode.K)) {
		GetComponent.<Animation>().CrossFade("StartAiming", 0.06f);
		AimingReadyChecker();
		if(aimIsReady == true) {
				if (Input.GetKeyDown (KeyCode.J) && Time.time > rateTime && currentAmmo > 0) {
				GetComponent.<Animation>().Play("Shoot");
				rateTime = Time.time + rate;
				Fire();
				muzzleFlash.GetComponent.<ParticleSystem>().Play();

				if (currentAmmo <= 0) {
				StartCoroutine(Reload());
				return;
				}
			}

		}
	}

	else {
		aimIsReady = false;
	}
}
function AimingReadyChecker() {
		yield WaitForSeconds (0.2f);
		aimIsReady = true;
}

function Fire()
    {
    	currentAmmo--;
        //Shoot
        var tempBullet : GameObject = Instantiate(bullet, bulletHolder.transform.position, bulletHolder.transform.rotation);
        var tempRigidBodyBullet : Rigidbody = tempBullet.GetComponent.<Rigidbody>();
		tempRigidBodyBullet.AddForce(tempRigidBodyBullet.transform.forward * bulletSpeed);
        Destroy(tempBullet, 0.5f);

        bulletAudio.Play();
    }

function Reload() {
	//Reloading
	isReloading = true;
	Debug.Log("Reloading");
	var tempClip : GameObject = Instantiate(clip, transform.position, transform.rotation);
	Destroy(tempClip, 0.1f);
	GetComponent.<Animation>().Play("Reload");
	reloadAudio.Play();

	yield WaitForSeconds(1);


	//Reload Completed
	currentAmmo = maxAmmo;
	isReloading = false;
}