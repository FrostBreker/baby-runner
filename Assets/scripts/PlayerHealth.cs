using UnityEngine;
using System.Collections;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 100;
    public int currentHealth;

    public float invincibilityTimeAfterHit = 3f;
    public float invincibilityFlashDelay = 0.2f;
    public bool isInvincible = false;

    public SpriteRenderer graphics;

    public HealthBar healthBar;

    public GameObject heartUpgradeUI;

    public static PlayerHealth instance;

    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogWarning("Il y a plus d'une instance de PlayerHealth dans la scène");
            return;
        }

        instance = this;
    }

    void Start()
    {
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.H))
        {
            TakeDamage(100);
        }

        if (currentHealth >= 100)
        {
            heartUpgradeUI.SetActive(true);
        }
        if (currentHealth <= 100)
        {
            heartUpgradeUI.SetActive(false);
        }
    }

    public void HealPlayer(int amount)
    {
            currentHealth += amount;

        healthBar.SetHealth(currentHealth);
    }


    public void TakeDamage(int damage)
    {
        if(!isInvincible)
        {
            currentHealth -= damage;
            healthBar.SetHealth(currentHealth);

            if(currentHealth <= 0)
            {
                Die();
                return;
            }

            isInvincible = true;
            StartCoroutine(InvincibilityFlash());
            StartCoroutine(HandleInvicibilityDelay());
        }
        
    }

    public void Die()
    {
        Debug.Log("Le joueur est mort");
        PlayerMovement.instance.enabled = false;
        PlayerMovement.instance.animator.SetTrigger("Death");
        PlayerMovement.instance.rb.bodyType = RigidbodyType2D.Kinematic;
        PlayerMovement.instance.rb.velocity = Vector3.zero;
        PlayerMovement.instance.playerCollider.enabled = false;
        MovementPlayerJoystick.instance.enabled = false;
        MovementPlayerJoystick.instance.animator.SetTrigger("Death");
        MovementPlayerJoystick.instance.rb.bodyType = RigidbodyType2D.Kinematic;
        MovementPlayerJoystick.instance.rb.velocity = Vector3.zero;
        MovementPlayerJoystick.instance.playerCollider.enabled = false;
        GameOverManager.instance.OnPlayerDeath();
    }

    public void Repsawn()
    {
        PlayerMovement.instance.enabled = true;
        PlayerMovement.instance.animator.SetTrigger("Respawn");
        PlayerMovement.instance.rb.bodyType = RigidbodyType2D.Dynamic;
        PlayerMovement.instance.playerCollider.enabled = true;
        MovementPlayerJoystick.instance.enabled = true;
        MovementPlayerJoystick.instance.animator.SetTrigger("Respawn");
        MovementPlayerJoystick.instance.rb.bodyType = RigidbodyType2D.Dynamic;
        MovementPlayerJoystick.instance.playerCollider.enabled = true;
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);

    }
    

    public IEnumerator InvincibilityFlash()
    {
        while (isInvincible)
        {
            graphics.color = new Color(1f, 1f, 1f, 0f);
            yield return new WaitForSeconds(invincibilityFlashDelay);
            graphics.color = new Color(1f, 1f, 1f, 1f);
            yield return new WaitForSeconds(invincibilityFlashDelay);
        }
    }

    public IEnumerator HandleInvicibilityDelay()
    {
        yield return new WaitForSeconds(invincibilityTimeAfterHit);
        isInvincible = false;
    }
}
