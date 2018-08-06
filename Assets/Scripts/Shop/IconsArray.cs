using UnityEngine;
using UnityEngine.UI;

public class IconsArray : MonoBehaviour {

	public Button[] arrowsIcons;
	public string arrowName;
	public Image selectSprite;//объект выделения
	public Image previewArrowSprite;//спрайт показа скина 
    Transform _selectSpriteTransform;
    Transform _previewArrowSpriteTransform;

    private void Awake()
    {
        _selectSpriteTransform = selectSprite.transform;
        _previewArrowSpriteTransform = previewArrowSprite.transform;
    }

    void OnEnable(){
		/*PlayerPrefs.SetInt("AllSkinsBought", 0);
		PlayerPrefs.SetInt ("HighScore", 0);//обнуление highscore
        PlayerPrefs.SetInt("Coins", 4500);
        PlayerPrefs.SetString(arrowsIcons[1].name, "Close");
         PlayerPrefs.SetString (arrowsIcons[0].name, "Open");
             PlayerPrefs.SetString ("Arrow (1)", "Close");
             PlayerPrefs.SetString ("Arrow (2)", "Close");
         PlayerPrefs.SetString (arrowsIcons[3].name, "Close");
             PlayerPrefs.SetString ("Arrow (4)", "Close");
             PlayerPrefs.SetString ("Arrow (5)", "Close");
             PlayerPrefs.SetString ("Arrow (6)", "Close");
             PlayerPrefs.SetString ("Arrow (7)", "Close");
             PlayerPrefs.SetString ("Arrow (8)", "Close");

         
        PlayerPrefs.SetInt ("BuyArrowCount", 0);
         PlayerPrefs.SetString ("Now Arrow", "Arrow"); //нужно зайти в магазин, чтобы поменялась стрелка в главном меню*/
         

		_selectSpriteTransform.position = _previewArrowSpriteTransform.position;

		for (int k = 1; k < arrowsIcons.Length; k++) {
			if (PlayerPrefs.GetString (arrowsIcons [k].name, "Close") == "Open")
				arrowsIcons [k].GetComponent<Image> ().sprite = arrowsIcons [k].GetComponent<SelectArrows> ().unlockedArrowSprite;
		} 
	}

	public void InteractebleOn(){
		for (int i = 0; i < arrowsIcons.Length; i++) {
			arrowsIcons [i].GetComponent<Button> ().interactable = true;
		}
	}


	public void InteractebleOff(){
		for (int i = 0; i < arrowsIcons.Length; i++) {
			arrowsIcons [i].GetComponent<Button> ().interactable = false;
		}
	}
}
