using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class DirectionManager : MonoBehaviour {
	RectTransform rectTranceform;
	//rotationのx,y,zを保持
	//x軸が上下、z軸が左右に影響を与える
	public float rotationX = ConstClass.ROTATION_X_MAX;
	const float rotationY = 0f;
	public float rotationZ = 0f;

	void Awake(){
		rectTranceform = gameObject.GetComponent<RectTransform> ();
	}

	void Update () {
		//-1,0,1 のいずれかを取得
		float tmpX = Input.GetAxisRaw ("Vertical");
		float tmpZ = Input.GetAxisRaw ("Horizontal");

		//方向指示オブジェクトのrotationを計算
		rotationX -= tmpX * Time.deltaTime * 70f;
		rotationZ -= tmpZ * Time.deltaTime * 70f;
		//方向の限界を超えないように制限
		rotationX = Mathf.Clamp (rotationX, ConstClass.ROTATION_X_MIN, ConstClass.ROTATION_X_MAX);
		rotationZ = Mathf.Clamp (rotationZ, ConstClass.ROTATION_Z_MIN, ConstClass.ROTATION_Z_MAX);
		//rotationをセット
		rectTranceform.localRotation = Quaternion.Euler( new Vector3 (rotationX,rotationY,rotationZ));
		//gameObject.transform.Rotate (new Vector3 (rotationX, rotationY, rotationZ),Space.Self);
	}
}
