using UnityEngine;
using UnityEngine.UI;

public class SelectArrows : MonoBehaviour {

	public Sprite arrowSprite;

	public GameObject selectIcons;

	public Sprite unlockedArrowSprite;//спрайт разблокированного скина
	public Image selectSprite;//объект выделения
	public bool click;//отслеживание нажатие на скин

	public GameObject iconsArray;
	public GameObject shopPreviewArrow;

	public float selectSpeed;//скорость, с которой перемещается объект выделения

    AudioManager audioManager;
	IconsArray iconsArrayScript;
	Image shopPreviewArrowSprite;

	Transform _selectTransform;
	Transform _transform;

	void Awake(){

		iconsArrayScript = iconsArray.GetComponent<IconsArray> ();
		shopPreviewArrowSprite = shopPreviewArrow.GetComponent<Image> ();

		if (PlayerPrefs.GetString ("Arrow") != "Open")
			PlayerPrefs.SetString ("Arrow", "Open");
		
		_selectTransform = selectSprite.transform;
		_transform = transform;

        audioManager = FindObjectOfType<AudioManager>();
	}

	//перемещение объекта выделения
	void Update(){

		if (click == true) {
			_selectTransform.position = Vector3.Lerp (_selectTransform.position, _transform.position, selectSpeed);
			iconsArrayScript.InteractebleOff ();
		}

		if (Vector2.Distance (_selectTransform.position, _transform.position) < 1) {
			click = false;
			iconsArrayScript.InteractebleOn ();
		}
	}

	void OnEnable(){
		click = false;
		iconsArrayScript.InteractebleOn ();
	}

	public void OnMouseUpAsButton(){
		click = true;

		iconsArrayScript.arrowName = gameObject.name;

		if (PlayerPrefs.GetString (gameObject.name) != "Close") {
			PlayerPrefs.SetString ("Now Arrow", gameObject.name);
			shopPreviewArrowSprite.sprite = arrowSprite;
            audioManager.Play("Click");//проигрываем щелчок
		}

	}
}
