using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour {

	public Animator animator;
	public AudioClip clip;
	private int levelToLoad;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.Space)) {
			FadeToLevel (1);
			GetComponent<AudioSource> ().PlayOneShot (clip, 1f);
		}
	}

	/*public void FadeToNextLevel() {
		FadeToLevel(SceneManager.GetActiveScene().buildIndex + 1);
	}
	*/

	public void FadeToLevel (int levelIndex) {
		levelToLoad = levelIndex;
		animator.SetTrigger ("FadeOut");
	}
	public void OnFadeComplete() {
		SceneManager.LoadScene(levelToLoad);
	}
}
