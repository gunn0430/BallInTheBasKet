using UnityEngine;
using System.Collections;

public class RankingData : MonoBehaviour {
	public string rankingData_Score = "";
	public string rankingData_Combo = "";

	//現在のランキングデータを保持しておく
	public int[] ScoreArray;
	public int[] ComboArray;

	void Awake(){
		Init ();
	}

	void Init(){
		//現在のランキングデータを初期化
		ScoreArray = new int[ConstClass.MAX_SIZE_RANKING];
		ComboArray = new int[ConstClass.MAX_SIZE_RANKING];
		for (int i = 0; i < ConstClass.MAX_SIZE_RANKING; i++) {
			ScoreArray[i] = 0;
			ComboArray[i] = 0;
		}
	}

	//playerPrefsに保存されているランキングデータを取得
	public void GetRankingData(){
		if (PlayerPrefs.HasKey (ConstClass.RANKING_SCORE)) {
			rankingData_Score = PlayerPrefs.GetString (ConstClass.RANKING_SCORE);
			ScoreArray = GetArray_NoSort (rankingData_Score);
		}
		if (PlayerPrefs.HasKey (ConstClass.RANKING_COMBO)) {
			rankingData_Combo = PlayerPrefs.GetString (ConstClass.RANKING_COMBO);
			ComboArray = GetArray_NoSort(rankingData_Combo);
		}
	}

	//データをランキングに入れるか判定（最小値比較）
	bool ValidateData(int data,int[] rankingArray){
		int tmp = 0;
		if(rankingArray.Length > 0){
			tmp = rankingArray[rankingArray.Length-1];
		}
		return tmp < data;
	}

	//新たなデータを加えて降順にソートし、配列にして返す
	int[] GetArray_Sort(int[] dataArr,int data){
		//前回までのランキングデータ配列を一時配列にコピー
		int[] tmp = new int[dataArr.Length + 1];
		for (int i = 0; i < dataArr.Length; i++) {
			tmp[i] = dataArr[i];
		}
		tmp [dataArr.Length] = data;
		int dummy;
		//valid
		if(tmp.Length <= 0){
			return new int[0];
		}
		//sort
		for (int i = 0; i < tmp.Length; i++) {
			for (int j = i+1; j < tmp.Length; j++) {
				if(tmp[i] < tmp[j]){
					dummy = tmp[i];
					tmp[i] = tmp[j];
					tmp[j] = dummy;
				}
			}
		}
		//ランキングデータが２０件を超えたらカット
		int[] tmp2 = new int[ConstClass.MAX_SIZE_RANKING];
		if(tmp.Length > ConstClass.MAX_SIZE_RANKING){
			for (int i = 0; i < ConstClass.MAX_SIZE_RANKING; i++) {
				tmp2[i] = tmp[i];
			}
			return tmp2;
		}
		return tmp;
	}

	//string文字列のランキングデータを受け取り、int型配列にして返す
	int[] GetArray_NoSort(string data){
		string[] tmp = data.Split (ConstClass.SPLIT_CHARA[0]);
		int[] intArray = new int[tmp.Length];
		//valid
		if(data.Length <= 0){
			return new int[0];
		}
		try{
			for (int i = 0; i < tmp.Length; i++) {
				intArray[i] = int.Parse(tmp[i]);
			}
		}catch(UnityException e){
			Debug.Log ("ERROR : "+e.Message);
			intArray = new int[9];
		}
		return intArray;
	}

	//string.join(,)のような処理を行う
	string ArrayJoin(int[] arr){
		string tmp = "";
		for (int i = 0; i < arr.Length; i++) {
			tmp += arr[i].ToString();
			if(i == arr.Length-1){
				break;
			}
			tmp += ConstClass.SPLIT_CHARA;
		}
		return tmp;
	}

	//スコアランキングにデータを登録する一連の処理
	public void SaveRankingData_Score(int score){
		//ランキングデータをロード
		GetRankingData ();
		//ランキング入りの判定
		if(ValidateData(score,ScoreArray)){
			//新たなデータを加えて降順にソート
			int[] tmpArr = GetArray_Sort(ScoreArray,score);
			//現在のランキングデータをstring文字列に変換に、PlayerPrefsに保存する
			string tmp = ArrayJoin(tmpArr);
			PlayerPrefs.SetString (ConstClass.RANKING_SCORE,tmp);
		}else{
			return;
		}
	}

	//comboランキングにデータを登録する一連の処理
	public void SaveRankingData_Combo(int combo){
		//ランキングデータをロード
		GetRankingData ();
		//ランキング入りの判定
		if(ValidateData(combo,ComboArray)){
			//新たなデータを加えて降順にソート
			int[] tmpArr = GetArray_Sort(ComboArray,combo);

			//現在のランキングデータをstring文字列に変換に、PlayerPrefsに保存する
			string tmp = ArrayJoin(tmpArr);
			PlayerPrefs.SetString (ConstClass.RANKING_COMBO,tmp);
		}else{
			return;
		}
	}

}
