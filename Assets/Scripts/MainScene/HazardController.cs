using System.Collections.Generic;
using UnityEngine;

public class HazardController : MonoBehaviour
{
    bool tap = false;
    public float minLetSpeed = 4;
    public float maxLetSpeed = 8;

    public GameController gameController;
    public PlayerController playerController;
    ObjectPooler objectPooler;

    List<GameObject> _spawnedHazardsFromPool;//кєшированный доступ к препятствиям в цикле
    GameObject downHazard;
    Transform child;
    AudioManager audioManager;

    private void Start()
    {
        objectPooler = ObjectPooler.Instance;
        _spawnedHazardsFromPool = objectPooler.spawnedHazards;
        audioManager = FindObjectOfType<AudioManager>();//доступ к звуку рывка
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0) && gameController.gameHasEnded == false)
        {
            tap = true;
            audioManager.Play("Dash");//проигрываем звук
            playerController.speed = 0f;
            for (int i = 0; i < _spawnedHazardsFromPool.Count; i++)
                _spawnedHazardsFromPool[i].GetComponent<LetMoving>().letSpeed = maxLetSpeed;
        }

        if (!tap)//устанавливает для всех препятствий одинаковую скорость
        {
            for (int i = 0; i < transform.childCount; i++)
            {
                child = transform.GetChild(i);
                child.GetComponent<LetMoving>().letSpeed = minLetSpeed;
            }
        }

        if (!gameController.gameHasEnded && _spawnedHazardsFromPool.Count != 0)
        {
            downHazard = _spawnedHazardsFromPool[0];
            if (_spawnedHazardsFromPool[0].transform.position.y < -3.25f)
            {
                tap = false;
                playerController.speed = playerController.maxSpeed;
                _spawnedHazardsFromPool.Remove(downHazard);
            }
        }

    }
}
