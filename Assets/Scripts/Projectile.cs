using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    Rigidbody2D rigidbody2d;
    // Awake is called when the projectile GameObject is istatiated
    void Awake()
    {
        rigidbody2d = GetComponent<Rigidbody2D>();
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Launch(Vector2 direction, float force)
    {
        rigidbody2d.AddForce(direction * force);
    }
    
    void OntriggerEnter2D(Collider2D other)
    {
        Debug.Log("Projectile collision with" + other.gameObject);
        Destroy( gameObject);

    }

}
