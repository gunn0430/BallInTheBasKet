using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class CanvasManager_title : MonoBehaviour {
	public GameObject titleCanvas;
	public GameObject rankingCanvas;
	public GameObject optionCanvas;



	void Start () {

	}
	
	void Update () {
	
	}

	//タイトル用canvasを表示し、その他を消す
	public void AppearTitle(){
		titleCanvas.GetComponent<Canvas> ().enabled = true;
		rankingCanvas.GetComponent<Canvas> ().enabled = false;
		optionCanvas.GetComponent<Canvas> ().enabled = false;
	}

	//ランキング用canvasを表示し、その他を消す
	public void AppearRanking(){
		titleCanvas.GetComponent<Canvas> ().enabled = false;
		rankingCanvas.GetComponent<Canvas> ().enabled = true;
		optionCanvas.GetComponent<Canvas> ().enabled = false;
	}

	//オプション用canvasを表示し、その他を消す
	public void AppearOption(){
		titleCanvas.GetComponent<Canvas> ().enabled = false;
		rankingCanvas.GetComponent<Canvas> ().enabled = false;
		optionCanvas.GetComponent<Canvas> ().enabled = true;	
	}

	//開始ボタン押下処理
	public void ClickStartButton(){
		Application.LoadLevel ("main");
	}
}
