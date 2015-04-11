using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class CanvasManager_main : MonoBehaviour {
	public GameObject tutorialCanvas;
	public GameObject scoreCanvas;
	public GameObject powerGageCanvas;
	public GameObject directionCanvas;
	public GameObject pauseCanvas;
	public GameObject pauseButtonCanvas;
	public GameObject lifeCanvas;
	public GameObject resultCanvas;
	public GameObject life_1;
	public GameObject life_2;
	public GameObject life_3;

	//スクリプトの参照
	GameManager GManager;

	void Awake(){
		//参照を取得
		GManager = GameObject.Find("GameManager").GetComponent<GameManager>();
	}

	//チュートリアルを非表示にする
	public void DisappearTutorial(){
		tutorialCanvas.GetComponent<Canvas> ().enabled = false;
		GManager.status_Now = GameManager.gameStatus.playing;
	}
	//チュートリアルを表示する
	public void AppearTutorial(){
		tutorialCanvas.GetComponent<Canvas> ().enabled = true;
		GManager.status_Now = GameManager.gameStatus.tutorial;
	}

	//スコア表示用キャンバスを非表示にする
	public void DisappearScoreCanvas(){
		scoreCanvas.GetComponent<Canvas> ().enabled = false;
	}
	//スコア表示用キャンバスを表示する
	public void AppearScoreCanvas(){
		scoreCanvas.GetComponent<Canvas> ().enabled = true;
	}

	//パワーゲージ表示用キャンバスを非表示にする
	public void DisappearPowerGageCanvas(){
		powerGageCanvas.GetComponent<Canvas> ().enabled = false;
	}
	//パワーゲージ表示用キャンバスを表示する
	public void AppearPowerGageCanvas(){
		powerGageCanvas.GetComponent<Canvas> ().enabled = true;
	}

	//方向表示用キャンバスを非表示にする
	public void DisappearDirectionCanvas(){
		directionCanvas.GetComponent<Canvas> ().enabled = false;
	}
	//方向表示用キャンバスを表示する
	public void AppearDirectionCanvas(){
		directionCanvas.GetComponent<Canvas> ().enabled = true;
	}

	//一時停止ウィンドウ表示用キャンバスを非表示にする
	public void DisappearPauseCanvas(){
		pauseCanvas.GetComponent<Canvas> ().enabled = false;
		pauseButtonCanvas.GetComponent<Canvas> ().enabled = true;
		GManager.status_Now = GameManager.gameStatus.playing;
		Time.timeScale = 1f;
	}
	//一時停止ウィンドウ表示用キャンバスを表示する
	public void AppearPauseCanvas(){
		pauseCanvas.GetComponent<Canvas> ().enabled = true;
		pauseButtonCanvas.GetComponent<Canvas> ().enabled = false;
		GManager.status_Now = GameManager.gameStatus.pause;
		Time.timeScale = 0f;
	}
	
	//一時停止ボタンウィンドウ表示用キャンバスを非表示にする
	public void DisappearPauseButtonCanvas(){
		pauseButtonCanvas.GetComponent<Canvas> ().enabled = false;
	}
	//一時停止ボタンウィンドウ表示用キャンバスを表示する
	public void AppearPauseButtonCanvas(){
		pauseButtonCanvas.GetComponent<Canvas> ().enabled = true;
	}

	//Result表示用キャンバスを表示する
	public void AppearResultCanvas(){
		resultCanvas.GetComponent<Canvas> ().enabled = true;
	}

	//Retryボタン押下時処理
	public void OnClick_Retry(){
		Application.LoadLevel ("main");
		Time.timeScale = 1f;
	}
	//ReturnTitleボタン押下時処理
	public void OnClick_ReturnTitle(){
		Application.LoadLevel ("title");
		Time.timeScale = 1f;
	}
}
