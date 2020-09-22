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
        if (!BallInPlay)
        {
            transform.position = BallBookMark.position;
            Rigidbody2D.velocity = Vector2.zero;
        }

        if (Input.GetButtonDown("Jump") && !BallInPlay)
        {
            BallInPlay = true;
            Rigidbody2D.AddForce(Vector2.up * Speed);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("BottomBoundary"))
        {
            BallInPlay = false;
            GameManager.UpdateLives(-1);
        }
    }
}
