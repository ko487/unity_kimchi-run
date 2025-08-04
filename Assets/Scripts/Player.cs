using UnityEngine;

public class Player : MonoBehaviour
{
    [Header("Settings")]
    public float JumpForce;

    [Header("References")]
    public Rigidbody2D playerRigidbody;
    public Animator playeranimator;
    public BoxCollider2D boxcolider2d;

    private bool isGrounded = true;
    private const int max_lives = 3;
    private int lives = max_lives;
    private bool isInvincible = false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            /*playerRigidbody.linearVelocityX = 1;
            playerRigidbody.linearVelocityY = 2;*/

            playerRigidbody.AddForceY(JumpForce, ForceMode2D.Impulse);
            isGrounded = false;
            playeranimator.SetInteger("state", 1);
        }
    }

    void KillPlayer()
    {
        boxcolider2d.enabled = false;
        playeranimator.enabled = false;
        playerRigidbody.AddForceY(JumpForce, ForceMode2D.Impulse);
    }

    void Hit()
    {
        lives -= 1;
        if (lives == 0)  // damaged & life check
        {
            KillPlayer();
        }
    }

    void Heal()
    {
        lives = Mathf.Min(max_lives, lives + 1);    // return which minimum
    }

    void StartInvincible()
    {
        isInvincible = true;
        Invoke("StopInvincible", 5f);
    }

    void StopInvincible()
    {
        isInvincible = false;
    }


    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "Platform")
        {
            if (!isGrounded)
            {
                playeranimator.SetInteger("state", 2);
            }
            isGrounded = true;
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            if (!isInvincible)
            {
                Destroy(collision.gameObject);
            } 
            Hit();
        }
        else if (collision.gameObject.tag == "food")
        {
            Destroy(collision.gameObject);
            Heal();
        }
        else if (collision.gameObject.tag == "golden")
        {
            Destroy(collision.gameObject);
            StartInvincible();
        }
    }
}
