using UnityEngine;
using System.Collections;

public class SoundManager_title : MonoBehaviour {
	 AudioSource audioSource;
	public AudioClip BGM;
	 AudioClip SE;
	
	string nowBGM;
	
	// Use this for initialization
	void Awake () {
		BGM = Resources.Load<AudioClip>("Sound/1");
		SE = Resources.Load<AudioClip>("SE/button");
		audioSource = gameObject.GetComponent<AudioSource>();
	}

	
	//ボタン押下時のSE
	public void ButtonSE(){
		audioSource .PlayOneShot (SE);
	}
}
