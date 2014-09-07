using UnityEngine;
using System.Collections;

public class Scoring : MonoBehaviour {

	public bool gameOver = false;
	public bool didWin;
	public static int consecutiveWins = 0;
	public int maxConsecutiveWins;
	public Touch touch;
	public TextMesh roundText;

	void Start () {
		maxConsecutiveWins = PlayerPrefs.GetInt ("MaxConsecutiveWins");
	}
	
	void Update () {
		if(gameOver){
			roundText.text = "Game Over";
			if(Application.platform == RuntimePlatform.Android){
				touch = Input.GetTouch (0);
				if(touch.phase == TouchPhase.Began){
					if(!didWin){
						Application.LoadLevel(0);
					}else{
						Application.LoadLevel(1);
					}
				}
			}
			if (Input.GetMouseButtonDown (0)) {
				if(!didWin){
					Application.LoadLevel(0);
				}else{
					Application.LoadLevel(1);
				}
			}
		}

	}

	public virtual void GameOver(bool won){
		GameObject.FindGameObjectWithTag ("Player").GetComponent<PlayerScript> ().enabled = false;
		GameObject.FindGameObjectWithTag ("Player").GetComponent<Buttons> ().enabled = false;
		gameOver = true;
		didWin = won;
		if(!won){
			consecutiveWins = 0;
		}else if(won){
			consecutiveWins++;
			if(consecutiveWins > maxConsecutiveWins){
				PlayerPrefs.SetInt("MaxConsecutiveWins", consecutiveWins);
			}
		}
	}
}
