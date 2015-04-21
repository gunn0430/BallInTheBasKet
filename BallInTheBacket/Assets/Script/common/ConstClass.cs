using UnityEngine;
using System.Collections;

public class ConstClass : MonoBehaviour {
	//ランキング最大数
	public const int MAX_SIZE_RANKING = 20;

	//ランキングのスコア保存用キー名
	public const string RANKING_SCORE = "ranking_score";
	//ランキングのコンボ数保存用キー名
	public const string RANKING_COMBO = "ranking_combo";
	//SPLIT_CHARA
	public const string SPLIT_CHARA = "|";

	//方向x軸の最小値
	public const int ROTATION_X_MIN = 0;
	//方向x軸の最大値
	public const int ROTATION_X_MAX = 80;

	//方向z軸の最小値
	public const int ROTATION_Z_MIN = -60;
	//方向z軸の最大値
	public const int ROTATION_Z_MAX = 60;

	//シュートの力
	public const float SHOOT_POWER = 50f;
	//シュートの力（最低）
	public const float SHOOT_POWER_MIN = 20f;

	//残り玉数有りのcolor
	public static readonly Color LIFE_COLOR_ON = Color.white;
	//残り玉数無しのcolor
	public static readonly Color LIFE_COLOR_OFF = Color.gray;

	//basketの出現位置制限範囲
	public const float BASKET_X_MIN = -20.5f;
	public const float BASKET_X_MAX = 22.5f;
	public const float BASKET_Y_MIN = 4f;
	public const float BASKET_Y_MAX = 17f;
	public const float BASKET_Z_MIN = -17f;
	public const float BASKET_Z_MAX = 22.5f;

	//玉入れ成功時の待ち時間
	public const float SUCCESS_INTERVAL = 5f;
	//end_pause時の待ち時間
	public const float END_PAUSE_INTERVAL = 1f;

	//BGMの音量
	public const string BGM_VOLUME_KEY = "bgm_volume_key";
	//SEの音量
	public const string SE_VOLUME_KEY = "se_volume_key";

	//サブカメラの回転角度制限値
	public const float CAMERA_ROTATION_X_MIN = -60f;
	public const float CAMERA_ROTATION_X_MAX = 60f;
	public const float CAMERA_ROTATION_Y_MIN = -30f;
	public const float CAMERA_ROTATION_Y_MAX = 30f;

}
