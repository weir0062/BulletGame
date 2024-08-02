using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PulyaBlya : MonoBehaviour
{
    public float maxLifetime = 5f;

    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, maxLifetime);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            Destroy(collision.gameObject);
            Destroy(gameObject);
        }
    }
}
