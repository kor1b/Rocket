using System.Collections.Generic;
using UnityEngine;

public class HazardController : MonoBehaviour
{
    bool tap = false;
    public float minLetSpeed = 4;
    public float maxLetSpeed = 8;

	float childCount;

    public GameController gameController;
    public PlayerController playerController;
    ObjectPooler objectPooler;

    List<GameObject> _spawnedHazardsFromPool;//кєшированный доступ к препятствиям в цикле
    GameObject downHazard;
    Transform child;
	AudioManager audioManager;
	bool soundEnabled;

	public bool hazardsSpawned;//метка о том, что на сцене есть препятствия

	private void Start()
    {
        objectPooler = ObjectPooler.Instance;
        _spawnedHazardsFromPool = objectPooler.spawnedHazards;
        audioManager = FindObjectOfType<AudioManager>();//доступ к звуку рывка
		if (audioManager.CheckEnabled("Dash"))
			soundEnabled = true;
		childCount = transform.childCount;
	}

    void Update()
    {
		if (_spawnedHazardsFromPool.Count != 0)
			hazardsSpawned = true;
		else
			hazardsSpawned = false;

		if (!gameController.gameHasEnded && hazardsSpawned)
		{
			downHazard = _spawnedHazardsFromPool[0];
			if (downHazard.transform.position.y < -3.9f)
			{
				tap = false;
				playerController.speed = playerController.maxSpeed;
				_spawnedHazardsFromPool.Remove(downHazard);
			}
		}

		if (Input.GetMouseButtonDown(0) && gameController.gameHasEnded == false && hazardsSpawned)
        {
			tap = true;
				if (soundEnabled)//если включен звук
					audioManager.Play("Dash");//проигрываем звук

				playerController.speed = 0f;
			
            for (int i = 0; i < _spawnedHazardsFromPool.Count; i++)
                _spawnedHazardsFromPool[i].GetComponent<LetMoving>().letSpeed = maxLetSpeed;
        }
		
        if (!tap)//устанавливает для всех препятствий одинаковую скорость
        {
				for (int i = 0; i < childCount; i++)
				{
					child = transform.GetChild(i);
					child.GetComponent<LetMoving>().letSpeed = minLetSpeed;
				}
			}
        
       

    }
}