using UnityEngine;
using UnityEngine.UI;

public class HandleColor : MonoBehaviour {

	public Slider slider;

	public Color ONColor;
	public Color OFFColor;

	Image handle;

	private void Start()
	{
		handle = GetComponent<Image>();
		ChangeColor();
	}

	public void ChangeColor()
	{
		if (slider.value == 1)
			handle.color = ONColor;
		else
			handle.color = OFFColor;
	}
}
