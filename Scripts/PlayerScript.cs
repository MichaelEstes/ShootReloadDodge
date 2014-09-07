using UnityEngine;
using System.Collections;

public class PlayerScript : MonoBehaviour {

	public bool won;
	public int ammo;
	public int round;
	public int newRound;
	public enum State{start, shooting, dodging, reloading, gameOver};
	public State state;
	public TextMesh ammoText;
	public TextMesh roundText;
	public Animator playerAnimator;
	public AiScript ai;
	public Scoring score;


	
	void Start () {
		won = false;
		ammo = 0;
		round = 0;
		newRound = 0;
		ammoText.renderer.sortingLayerName = "UI";
		roundText.renderer.sortingLayerName = "UI";
		if(Application.loadedLevel != 0){
			SetText(ammoText, ammo.ToString());
			SetText(roundText, "Round: " + round.ToString());
		}
		state = State.start;
	}
	
	void Update () {
		if(round > newRound){
			SetText(roundText, "Round: " + round.ToString());
			newRound = round;
			ai.NewRound(ammo);
			if(state == State.shooting){
				ammo -= 1;
				SetText(ammoText, ammo.ToString());
				playerAnimator.SetTrigger("PlayerShootTrigger");
			}else if(state == State.dodging){
				playerAnimator.SetTrigger("PlayerDodgeTrigger");
			}else if(state == State.reloading){
				ammo += 1;
				SetText(ammoText, ammo.ToString());
				playerAnimator.SetTrigger("PlayerReloadTrigger");
			}
			CheckState();
		}
	}

	void CheckState(){
		if(ai.randomState == 1 && state == State.shooting){
			won = true;
			state = State.gameOver;
			ai.Death();
		}else if(state == State.reloading && ai.randomState == 3){
			won = false;
			state = State.gameOver;
			playerAnimator.SetTrigger("PlayerDeathTrigger");
		}
		if(state == State.gameOver){
			score.GameOver(won);
		}

	}
	
	void SetText(TextMesh text,string setText){
		text.text = setText;
	}

	void AdvanceRound(){
		round++;
	}
	
	public virtual void Shoot(){
		if(ammo > 0){
			state = State.shooting;
			AdvanceRound();
		}
		
	}
	
	public virtual void Dodge(){
		state = State.dodging;
		AdvanceRound();
	}
	
	public virtual void Reload(){
		state = State.reloading;
		AdvanceRound();
	}
}
