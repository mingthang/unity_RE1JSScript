using UnityEngine;
using System.Collections;

public class AnimSystem : MonoBehaviour
{


    public bool aimIsReady = false;
    public float bulletSpeed = 1100;
    public GameObject bullet;
    public float rate = 1f;
    public GameObject bulletHolder;
    public GameObject muzzleFlash;
    public AudioSource bulletAudio;
    private float rateTime;
    private bool isReloading = false;
    public AudioSource reloadAudio;
    public GameObject clip;

    //Beretta
    public int maxAmmo = 15;
    private int currentAmmo;
    public float reloadTime = 1f;



    void Start()
    {
        GetComponent< Animation > ().wrapMode = WrapMode.Loop;
        GetComponent< Animation > ()["StartAiming"].wrapMode = WrapMode.ClampForever;
        GetComponent<Animation>()["CollectItem"].wrapMode = WrapMode.ClampForever;
        GetComponent< Animation > ()["StartThinking"].wrapMode = WrapMode.Once;
        GetComponent< Animation > ()["Shoot"].wrapMode = WrapMode.Once;
        GetComponent< Animation > ()["Reload"].wrapMode = WrapMode.Once;
        GetComponent< Animation > ()["Shoot"].layer = 1;
        GetComponent< Animation > ()["Reload"].layer = 1;
        bulletAudio = GetComponent< AudioSource > ();
        reloadAudio = GetComponent< AudioSource > ();
        currentAmmo = maxAmmo;
    }

    void Update()
    {

        if (isReloading)
        {
            return;
        }

        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.D))
        {
            GetComponent< Animation > ().CrossFade("Walking");
            if (Input.GetKey(KeyCode.LeftShift) && Input.GetAxis("Vertical") != 0)
            {
                GetComponent< Animation > ().CrossFade("Sprinting");
            }
            if (Input.GetAxis("Vertical") == 0)
            {
                GetComponent< Animation > ().CrossFade("Walking");
            }
        }

        else
        {
            GetComponent< Animation > ().CrossFade("Idle");
        }

        if (Input.GetKey(KeyCode.S))
        {
            GetComponent< Animation > ().CrossFade("WalkingBwd");
        }

        if (Input.GetKey(KeyCode.K))
        {
            GetComponent< Animation > ().CrossFade("StartAiming", 0.06f);
            AimingReadyChecker();
            if (aimIsReady == true)
            {
                if (Input.GetKeyDown(KeyCode.J) && Time.time > rateTime && currentAmmo > 0)
                {
                    GetComponent< Animation > ().Play("Shoot");
                    rateTime = Time.time + rate;
                    Fire();
                    muzzleFlash.GetComponent< ParticleSystem > ().Play();

                    if (currentAmmo <= 0)
                    {
                        StartCoroutine(Reload());
                        return;
                    }
                }

            }
        }

        else
        {
            aimIsReady = false;
        }
    }
    IEnumerator AimingReadyChecker()
    {
        yield return new WaitForSeconds(2);
        aimIsReady = true;
    }

    void Fire()
    {
        currentAmmo--;
        //Shoot
        GameObject tempBullet = Instantiate(bullet, bulletHolder.transform.position, bulletHolder.transform.rotation);
        Rigidbody tempRigidBodyBullet = tempBullet.GetComponent< Rigidbody > ();
        tempRigidBodyBullet.AddForce(tempRigidBodyBullet.transform.forward * bulletSpeed);
        Destroy(tempBullet, 0.5f);

        bulletAudio.Play();
    }

    IEnumerator Reload()
    {
        //Reloading
        isReloading = true;
        Debug.Log("Reloading");
        GameObject tempClip = Instantiate(clip, transform.position, transform.rotation);
        Destroy(tempClip, 0.1f);
        GetComponent< Animation > ().Play("Reload");
        reloadAudio.Play();

        yield return new WaitForSeconds(1);


        //Reload Completed
        currentAmmo = maxAmmo;
        isReloading = false;
    }
}