using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class LifeManager : MonoBehaviour {
	public GameObject Life_1;
	public GameObject Life_2;
	public GameObject Life_3;

	Image Life_1_Image;
	Image Life_2_Image;
	Image Life_3_Image;

	void Awake(){
		Life_1_Image = Life_1.GetComponent<Image> ();
		Life_2_Image = Life_2.GetComponent<Image> ();
		Life_3_Image = Life_3.GetComponent<Image> ();
	}

	//残り玉数を１減らす処理
	public void LifeMinus(){
		if(Life_1_Image.color == ConstClass.LIFE_COLOR_ON)
		{
			Life_1_Image.color = ConstClass.LIFE_COLOR_OFF;
		}
		else if(Life_2_Image.color == ConstClass.LIFE_COLOR_ON)
		{
			Life_2_Image.color = ConstClass.LIFE_COLOR_OFF;
		}
		else if(Life_3_Image.color == ConstClass.LIFE_COLOR_ON)
		{
			Life_3_Image.color = ConstClass.LIFE_COLOR_OFF;
		}
	}

	//残り玉数を１回復する処理
	public void LifePlus(){
		if(Life_3_Image.color == ConstClass.LIFE_COLOR_OFF)
		{
			Life_3_Image.color = ConstClass.LIFE_COLOR_ON;
		}
		else if(Life_2_Image.color == ConstClass.LIFE_COLOR_OFF)
		{
			Life_2_Image.color = ConstClass.LIFE_COLOR_ON;
		}
		else if(Life_1_Image.color == ConstClass.LIFE_COLOR_OFF)
		{
			Life_1_Image.color = ConstClass.LIFE_COLOR_ON;
		}
	}

	//残り玉数を全回復する処理
	public void LifeRecoverAll(){
		Life_1_Image.color = ConstClass.LIFE_COLOR_ON;
		Life_2_Image.color = ConstClass.LIFE_COLOR_ON;
		Life_3_Image.color = ConstClass.LIFE_COLOR_ON;
	}

	//残り玉数があるかどうか
	public bool LifeIsNothing(){
		if(Life_3_Image.color == ConstClass.LIFE_COLOR_OFF){
			return true;
		}
		return false;
	}

}
