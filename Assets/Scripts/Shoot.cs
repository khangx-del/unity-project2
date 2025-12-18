using System;
using UnityEngine;

public class Shoot : MonoBehaviour
{

    public float speed = 50f;
    private Rigidbody2D _rb;
    public float lifeTime = 10.0f;
    
    private void Awake()
    {
      _rb = GetComponent<Rigidbody2D>();  
      _rb.collisionDetectionMode = CollisionDetectionMode2D.Continuous;
    }

    public void Project(Vector2 direction)
    {
        _rb.linearVelocity = direction * this.speed;

        Destroy(this.gameObject, this.lifeTime);
    }

    
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Asteroid"))
        {
            Destroy(this.gameObject);          
            Destroy(collision.gameObject); 
        }
    }
}   

