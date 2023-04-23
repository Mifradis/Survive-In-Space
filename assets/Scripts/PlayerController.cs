using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class PlayerController : MonoBehaviour
{
    float speed = 6;
    public GameOver endOfGame;
    float screenWidthWithWorldUnits;
    float screenHeightWithWorldUnits;
    private void Start()
    {
        float halfPlayerHeight = transform.localScale.y / 2f;
        float halfPlayerWidth = transform.localScale.x/2f -1;
        screenHeightWithWorldUnits = Camera.main.aspect * Camera.main.orthographicSize + halfPlayerHeight;
        screenWidthWithWorldUnits = Camera.main.aspect * Camera.main.orthographicSize + halfPlayerWidth;
    }

    void Update()
    {
        Vector2 input = new Vector2 (Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        Vector2 velocity = input * speed;
        transform.Translate((-1) * velocity * Time.deltaTime);
        if (Input.GetKeyDown(KeyCode.Space))
        {
            FindObjectOfType<ShootingManagerForPlayer>().Shooting();
        }
        if(transform.position.x > screenWidthWithWorldUnits)
        {
            transform.position = new Vector2(screenWidthWithWorldUnits, transform.position.y);
        }
        if(transform.position.x < -screenWidthWithWorldUnits)
        {
            transform.position = new Vector2(-screenWidthWithWorldUnits, transform.position.y);
        }
        if(transform.position.y > screenHeightWithWorldUnits)
        {
            transform.position = new Vector2(transform.position.x, screenHeightWithWorldUnits);
        }
        if(transform.position.y < -screenHeightWithWorldUnits)
        {
            transform.position = new Vector2(transform.position.x, -screenHeightWithWorldUnits);
        }
        
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Fireball(red)")
        {
            Camera.main.DOShakePosition(0.5f, 0.3f);
            Destroy(gameObject);
            endOfGame.OnGameOver();
        }
    }
}
