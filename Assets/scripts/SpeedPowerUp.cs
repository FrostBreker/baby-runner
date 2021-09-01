using System.Collections;
using UnityEngine;

public class SpeedPowerUp : MonoBehaviour
{
    public int speedPoints = 5;

    public float speedTimeAfterHit = 3f;

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
        MovementPlayerJoystick.instance.SpeedPlayer(speedPoints);
        yield return new WaitForSeconds(speedTimeAfterHit);
        MovementPlayerJoystick.instance.IncreaseSpeedPlayer(speedPoints);
        Destroy(gameObject);
    }
}
