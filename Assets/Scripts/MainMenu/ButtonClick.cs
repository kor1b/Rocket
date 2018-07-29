using UnityEngine;
using UnityEngine.EventSystems;

public class ButtonClick : EventTrigger{

    RectTransform _rectTransform;
    float standartWidth;
    float standartHeight;
    

    private void Start()
    {
        _rectTransform = GetComponent<RectTransform>();
        standartWidth = _rectTransform.rect.width;
        standartHeight = _rectTransform.rect.height;      
        
    }

    public void OnDown(){
        _rectTransform.sizeDelta = new Vector2(standartWidth * 0.9f, standartHeight * 0.9f);
    }

	public void OnUp(){
       _rectTransform.sizeDelta = new Vector2(standartWidth, standartHeight);
	}
}
