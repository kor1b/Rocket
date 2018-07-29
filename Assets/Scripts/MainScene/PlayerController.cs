using UnityEngine;

public class PlayerController : MonoBehaviour {

	public float speed;
    public float maxSpeed = 10;
	public float speedStartPosition;

	public Vector2 leftMaxPos;
	public Vector2 rightMaxPos;
	public float minDistance = 0.1f;
	//public bool enterTheGate;
	bool direction = true;

	public static Sprite arrowSprite;
	public Sprite standartSprite;

	public GameController gameController;

	Vector3 _needPosition;//позиция, куда двигается стрелка к началу игры
	Transform _transform;

	void Start () {

		_transform = transform;
		_needPosition = new Vector3 (0, -2.5f, 0);

		//enterTheGate = false;

		GetComponent<SpriteRenderer> ().sprite = arrowSprite;

		if (PlayerPrefs.GetInt ("BuyArrowCount") != 1)
			GetComponent<SpriteRenderer> ().sprite = standartSprite;

	}
		
	void Update () {

		PlayerPrefs.SetString ("ReloadKey", "Zero");

		if (_transform.position.y != -2.5f) {
			_transform.position = Vector2.MoveTowards (_transform.position, _needPosition, Time.deltaTime * speedStartPosition);
		}
		else {

		if (direction){
				_transform.position = Vector2.MoveTowards (_transform.position, rightMaxPos, Time.deltaTime * speed);
				if (Vector2.Distance (_transform.position, rightMaxPos) < minDistance)
			direction =! direction;
	}

		if (!direction) {
				_transform.position = Vector2.MoveTowards (_transform.position, leftMaxPos, Time.deltaTime * speed);
				if (Vector2.Distance (_transform.position, leftMaxPos) < minDistance)
				direction =! direction;
		}

            //if (Input.GetMouseButtonDown(0))
             //   speed = 0f;
	}

	}

    /*void OnTriggerExit2D (Collider2D gate){
		if (gate.gameObject.CompareTag ("Gate")) {
			enterTheGate = true;

		}
	}*/

    void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.collider.CompareTag("Hazard") || coll.collider.CompareTag("CircleHazard"))

           gameController.EndGame();
    }
}
