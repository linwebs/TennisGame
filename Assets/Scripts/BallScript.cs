using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BallScript : MonoBehaviour {
	//Ball
	public float Power = 10;//發射時的速度
	public float Angle = 320;//發射角度
	private float Gravity = -10;//重力加速度
	private Vector3 MoveSpeed;//初速度向量
	private Vector3 GritySpeed = Vector3.zero;//重力的速度向量
	private float dTime;//已經過去的時間
	private Vector3 currentAngle;
	private int forwardangle;

	//Score
	//界外線 X:短邊 Z:長邊
	private float OutsideLineX1 = 5.5f;
	private float OutsideLineX2 = -5.5f;
	private float OutsideLineZ1 = 12.0f;
	private float OutsideLineZ2 = -12.0f;

	public GameObject tennis1;
	public GameObject tennis2;
	public GameObject player1;
	public Text GGtext;
	public Text score1_1;
	public Text score2_1;
	public Text score1_2;
	public Text score2_2;
	public Text score1_3;
	public Text score2_3;
	private int flag;//0:玩家，1:電腦，持球的人
	private int touchfloor;//碰撞floor次數
	private int iscore1;
	private int iscore2;

	private int gametimes = 0;//第?局
	private int playtimes = 0;//玩家贏?場
	private int computimes = 0;//電腦贏?場

	private bool GOGO;//Space發球
	private float x, y, z;

	Rigidbody m_Rigidbody;

	void Start() {
		newgames();
	}

	void Update() {
		if (Input.GetKey(KeyCode.Space)) {
			if(playtimes < 2) {
				// 如果未勝利 才可揮拍
				StartCoroutine(your_timer());
			}
		}

		if (!GOGO) {
			x = player1.transform.position.x + 1.0f;
			y = player1.transform.position.y + 1.0f;
			z = player1.transform.position.z + 0.2f;
			transform.position = new Vector3(x, y, z);
			m_Rigidbody = GetComponent<Rigidbody>();
			//This locks the RigidBody so that it does not move or rotate in the Z axis.
			m_Rigidbody.constraints = RigidbodyConstraints.FreezePositionY;
		}
	}

	IEnumerator your_timer() {
		Debug.Log("Your enter Coroutine at" + Time.time);
		yield return new WaitForSeconds(0.2f);
		GOGO = true;
		m_Rigidbody = GetComponent<Rigidbody>();
		//This locks the RigidBody so that it does not move or rotate in the Z axis.
		m_Rigidbody.constraints = RigidbodyConstraints.None;
	}

	void FixedUpdate() {

		if (GOGO) {
			//Ball
			//計算重力速度
			//v = at
			GritySpeed.y = Gravity * (dTime += Time.fixedDeltaTime);
			//位移模擬軌跡
			transform.position += (MoveSpeed + GritySpeed) * Time.fixedDeltaTime;
			currentAngle.x = Mathf.Atan((MoveSpeed.y + GritySpeed.y) / MoveSpeed.z) * Mathf.Rad2Deg;
			transform.eulerAngles = currentAngle;
		}
	}
	void OnCollisionEnter(Collision collision) {
		Debug.Log("" + collision.gameObject.tag);
		if (collision.gameObject.tag == "tennis_racket") {
			touchfloor = 0;
			if (flag == 0) {
				//Boomtext.text = "Player 1";
				Angle += 90;
				flag = 1;
			} else if (flag == 1) {
				//Boomtext.text = "Player 2";
				Angle -= 90;
				flag = 0;
			}
			dTime = 0;
			//Debug.Log("AAA" + dTime);
			//GritySpeed = Vector3.zero;
			RandomZ();
			MoveSpeed = Quaternion.Euler(new Vector3(Angle, forwardangle, 0)) * Vector3.forward * Power;
			currentAngle = Vector3.zero;
		}

		if (collision.gameObject.tag == "floor") {

			touchfloor++;
			if (touchfloor == 1) {
				//Boomtext.text = "floor 1";
				//判斷第一下是否界外，界外對手得分
				Check_OutsideLine();
			} else if (touchfloor == 2) {
				// 分數為0、15、30、40，40分直接贏得此局
				//Boomtext.text = "floor 2";
				//判斷誰該加分
				if (flag == 0) {
					AddScore1();
				} else if (flag == 1) {
					AddScore2();
				}
				initial();
			}
		}
	}
	public void initial() {
		GOGO = false;

		//Ball
		//通過一個公式計算出初速度向量
		//Angle*Power
		dTime = 0;
		RandomZ();
		MoveSpeed = Quaternion.Euler(new Vector3(Angle, forwardangle, 0)) * Vector3.forward * Power;
		currentAngle = Vector3.zero;

		//Score
		touchfloor = 0;
		flag = 0;//預設玩家發球

		//讓球出現在拍子前
		x = player1.transform.position.x + 1.0f;
		y = player1.transform.position.y + 1.0f;
		z = player1.transform.position.z + 0.3f;
		transform.position = new Vector3(x, y, z);
	}

	// 再一局
	public void newgames() {
		if (playtimes >= 2) {
			//勝利
			GGtext.text = "You Win!";
		}
		if (computimes >= 2) {
			//敗北
			GGtext.text = "You Lose";
		}
		gametimes += 1;
		iscore1 = 0;
		iscore2 = 0;

		GOGO = false;

		//Ball
		//通過一個公式計算出初速度向量
		//Angle*Power
		dTime = 0;
		RandomZ();
		MoveSpeed = Quaternion.Euler(new Vector3(Angle, forwardangle, 0)) * Vector3.forward * Power;
		currentAngle = Vector3.zero;

		//Score
		touchfloor = 0;
		flag = 0;//預設玩家發球

		//讓球出現在拍子前
		x = player1.transform.position.x + 1.0f;
		y = player1.transform.position.y + 1.0f;
		z = player1.transform.position.z + 0.3f;
		transform.position = new Vector3(x, y, z);
	}
	public void RandomZ() {
		//改變球的方向
		forwardangle = Random.Range(-20, 20);
	}
	private void Check_OutsideLine() {
		if (transform.position.x > OutsideLineX1 || transform.position.x < OutsideLineX2
			|| transform.position.z > OutsideLineZ1 || transform.position.z < OutsideLineZ2) {
			//Debug.Log("Check_OutsideLine");
			if (flag == 0) {
				AddScore2();
			} else if (flag == 1) {
				AddScore1();
			}
			initial();
		}
	}
	public void AddScore1() {
		if (iscore1 == 30) {
			iscore1 = 40;
		} else if (iscore1 == 40) {
			// Boomtext.text = "You Win";
			playtimes += 1;
			if (gametimes == 1)
				score1_1.text = "WIN";
			else if (gametimes == 2)
				score1_2.text = "WIN";
			else if (gametimes == 3)
				score1_3.text = "WIN";
			newgames();
		} else {
			iscore1 += 15;
		}
		if (gametimes == 1)
			score1_1.text = iscore1.ToString();
		else if (gametimes == 2)
			score1_2.text = iscore1.ToString();
		else if (gametimes == 3)
			score1_3.text = iscore1.ToString();
	}
	public void AddScore2() {
		if (iscore2 == 30) {
			iscore2 = 40;
		} else if (iscore2 == 40) {
			//Boomtext.text = "You Lose";
			computimes += 1;
			if (gametimes == 1)
				score2_1.text = "WIN";
			else if (gametimes == 2)
				score2_2.text = "WIN";
			else if (gametimes == 3)
				score2_3.text = "WIN";
			newgames();
		} else {
			iscore2 += 15;
		}
		if (gametimes == 1)
			score2_1.text = iscore2.ToString();
		else if (gametimes == 2)
			score2_2.text = iscore2.ToString();
		else if (gametimes == 3)
			score2_3.text = iscore2.ToString();
	}
}