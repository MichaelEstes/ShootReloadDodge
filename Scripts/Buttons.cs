using UnityEngine;
using System.Collections;

public class Buttons : MonoBehaviour {

	public Vector2 inputPos;
	public Touch touch;
	public PlayerScript player;

	void Start () {
	
	}
	
	void Update () {
		if(Application.platform == RuntimePlatform.Android){
			touch = Input.GetTouch (0);
			if(touch.phase == TouchPhase.Began){
				RaycastHit2D hitInfo = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(touch.position), Vector2.zero);
				if(hitInfo.collider != null)
				{
					if(hitInfo.collider.name == "ShootButton"){
						player.Shoot();
					}else if( hitInfo.collider.name == "DodgeButton"){
						player.Dodge();
					}else if(hitInfo.collider.name == "ReloadButton"){
						player.Reload();
					}
				}
			}
		}
		if(Input.GetMouseButtonDown(0))
		{
			RaycastHit2D hitInfo = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);
			if(hitInfo.collider != null)
			{
				if(hitInfo.collider.name == "ShootButton"){
					player.Shoot();
				}else if( hitInfo.collider.name == "DodgeButton"){
					player.Dodge();
				}else if(hitInfo.collider.name == "ReloadButton"){
					player.Reload();
				}
			}
		}
		if (Input.GetKeyDown(KeyCode.Escape)){
			Application.Quit(); 
		}
	}
}
