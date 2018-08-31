using UnityEngine;
using UnityEngine.UI;

public class TapFlashController : MonoBehaviour {

    public Color flashColor;
    public float flashSpeed;
    public GameController gameController;
    Image image;
	public HazardController hazardController;

    private void Start()
    {
        image = GetComponent<Image>();
    }

	public void Flash()
	{
		image.color = flashColor;

	}

	void Update()
    {
        if (!gameController.gameHasEnded && hazardController.hazardsSpawned)
        {
            if (!Input.GetMouseButtonDown(0))
                image.color = Color.Lerp(image.color, Color.clear, flashSpeed * Time.deltaTime);
        }

        else
            image.color = Color.Lerp(image.color, Color.clear, flashSpeed * Time.deltaTime);
    }        
}
