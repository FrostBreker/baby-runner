using System.Reflection;
using UnityEngine;

public class MovementPlayerJoystick : MonoBehaviour
{
    public float Speed;
    public float jumpForce;

    public int currentSpeed;

    bool Grounded = true;
    
    public Rigidbody2D rb;
    public Animator animator;
    public SpriteRenderer spriteRenderer;
    public CapsuleCollider2D playerCollider;

    public GameObject speedUpgradeUI;
    public GameObject jumpUpgradeUI;

    public static MovementPlayerJoystick instance;

    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogWarning("Il y a plus d'une instance de MovementPlayerJoystick dans la scène");
            return;
        }

        instance = this;
    }

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        float MoveX = SimpleInput.GetAxis("Horizontal");

        rb.velocity = new Vector2(MoveX * Speed, rb.velocity.y);

        if(Input.GetKeyDown(KeyCode.Space) && Grounded == true)
        {
            rb.AddForce(transform.up * jumpForce);
            Grounded = false;
        }

        if (Speed >= 8)
        {
            speedUpgradeUI.SetActive(true);
        }
        if (Speed <= 8)
        {
            speedUpgradeUI.SetActive(false);
        }

        if (jumpForce >= 250)
        {
            jumpUpgradeUI.SetActive(true);
        }
        if (jumpForce <= 250)
        {
            jumpUpgradeUI.SetActive(false);
        }
    }

    public void Jump()
    {
        if(Grounded == true)
        {
            rb.AddForce(transform.up * jumpForce);
            Grounded = false;
        }
    }

    public void SpeedPlayer(int amount)
    {
        Speed += amount;
    }

    public void IncreaseSpeedPlayer(int amount)
    {
        Speed -= amount;
    }

    public void JumpPlayer(int amount)
    {
        jumpForce += amount;
    }

    public void IncreaseJumpPlayer(int amount)
    {
        jumpForce -= amount;
    }

    private void OnCollisionEnter2D(Collision2D Col)
    {
        if(Col.gameObject.tag == "Ground")
        {
            Grounded = true;
        }
    }
}