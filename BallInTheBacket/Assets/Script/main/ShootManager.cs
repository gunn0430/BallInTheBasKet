using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ShootManager : MonoBehaviour {
	public GameObject direction;
	public GameObject powerGage;
	public GameObject ball;
	float power;
	Quaternion rotation;

	//スクリプトの参照
	GameManager GManager;
	InputManager IManager;
	DirectionManager DManager;
	PowerGage PGage;

	void Start () {
		//参照を取得
		GManager = GameObject.Find("GameManager").GetComponent<GameManager>();
		IManager = GameObject.Find("GameManager").GetComponent<InputManager>();
		DManager = direction.GetComponent<DirectionManager>();
		PGage = powerGage.GetComponent<PowerGage> ();
	}
	
	void Update () {
		if(IManager.isSpaceKeyUp){
			ShootBall();
		}
	}

	//ボールを発射
	public void ShootBall(){
		//GameManagerにstatusの変更を告げる
		GManager.status_Now = GameManager.gameStatus.shoot;

		//発射角度の計算
		float x = -1f * DManager.rotationZ / ConstClass.ROTATION_Z_MAX;
		float y = 1f - DManager.rotationX / ConstClass.ROTATION_X_MAX;
		float z = 1f;
		Vector3 vec = new Vector3 (x,y,z);

		rotation = direction.GetComponent<RectTransform>().localRotation;
		power = PGage.rate * ConstClass.SHOOT_POWER;
		GameObject clone = Instantiate (ball,gameObject.transform.position,rotation) as GameObject;
		//ボールに推進力を加える
		clone.GetComponent<Rigidbody> ().AddForce ( vec * power * ConstClass.SHOOT_POWER_MIN);
		//ボールに回転力を加える
		clone.GetComponent<Rigidbody> ().AddTorque ( Vector3.right * power);
	}
}
