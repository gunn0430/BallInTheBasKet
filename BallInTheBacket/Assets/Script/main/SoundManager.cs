using UnityEngine;
using System.Collections;

public class SoundManager : MonoBehaviour {
	public AudioSource[] audioSource = new AudioSource[1];
	public AudioClip[] BGM = new AudioClip[7];
	public AudioClip[] SE = new AudioClip[3];
	//BGMのボリューム
	public float bgmVol = 0.5f;
	//SEのボリューム
	public float seVol = 0.5f;
	string nowBGM;

	void Awake () {
		BGM = Resources.LoadAll<AudioClip>("Sound");
		SE[0] = Resources.Load<AudioClip>("SE/button");
		SE[1] = Resources.Load<AudioClip>("SE/clear");
		SE[2] = Resources.Load<AudioClip>("SE/ball");
		audioSource = gameObject.GetComponents<AudioSource>();
		GetVolume ();
		SetAudioVolume ();
		BGMStart();

	}
	
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
		audio.volume = seVol;
		audio.PlayOneShot (SE[2]);
	}

	
	//音量を取得
	public void GetVolume () {
		if (PlayerPrefs.HasKey (ConstClass.BGM_VOLUME_KEY)) {
			bgmVol = PlayerPrefs.GetFloat (ConstClass.BGM_VOLUME_KEY);
		} else {
			bgmVol = 0.5f;
		}
		if (PlayerPrefs.HasKey (ConstClass.SE_VOLUME_KEY)) {
			seVol = PlayerPrefs.GetFloat (ConstClass.SE_VOLUME_KEY);
		} else {
			seVol = 0.5f;
		}
	}

	//audiosourceの音量を設定
	public void  SetAudioVolume(){
		audioSource [0].volume = bgmVol;
		audioSource [1].volume = seVol;
	}
}
