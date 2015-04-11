using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class RankingManager : MonoBehaviour {
	public GameObject content;
	public GameObject node;

	RankingData rankingData;

	void Start () {
		rankingData = gameObject.GetComponent<RankingData>();
		SetRankingDate ();
	}

	 //ランキングデータを取得し、表示する
	public void SetRankingDate(){
		//ランキングデータの取得
		rankingData.GetRankingData ();
		//ランキングデータを表示
		Text text = node.transform.FindChild("Text").GetComponent<Text> ();
		for (int i = 0; i < rankingData.ScoreArray.Length; i++) {
			//ランキングデータをセット
			if(i < 9){
				text.text = " " + (i+1).ToString() + " . SCORE:  " + rankingData.ScoreArray[i].ToString();
			}else{
				text.text = (i+1).ToString() + ". SCORE:  " + rankingData.ScoreArray[i].ToString();
			}
			//ランキングデータを生成
			GameObject clone = Instantiate(node,content.transform.position,content.transform.rotation) as GameObject;
			//スクロールさせるために親子関係の調整
			clone.transform.SetParent(content.transform);
			//スケールの調整
			clone.GetComponent<RectTransform>().localScale = Vector3.one;
		}

	}




}
