using UnityEngine;
using UnityEngine.UI;
using System;

public class ArrowSprite : MonoBehaviour
{
    public GameObject[] arrows;
    Image _image;
    GameObject arrow;

    private void Awake()
    {
        _image = GetComponent<Image>();
        if (PlayerPrefs.GetInt("BuyArrowCount") != 1)
            _image.sprite = arrows[0].GetComponent<Image>().sprite;
    }

    void OnEnable()
    {
        GameObject selArr = Array.Find(arrows, arrow => PlayerPrefs.GetString("Now Arrow") == arrow.name);

        _image.sprite = selArr.GetComponent<SelectArrows>().arrowSprite;
        PlayerController.arrowSprite = selArr.GetComponent<SelectArrows>().arrowSprite;

    }
}

	


