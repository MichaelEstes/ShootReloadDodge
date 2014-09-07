using UnityEngine;
using System.Collections;

public class StartScript : MonoBehaviour {

	public Touch touch;
	public TextMesh startText;
	private int maxConsecutiveWins;

	void Start () {
		if(Application.loadedLevel == 0){
			startText.renderer.sortingLayerName = "UI";
			maxConsecutiveWins = PlayerPrefs.GetInt ("MaxConsecutiveWins");
			startText.text = "High Score: " + maxConsecutiveWins.ToString();
		}
	}
	
	void Update () {
		if(Application.loadedLevel == 0){
			if(Application.platform == RuntimePlatform.Android){
				touch = Input.GetTouch (0);
				if(touch.phase == TouchPhase.Began){
					Application.LoadLevel(1);
				}
			}
			if (Input.GetMouseButtonDown (0)) {
				Application.LoadLevel(1);
			}
			if (Input.GetKeyDown(KeyCode.Escape)){
				Application.Quit(); 
			}
		}
	}
}
