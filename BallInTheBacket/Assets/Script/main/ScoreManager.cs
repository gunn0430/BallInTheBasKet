using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ScoreManager : MonoBehaviour {
	public GameObject scoreTextObj;
	Text scoreText;
	//現在の玉入れ成功数
	public int score = 0;

	void Awake(){
		scoreText = scoreTextObj.GetComponent<Text> ();
		ScoreReload ();
	}

	//スコア表示の更新
	public void ScoreReload(){
		scoreText.text = "SCORE : " + score.ToString();
	}

	//スコアを増やす
	public void ScorePlus(int plus){
		score += plus;
	}
}
