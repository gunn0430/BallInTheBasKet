using UnityEngine;
using System.Collections;

public class BasketManager : MonoBehaviour {
	public GameObject basket;
	public GameObject particle;
	//現在出現中のbasket
	GameObject clone;
	//出現場所
	Vector3 position;
	//出現時の向き
	Quaternion rotation;

	//basketを移動させる
	public void MoveBasket(){
		basket.transform.position = GetPosition ();
	}
	
	//出現場所を取得
	Vector3 GetPosition(){
		//各値をランダムで取得
		float x = Random.Range (ConstClass.BASKET_X_MIN,ConstClass.BASKET_X_MAX);
		float y = Random.Range (ConstClass.BASKET_Y_MIN,ConstClass.BASKET_Y_MAX);
		float z = Random.Range (ConstClass.BASKET_Z_MIN,ConstClass.BASKET_Z_MAX);
		return new Vector3(x,y,z);
	}

	public void PlayParticle(){
		particle.GetComponent<ParticleSystem> ().Play ();
	}
	
//	//出現時の向きを取得
//	Quaternion GetRotation(){
//		Quaternion tmp;
//		tmp = gameObject.transform.rotation;
//		return tmp;
//	}
}
