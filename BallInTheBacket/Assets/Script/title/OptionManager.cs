using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class OptionManager : MonoBehaviour {

	public GameObject bgmScrollbarObj;
	public GameObject seScrollbarObj;
	public Scrollbar bgmScrollbar;
	public Scrollbar seScrollbar;
	SoundManager_title soundManager;


	void Awake(){
		//参照を取得
		bgmScrollbar = bgmScrollbarObj.GetComponent<Scrollbar> ();
		seScrollbar = seScrollbarObj.GetComponent<Scrollbar> ();
		soundManager = GameObject.Find ("SoundManager").GetComponent<SoundManager_title>();
	}

	//スクロールバーのvalueを設定
	public void SetScrollBarValue(){
		bgmScrollbar.value = PlayerPrefs.GetFloat (ConstClass.BGM_VOLUME_KEY);
		seScrollbar.value = PlayerPrefs.GetFloat (ConstClass.SE_VOLUME_KEY);
	}
}
