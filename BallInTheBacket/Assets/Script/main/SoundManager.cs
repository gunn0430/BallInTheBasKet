using UnityEngine;
using System.Collections;

public class SoundManager : MonoBehaviour {
	public AudioSource[] audioSource = new AudioSource[1];
	public AudioClip[] BGM = new AudioClip[7];
	public AudioClip[] SE = new AudioClip[3];

	string nowBGM;

	// Use this for initialization
	void Awake () {
		BGM = Resources.LoadAll<AudioClip>("Sound");
		SE[0] = Resources.Load<AudioClip>("SE/button");
		SE[1] = Resources.Load<AudioClip>("SE/clear");
		SE[2] = Resources.Load<AudioClip>("SE/ball");
		audioSource = gameObject.GetComponents<AudioSource>();
		BGMStart();

	}
	
	// Update is called once per frame
	void Update () {
		if(!audioSource[0].isPlaying){
			BGMStart();
		}
	}

	//BGMを再生する
	void BGMStart(){
		AudioClip tmp = BGM [Random.Range (1, 7)];
		audioSource[0].clip = tmp;
		audioSource[0].Play ();
		//audioSource.PlayOneShot (tmp);
	}

	//ボタン押下時のSE
	public void ButtonSE(){
		audioSource [1].PlayOneShot (SE[0]);
	}

	//玉入れ成功時のSE
	public void ClearSE(){
		audioSource [1].PlayOneShot (SE[1]);
	}
	
	//ボールが何かにぶつかった時のSE
	public void BallSE(AudioSource audio){
		audio.PlayOneShot (SE[2]);
	}
	

}
