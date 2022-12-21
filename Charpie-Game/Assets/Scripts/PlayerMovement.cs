using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed;
    public Rigidbody2D Rb;
    private Vector2 moveDirection;
    private Vector2 mousePosition;
    private float shotDelay;
    public float shotDelayReset;
    private PlayerStats playerStats;

    public Weapon weapon;

    public Animator animator;

    private void Start()
    {
        shotDelay = shotDelayReset;
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
            shotDelay = shotDelayReset;
        }
    }

    void Move()
    {
        Rb.velocity = new Vector2(moveDirection.x * moveSpeed, moveDirection.y * moveSpeed);

        Vector2 aimDirection = mousePosition - Rb.position;
        float aimAngle = Mathf.Atan2(aimDirection.y, aimDirection.x) * Mathf.Rad2Deg - 90f;
        Rb.rotation = aimAngle;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.tag == "Enemy")
        {
            InvokeRepeating("DamagePlayer", 0f, 1f);
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
        playerStats = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerStats>();
        playerStats.playerHeath -= 1;
    }

}
