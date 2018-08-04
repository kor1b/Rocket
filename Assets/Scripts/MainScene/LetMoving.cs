using UnityEngine;
using System;

public class LetMoving : MonoBehaviour//, IPooledObject
{
    Transform _transform;

    [HideInInspector]
    public float letSpeed;

    public float lerpSpeed = 2f;

    Rigidbody2D _rb;
    SpriteRenderer _spriteRenderer;

    GameController gameController;

    void Start()
    {
        _transform = transform;

        GameObject gameControllerObject = GameObject.FindWithTag("GameController");
        if (gameControllerObject != null)
            gameController = gameControllerObject.GetComponent<GameController>();

        _rb = GetComponent<Rigidbody2D>();
        _spriteRenderer = GetComponent<SpriteRenderer>();

    }

    private void FixedUpdate()
    {
        _rb.velocity = Vector2.down * letSpeed;
    }

    void Update()
    {
		if (_transform.position.y < -10)
		{
			gameObject.SetActive(false);
		}
        //при проигрыше выставляет альфа канал препятствий на 0
        if (gameController.gameHasEnded)
        {
           _spriteRenderer.color = Color.Lerp(_spriteRenderer.color, Color.clear, Time.deltaTime * lerpSpeed);

        }
    }
 }
