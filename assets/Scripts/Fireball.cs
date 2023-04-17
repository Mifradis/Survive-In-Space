using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fireball : MonoBehaviour
{
    float speed = 8;
    float visibleHeightThreshold;
    void Start()
    {
        visibleHeightThreshold = Camera.main.orthographicSize + transform.localScale.y;
    }

    // Update is called once per frame
    void Update()
    {
        if (gameObject.tag == "Fireball(blue)")
        {
            transform.Translate(Vector3.down * speed * Time.deltaTime);
            if (transform.position.y > visibleHeightThreshold)
            {
                Destroy(gameObject);
            }
        }
        if(gameObject.tag == "Fireball(red)")
        {
            transform.Translate(Vector3.down * speed * Time.deltaTime);
            if(transform.position.y < -visibleHeightThreshold)
            {
                Destroy(gameObject);
            }
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (gameObject.tag == "Fireball(red)")
        {
            if (collision.tag == "Player")
            {
                Destroy(gameObject);
            }
        }
        if (gameObject.tag == "Fireball(blue)")
        {
            if (collision.tag == "Enemy")
            {
                Destroy(gameObject);
            }
        }
    }
}
