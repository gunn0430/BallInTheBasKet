using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ResultManager : MonoBehaviour {
//	GameManager GManager;
	ScoreManager scoreManager;

	public GameObject resultTextObj;
	Text resultText;

	void Awake(){
//		GManager = gameObject.GetComponent<GameManager> ();
		scoreManager = gameObject.GetComponent<ScoreManager> ();
		resultText = resultTextObj.GetComponent<Text> ();
	}

	//リザルトスコアを表示
	public void SetResultScore(){
		resultText.text = "リザルト\n\n" + "SCORE : " + scoreManager.score.ToString ();
	}
}
