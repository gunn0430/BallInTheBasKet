using UnityEngine;
using System.Collections;

public class SoundManager_title : MonoBehaviour {
	AudioSource[] audioSource;
	public AudioClip BGM;
	AudioClip SE;
	OptionManager optionManager;
	//BGMのボリューム
	public float bgmVol = 0.5f;
	//SEのボリューム
	public float seVol = 0.5f;

	string nowBGM;
	
	void Awake () {
		optionManager = GameObject.Find("OptionManager").GetComponent<OptionManager>();
		BGM = Resources.Load<AudioClip>("Sound/1");
		SE = Resources.Load<AudioClip>("SE/button");
		audioSource = gameObject.GetComponents<AudioSource>();
		GetVolume ();
		SetAudioVolume ();
	}

	
	//ボタン押下時のSE
	public void ButtonSE(){
		audioSource[1] .PlayOneShot (SE);
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

	//音量を保存
	public void SetVolume () {
		PlayerPrefs.SetFloat (ConstClass.BGM_VOLUME_KEY,bgmVol);
		PlayerPrefs.SetFloat (ConstClass.SE_VOLUME_KEY,seVol);
	}

	//BGM音量が変更された時の処理
	public void ChangeBGMVolume(){
		bgmVol = optionManager.bgmScrollbar.value;
	}
	//SE音量が変更された時の処理
	public void ChangeSEVolume(){
		seVol = optionManager.seScrollbar.value;
	}

	//audiosourceの音量を設定
	public void  SetAudioVolume(){
		audioSource [0].volume = bgmVol;
		audioSource [1].volume = seVol;
	}
}
