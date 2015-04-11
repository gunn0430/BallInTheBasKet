using UnityEngine;
using System.Collections;

public class BallScript : MonoBehaviour {
	float ballDestroyTime = 5f;
	float time = 0f;
	LifeManager lifeManager;
	GameManager GManager;
	BasketManager basketManager;
	ScoreManager scoreManager;
	SoundManager soundManager;
	AudioSource audioSource;

	//ボールが消える際にbasketに入っているかどうか
	bool isSuccess = false;

	void Awake(){
		GManager = GameObject.Find("GameManager").GetComponent<GameManager> ();
		lifeManager = GameObject.Find("LifeManager").GetComponent<LifeManager> ();
		basketManager = GameObject.Find("GameManager").GetComponent<BasketManager> ();
		scoreManager = GameObject.Find("GameManager").GetComponent<ScoreManager> ();
		soundManager = GameObject.Find("SoundManager").GetComponent<SoundManager> ();
		audioSource = gameObject.GetComponent<AudioSource>();
	}

	void Update () {
		//発射されてからの時間を計測
		time += Time.deltaTime;
		//ボールの有効時間切れで消滅させる
		if(time > ballDestroyTime){
			BallDestroy();
		}
	}

	//ボールが消える際の処理
	void BallDestroy(){
		//残り玉数の増減
		if (isSuccess) {
			lifeManager.LifeRecoverAll();
		} else {
			lifeManager.LifeMinus();
		}
		//玉入れ失敗時、GameManagerにstatusの変更を告げる
		if(!isSuccess){
			GManager.status_Now = GameManager.gameStatus.playing;
		}
		//残り玉数がない場合,GameManagerにstatusの変更を告げる
		if(lifeManager.LifeIsNothing()){
			GManager.status_Now = GameManager.gameStatus.end_pause;
		}
		//ボールを削除
		Destroy(this.gameObject);
	}

	void OnTriggerEnter(Collider col){
		if(col.tag == "SuccessTrigger"){
			Success();
		}
	}

	void OnCollisionEnter(Collision col){
		soundManager.BallSE (audioSource);
	}

	//玉入れ成功時の処理
	void Success(){
		isSuccess = true;
		//残り玉数を全回復
		lifeManager.LifeRecoverAll();
		//成功時のパーティクル表示
		basketManager.PlayParticle();
		//玉入れ成功時のSE
		soundManager.ClearSE ();
		//GameManagerにstatusの変更を告げる
		GManager.status_Now = GameManager.gameStatus.success;
		//スコアを増やす
		scoreManager.ScorePlus (1);
		scoreManager.ScoreReload ();
	}
	
}
