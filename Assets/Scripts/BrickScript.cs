using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrickScript : MonoBehaviour
{
    public Transform Explosion;
    public int BrickPointValue;

    private void HitBrick(GameManager gameManager)
    {
        var explosion = Instantiate(Explosion, transform.position, transform.rotation);
        Destroy(explosion.gameObject, 2.5f);
        Destroy(gameObject);
        gameManager.UpdateScore(BrickPointValue);
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.transform.CompareTag("Ball"))
        {
            var ballScript = other.gameObject.GetComponent<BallScript>();
            HitBrick(ballScript.GameManager);
        }
    }
}
