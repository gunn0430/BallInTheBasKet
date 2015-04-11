using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {

	//ゲームの状態管理用
	public enum gameStatus{
		tutorial = 0,
		ready,
		playing,
		shoot,
		success,
		pause,
		end_pause,
		result
	}
	public gameStatus status_Now = gameStatus.tutorial;
	private gameStatus status_Before;
	//玉入れ成功時の待ち時間
	float successInterval = ConstClass.SUCCESS_INTERVAL;
	//end_pause時の待ち時間
	float end_pauseInterval = ConstClass.END_PAUSE_INTERVAL;

	//スクリプトの参照
	CanvasManager_main CManager;
	BasketManager basketManager;
	ResultManager resultManager;
	RankingData rankingData;
	ScoreManager scoreManager;

	void Awake () {
		//参照を取得
		CManager = GameObject.Find ("CanvasManager").GetComponent<CanvasManager_main> ();
		basketManager = gameObject.GetComponent<BasketManager> ();
		resultManager = gameObject.GetComponent<ResultManager> ();
		rankingData = gameObject.GetComponent<RankingData> ();
		scoreManager = gameObject.GetComponent<ScoreManager> ();

		StatusChange(status_Now);
		status_Before = status_Now;
	}
	
	// Update is called once per frame
	void Update () {
		if(status_Before != status_Now){
			status_Before = status_Now;
			StatusChange(status_Now);
		}

		switch (status_Now)
		{
			case gameStatus.success:
				Update_Success();
				break;
			case gameStatus.end_pause:
				Update_End_Pause();
				break;
		}

	}

	//ゲームのstatusが変更された時に呼ばれる処理
	public void StatusChange(gameStatus status){
		switch(status)
		{
			case gameStatus.tutorial:
				Start_Tutorial();
				break;
			case gameStatus.ready:
				Start_Ready();
				break;
			case gameStatus.playing:
				Start_Playing();
				break;
			case gameStatus.shoot:
				Start_Shoot();
				break;
			case gameStatus.success:
				Start_Success();
				break;
			case gameStatus.pause:
				Start_Pause();
				break;
			case gameStatus.end_pause:
				Start_End_Pause();
				break;
			case gameStatus.result:
				Start_Result();
				break;
		}
	}

	//tutorial状態に遷移した時に呼ばれる処理
	void Start_Tutorial(){
		CManager.AppearTutorial ();
		CManager.DisappearPauseButtonCanvas ();
	}

	//ready状態に遷移した時に呼ばれる処理
	void Start_Ready(){
		CManager.DisappearTutorial ();
	}

	//playing状態に遷移した時に呼ばれる処理
	void Start_Playing(){
		CManager.AppearScoreCanvas ();
		CManager.AppearPowerGageCanvas ();
		CManager.AppearDirectionCanvas ();
		CManager.AppearPauseButtonCanvas ();
	}
	
	//shoot状態に遷移した時に呼ばれる処理
	void Start_Shoot(){
		
	}

	//success状態に遷移した時に呼ばれる処理
	void Start_Success(){
		//玉入れ成功時、basketの位置を変更する
		basketManager.PlayParticle ();
	}
	//success状態中に呼び出され続ける処理
	void Update_Success(){
		//一定時間経過後、playing状態に遷移
		successInterval -= Time.deltaTime;
		if(successInterval < 0){
			status_Now = gameStatus.playing;
			successInterval = ConstClass.SUCCESS_INTERVAL;
			//basketを移動させる
			basketManager.MoveBasket ();
		}
	}
	
	//pause状態に遷移した時に呼ばれる処理
	void Start_Pause(){
		
	}

	//end_pause状態に遷移した時に呼ばれる処理
	void Start_End_Pause(){
		CManager.DisappearPauseButtonCanvas ();
		status_Now = gameStatus.end_pause;
	}
	//end_pause状態中に呼び出され続ける処理
	void Update_End_Pause(){
		//一定時間経過後、playing状態に遷移
		end_pauseInterval -= Time.deltaTime;
		if(end_pauseInterval < 0){
			status_Now = gameStatus.result;
			end_pauseInterval = ConstClass.END_PAUSE_INTERVAL;
		}
	}

	//result状態に遷移した時に呼ばれる処理
	void Start_Result(){
		rankingData.SaveRankingData_Score (scoreManager.score);
		resultManager.SetResultScore ();
		CManager.AppearResultCanvas ();
		CManager.DisappearPauseButtonCanvas ();
	}


}
