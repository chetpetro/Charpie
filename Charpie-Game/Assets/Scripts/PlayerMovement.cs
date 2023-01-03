using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
 
    public Rigidbody2D Rb;
    private Vector2 moveDirection;
    private Vector2 mousePosition;
    private float shotDelay;
    private PlayerStats playerStats;

    public Weapon weapon;
    private EnemyHit enemyHit;
    private GameObject[] enemyList;

    public Animator animator;

    private void Start()
    {
        playerStats = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerStats>();
        shotDelay = playerStats.shotDelayReset;
    }

    // Update is called once per frame
    void Update()
    {
        ProcessInputs();

        if(shotDelay > 0)
        {
            shotDelay -= Time.deltaTime;
        }
    }

    void FixedUpdate()
    {
        Move();
    }

    void ProcessInputs()
    {
        float moveX = Input.GetAxisRaw("Horizontal");
        float moveY = Input.GetAxisRaw("Vertical");

        animator.SetFloat("Horizontal", moveX);
        animator.SetFloat("Vertical", moveY);
        animator.SetFloat("Speed", moveDirection.sqrMagnitude);

        moveDirection = new Vector2(moveX, moveY);
        mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        if (Input.GetMouseButtonDown(0) && shotDelay <= 0)
        {
            weapon.Fire();
            shotDelay = playerStats.shotDelayReset;
        }
    }

    void Move()
    {
        Rb.velocity = new Vector2(moveDirection.x * playerStats.playerMovementSpeed, moveDirection.y * playerStats.playerMovementSpeed);

        Vector2 aimDirection = mousePosition - Rb.position;
        float aimAngle = Mathf.Atan2(aimDirection.y, aimDirection.x) * Mathf.Rad2Deg - 90f;
        Rb.rotation = aimAngle;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.tag == "Enemy")
        {
            enemyList = GameObject.FindGameObjectsWithTag("Enemy");
            for (int i = 0; i < enemyList.Length; i++)
            {
                enemyHit = enemyList[i].GetComponent<EnemyHit>();
            }

            InvokeRepeating("DamagePlayer", 0f, enemyHit.hitSpeed);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {

        if (collision.gameObject.tag == "Enemy")
        {
            CancelInvoke("DamagePlayer");
        }
    }

    public void DamagePlayer()
    {
        playerStats.playerHeath -= 1;
    }

}
