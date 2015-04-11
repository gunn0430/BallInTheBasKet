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

	public enum CameraEnable{
		mainCamera = 0,
		leftCamera,
		rightCamera,
		topCamera
	}
	CameraEnable activeCamera;

//	GameManager GManaget;
	InputManager inputManager;

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
}
