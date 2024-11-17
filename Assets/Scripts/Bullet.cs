using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float lifetime = 2.0f;
    public float speed = 15f;
    
    void Start()
    {
        Destroy(gameObject, lifetime);
    }

    
    void Update()
    {
        transform.position += transform.forward * speed * Time.deltaTime;
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Player")
        {
            other.gameObject.GetComponent<Health>().TakeDamage(10);
        }
        Destroy(gameObject);
    }
}
