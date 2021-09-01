using System.Collections;
using UnityEngine;

public class JumpPowerUP : MonoBehaviour
{
    public int jumpPoints = 5;

    public float jumpTimeAfterHit = 3f;

    public SpriteRenderer spriteRenderer;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            StartCoroutine(TimerSpeedEffect());
        }
    }

    IEnumerator TimerSpeedEffect()
    {
        gameObject.GetComponent<SpriteRenderer>().enabled = false;
        gameObject.GetComponent<CircleCollider2D>().enabled = false;
        MovementPlayerJoystick.instance.JumpPlayer(jumpPoints);
        yield return new WaitForSeconds(jumpTimeAfterHit);
        MovementPlayerJoystick.instance.IncreaseJumpPlayer(jumpPoints);
        Destroy(gameObject);
    }
}
