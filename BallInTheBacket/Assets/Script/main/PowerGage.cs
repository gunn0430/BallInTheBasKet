using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PowerGage : MonoBehaviour {
	public GameObject gageFill;
	//スクリプトの参照
	InputManager IManager;

	private const float maxTime = 1.5f;
	private float maxGageSize;
	private float time = 0f;
	public float rate = 0f;

	bool isPlus = true;

	void Awake () {
		//参照を取得
		IManager = GameObject.Find ("GameManager").GetComponent<InputManager> ();
		//ゲージの最大サイズを取得
		maxGageSize = gameObject.GetComponent<RectTransform> ().sizeDelta.y* 0.97f;
	}
	
	void Update () {
		if (IManager.isSpaceKey) {
			if (isPlus) {
				time += Time.deltaTime;
			} else {
				time -= Time.deltaTime;
			}

			if(maxTime < time)
			{
				isPlus = false;
			}
			else if(time < 0)
			{
				isPlus = true;
			}
			//ゲージのフルパワーに対する割合を取得
			rate = time / maxTime;
			gageFill.GetComponent<RectTransform> ().sizeDelta = new Vector2(gageFill.GetComponent<RectTransform> ().sizeDelta.x,
			                                                                (float)(maxGageSize * rate)); 
		} else {
			time = 0f;
			isPlus = true;
		}
	}



}
