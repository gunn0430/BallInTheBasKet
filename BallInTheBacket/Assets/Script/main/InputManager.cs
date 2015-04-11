using UnityEngine;
using System.Collections;

public class InputManager : MonoBehaviour {
	public bool isSpaceKey = false;
	public bool isSpaceKeyUp = false;
	public bool isChangeKeyDown = false;
	//スクリプトの参照
	GameManager GManager;

	void Awake(){
		//参照を取得
		GManager = GameObject.Find("GameManager").GetComponent<GameManager>();
	}

	void Update () {
		//leftコントロールキーが押された1フレームtrue
		if (Input.GetButtonDown ("Change")) {
			isChangeKeyDown = true;
		} else {
			isChangeKeyDown = false;
		}

		//ボール発射を制限
		switch(GManager.status_Now){
			case GameManager.gameStatus.playing:
//				isChangeKeyDown = false;
				//スペースキーが押されている間true
				if (Input.GetButton ("Jump")) {
					isSpaceKey = true;
				} else {
					isSpaceKey = false;
				}
				//スペースキーが離された1フレームtrue
				if (Input.GetButtonUp ("Jump")) {
					isSpaceKeyUp = true;
				} else {
					isSpaceKeyUp = false;
				}
				break;
//			case GameManager.gameStatus.shoot:
//				isSpaceKey = false;
//				isSpaceKeyUp = false;
//				//leftコントロールキーが押された1フレームtrue
//				if (Input.GetButtonDown ("Change")) {
//					isChangeKeyDown = true;
//				} else {
//					isChangeKeyDown = false;
//				}
//				break;
			default:
				isSpaceKey = false;
				isSpaceKeyUp = false;
//				isChangeKeyDown = false;
				break;
		}
	}
}
