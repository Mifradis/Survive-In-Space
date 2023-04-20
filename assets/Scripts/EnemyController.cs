using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public GameObject leftGun;
    int kills;
    public GameObject rightGun;
    public Vector2 speedMinMax;
    float speed;
    float enemyMovementRangeHeight;
    float enemyMovementRangeWidth;
    float verticalPosition = 1;
    float horizontalPosition = 1;
    void Start()
    {
        speed = Mathf.Lerp(speedMinMax.x, speedMinMax.y, Difficulty.GetDifficultyPercent());
        enemyMovementRangeHeight = Camera.main.orthographicSize / 2f;
        enemyMovementRangeWidth = Camera.main.orthographicSize * Camera.main.aspect;
        Physics2D.queriesStartInColliders = false;
    }

    
    void Update()
    {
        enemyMovement();
        enemyShooting();
    }
    void enemyMovement()
    {
        Vector2 enemyMove = new Vector2(horizontalPosition, verticalPosition);
        Vector2 displacmentToTarget = enemyMove.normalized;
        Vector2 velocity = displacmentToTarget * speed;
        transform.Translate(velocity * Time.deltaTime);
        //Enemy ship can move in Main Camera 
        if (enemyMovementRangeHeight >= transform.position.y)
        {
            verticalPosition = 1;
        }
        if (enemyMovementRangeHeight * 2 <= transform.position.y)
        {
            verticalPosition = -1;
        }
        if (enemyMovementRangeWidth < transform.position.x)
        {
            horizontalPosition = -1;
        }
        if (-enemyMovementRangeWidth > transform.position.x)
        {
            horizontalPosition = 1;
        }
    }
    void enemyShooting()
    {
        RaycastHit2D hitInfoLeft = Physics2D.Raycast(leftGun.transform.position, -transform.up, 100);
        RaycastHit2D hitInfoRight = Physics2D.Raycast(rightGun.transform.position, -transform.up, 100);
        if (hitInfoLeft.collider != null)
        {
            if (hitInfoLeft.collider.tag == "Player")
            {
                FindObjectOfType<ShootingManagerForEnemy>().Shooting();
            }
        }        
        if (hitInfoRight.collider != null)
        {
            if (hitInfoRight.collider.tag == "Player")
            {
                FindObjectOfType<ShootingManagerForEnemy>().Shooting();
            }
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Fireball(blue)")
        {
            Destroy(gameObject);
            setKills(kills + 1);
        }
    }
    public int getKills()
    {
        return kills;
    }
    public void setKills(int newKills)
    {
        kills = newKills;
    }
}
