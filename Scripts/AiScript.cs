using UnityEngine;
using System.Collections;

public class AiScript : MonoBehaviour {

	public int aiAmmo;
	public int randomState;
	public TextMesh aiAmmoText;
	public Animator aiAnimator;


	void Start () {
		aiAmmo = 0;
		SetAiText (aiAmmoText, aiAmmo);

	}
	
	void Update () {
	
	}

	void SetAiText(TextMesh text, int setText){
		text.text = setText.ToString ();
	}

	public virtual void NewRound(int playerAmmo){
		if(aiAmmo == 0){
			randomState = Random.Range(1,3);
			if(playerAmmo == 0){
				randomState = 1;
			}
			ChooseState(randomState);
		}else{
			randomState = Random.Range(1,4);
			ChooseState(randomState);
		}
	}

	void ChooseState(int stateNum){
		if(stateNum == 1){
			AiReload();
		}else if(stateNum == 2){
			AiDodge();
		}else if(stateNum == 3){
			AiShoot();
		}
	}

	void AiReload(){
		aiAmmo += 1;
		SetAiText (aiAmmoText, aiAmmo);
		aiAnimator.SetTrigger ("AiReloadTrigger");
	}

	void AiShoot(){
		aiAmmo -= 1;
		SetAiText (aiAmmoText, aiAmmo);
		aiAnimator.SetTrigger ("AiShootTrigger");
	}

	void AiDodge(){
		aiAnimator.SetTrigger ("AiDodgeTrigger");
	}

	public virtual void Death(){
		aiAnimator.SetTrigger ("AiDeathTrigger");
	}

}
