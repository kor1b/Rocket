using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopButton : MonoBehaviour {

	public GameObject shopBG;

		public void OnMouseUpAsButton(){
			
			shopBG.SetActive (!shopBG.activeSelf);

	}
}
