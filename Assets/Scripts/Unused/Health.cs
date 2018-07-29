using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Health : MonoBehaviour {

	public GameController gameController;
	public GameObject player;

	public Color startPlayerColor;
	public Color playerOverheat;

	public Image overheatFlash;
	public Color overheatColor;
	public float flashSpeed;
	public float healthPoints;
	public float speed;
	public float damage_heal;

	public float timer;

	Slider slider;

	void Awake () {

		startPlayerColor = player.GetComponent<SpriteRenderer> ().color;
		slider = GetComponent<Slider> ();
		slider.value = 0f;
		healthPoints = 0f;

	}
	
	void Update () {
		timer += Time.deltaTime;
		if (timer >= 2f && player != null) {
			if (!Input.GetMouseButton (0)) {

				player.GetComponent<SpriteRenderer> ().color = Color.Lerp (player.GetComponent<SpriteRenderer> ().color, startPlayerColor, Time.deltaTime * speed);

				//healthPoints--;
				//slider.value -= damage_heal;
				//slider.value = Mathf.Lerp (healthPoints, 0, Time.deltaTime * speed);
				//healthPoints = slider.value;
			}

			if (Input.GetMouseButton (0)) {

				player.GetComponent<SpriteRenderer> ().color = Color.Lerp (player.GetComponent<SpriteRenderer> ().color, playerOverheat, Time.deltaTime * speed);

				//healthPoints++;
				//slider.value = Mathf.Lerp (healthPoints, 100, Time.deltaTime * speed);
				//slider.value += damage_heal;
				//healthPoints =lider.value;
			}

			if (CompareColors (player.GetComponent<SpriteRenderer> ().color, playerOverheat)) {
				gameController.gameHasEnded = true;
				overheatFlash.color = overheatColor;

				gameController.EndGame ();
			}

			if (gameController.gameHasEnded == true)
				overheatColor = Color.Lerp (overheatColor, Color.clear, flashSpeed * Time.deltaTime);
		 }
		}
		
	public bool CompareColors (Color a, Color b){
	
		float delta = 0.01f;
		bool result = false;

		if ((a.r - b.r) < delta)
			if ((a.g - b.g) < delta) 
				if ((a.b - b.b) < delta)
			        result = true;

		return result;
	 
	
	}
}

	
		

