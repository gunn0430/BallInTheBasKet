using UnityEngine;
using System.Collections;

public class CameraManager : MonoBehaviour {

	public GameObject left;
	public GameObject right;
	public GameObject top;

	Camera camera_main;
	Camera camera_left;
	Camera camera_right;
	Camera camera_top;

	//列挙体の宣言
	public enum CameraEnable{
		mainCamera = 0,
		leftCamera,
		rightCamera,
		topCamera
	}
	CameraEnable activeCamera;

//	GameManager GManaget;
	InputManager inputManager;

	Vector2 leftCameraRotation = new Vector2(0,0);
	Vector2 rightCameraRotation = new Vector2(0,0);
	Vector2 topCameraRotation = new Vector2(0,0);

	void Awake () {
		camera_main = gameObject.GetComponent<Camera> ();
		camera_left = left.GetComponent<Camera> ();
		camera_right = right.GetComponent<Camera> ();
		camera_top = top.GetComponent<Camera> ();

//		GManaget = GameObject.Find("GameManager").GetComponent<GameManager>();
		inputManager = GameObject.Find("GameManager").GetComponent<InputManager>();
		SetMainCamera ();
	}
	
	void Update () {
		if(inputManager.isChangeKeyDown){
			ChangeCamera(activeCamera);
		}
		//メインカメラ以外の時、カメラ角度を調整できる
		if(activeCamera != CameraEnable.mainCamera){
			//マウスドラッグ時
			if( Input.GetMouseButton(0)){
				ChangeCameraRotation();
			}
		}
	}

	//メインカメラを起動
	void SetMainCamera(){
		camera_main.enabled = true;
		camera_left.enabled = false;
		camera_right.enabled = false;
		camera_top.enabled = false;
		//アクティブなカメラを登録
		activeCamera = CameraEnable.mainCamera;
	}

	//leftカメラを起動
	void SetLeftCamera(){
		camera_left.enabled = true;
		camera_main.enabled = false;
		camera_right.enabled = false;
		camera_top.enabled = false;
		//アクティブなカメラを登録
		activeCamera = CameraEnable.leftCamera;
	}

	//rightカメラを起動
	void SetRightCamera(){
		camera_right.enabled = true;
		camera_main.enabled = false;
		camera_left.enabled = false;
		camera_top.enabled = false;
		//アクティブなカメラを登録
		activeCamera = CameraEnable.rightCamera;
	}

	//topカメラを起動
	void SetTopCamera(){
		camera_top.enabled = true;
		camera_main.enabled = false;
		camera_left.enabled = false;
		camera_right.enabled = false;
		//アクティブなカメラを登録
		activeCamera = CameraEnable.topCamera;
	}

	//カメラの切り替え
	void ChangeCamera(CameraEnable camera){
		switch(camera){
		case CameraEnable.mainCamera:
			SetLeftCamera();
			break;
		case CameraEnable.leftCamera:
			SetRightCamera();
			break;
		case CameraEnable.rightCamera:
			SetTopCamera();
			break;
		case CameraEnable.topCamera:
			SetMainCamera();
			break;
		}
	}
	public float x;	public float y;	public float z;
	//カメラ角度調節
	public void ChangeCameraRotation(){
		Vector3 target;
		//スクリーン上でのマウスの位置を取得
		Vector3 mousePos = Input.mousePosition;
		switch(activeCamera){
		case CameraEnable.leftCamera:
			//カメラ操作の調整
			target = camera_left.ScreenToViewportPoint(mousePos);
			left.transform.rotation = Quaternion.LookRotation(target);
			break;
		case CameraEnable.rightCamera:
			//カメラ操作の調整
			target = camera_right.ScreenToViewportPoint(new Vector3(mousePos.x * -1,mousePos.y,mousePos.z * -1));
			right.transform.rotation = Quaternion.LookRotation(target);
			break;
		case CameraEnable.topCamera:
			//カメラ操作の調整
//			target = camera_top.ScreenToViewportPoint(new Vector3(mousePos.x * x,mousePos.y - y,mousePos.z * z));
//			top.transform.rotation = Quaternion.LookRotation(target);
			break;
		}	
	}

	//カメラの回転量を計算
	Vector2 CalcRotation(Vector2 cameraRotate,float X,float Y){
		float tmpX = cameraRotate.x + X;
		float tmpY = cameraRotate.y + Y;
		//方向の限界を超えないように制限
		tmpX = Mathf.Clamp (tmpX, ConstClass.CAMERA_ROTATION_X_MIN, ConstClass.CAMERA_ROTATION_X_MAX);
		tmpY = Mathf.Clamp (tmpY, ConstClass.CAMERA_ROTATION_Y_MIN, ConstClass.CAMERA_ROTATION_Y_MAX);
		return new Vector2(tmpX,tmpY);
	}
}
