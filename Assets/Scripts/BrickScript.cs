using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrickScript : MonoBehaviour
{
    public Transform Explosion;
    public int BrickPointValue;

    public void HitBrick()
    {
        var explosion = Instantiate(Explosion, transform.position, transform.rotation);
        Destroy(explosion.gameObject, 2.5f);
        Destroy(gameObject);
    }
}
