using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallScript : MonoBehaviour
{
    public float Speed;
    public bool BallInPlay;
    public Transform BallBookMark;
    public GameManager GameManager;
    private Rigidbody2D Rigidbody2D;

    void Start()
    {
        Rigidbody2D = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (GameManager.IsGameOver)
        {
            return;
        }

        if (!BallInPlay)
        {
            transform.position = BallBookMark.position;
        }

        if (Input.GetButtonDown("Jump") && !BallInPlay)
        {
            BallInPlay = true;
            Rigidbody2D.AddForce(Vector2.up * Speed);
        }
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.transform.CompareTag("Brick"))
        {
            var brickScript = other.gameObject.GetComponent<BrickScript>();
            GameManager.UpdateScore(brickScript.BrickPointValue);
            brickScript.HitBrick();
            GameManager.UpdateNumberOfBricks();
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("BottomBoundary"))
        {
            BallInPlay = false;
            Rigidbody2D.velocity = Vector2.zero;

            GameManager.UpdateLives(-1);
        }
    }
}
