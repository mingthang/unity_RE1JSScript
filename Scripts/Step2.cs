using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Step2 : MonoBehaviour
{
    [SerializeField]
    private AudioClip[] clips;

    AudioSource audio;

    private void Awake()
    {
        audio = GetComponent<AudioSource>();
    }
    private void StepRight()
    {
        AudioClip clip = GetRandomClip();
		audio.PlayOneShot(clip, 1f);
    }
    private AudioClip GetRandomClip()
    {
        return clips[UnityEngine.Random.Range(0, clips.Length)];
    }
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}
