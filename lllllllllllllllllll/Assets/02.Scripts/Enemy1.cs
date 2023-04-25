using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy1 : Enemy
{
    // Start is called before the first frame update
    void Start()
    {
        Move();
    }

    void Move()
    {
        GetComponent<Rigidbody2D>().AddForce(Vector2.right * 50);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
