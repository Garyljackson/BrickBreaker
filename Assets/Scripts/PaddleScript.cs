using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaddleScript : MonoBehaviour
{
    public float Speed;
    public float LeftScreenBoundary;
    public float RightScreenBoundary;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");

        transform.Translate(Vector2.right * horizontal * Time.deltaTime * Speed);

        if(transform.position.x < LeftScreenBoundary){
            transform.position = new Vector2(LeftScreenBoundary, transform.position.y);
        }

        if(transform.position.x > RightScreenBoundary){
            transform.position = new Vector2(RightScreenBoundary, transform.position.y);
        }
    }
}
