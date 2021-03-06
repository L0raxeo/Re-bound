using UnityEngine;

public class PlayerBehavior : MonoBehaviour
{

    public Rigidbody2D rb;
    public Weapon weapon;
    public ThrowHook hook;
    public LevelManager levelManager;
    public ScoreManager scoreManager;

    public bool inGame = false;

    // For Destroyer powerup only
    public int destroyCount = 0;

    // Makes sure that the user is in the game to move and collide
    private void Update()
    {
        if (inGame)
        {
            CheckInput();
            scoreManager.UpdateScore(transform.position.y);
        }
        CheckScreenCollision();
    }

    // Movement
    private void Jump(Vector2 touchPosition)
    {
        float xThrust = -250f * (touchPosition.x - transform.position.x); // xSlope
        float yThrust = -250f * (touchPosition.y - transform.position.y); // ySlope

        // put a cap for terminal velocity

        if (xThrust < -500 && xThrust < 0)
            xThrust = -500;
        else if (xThrust > 500 && xThrust > 0)
            xThrust = 500;

        if (yThrust < -500 & yThrust < 0)
            yThrust = -500;
        else if (yThrust > 500 && yThrust > 0)
            yThrust = 500;

        rb.AddForce(new Vector2(xThrust, yThrust));
    }

    // Checks for touch input
    private bool touchedLastFrame = false;
    private void CheckInput()
    {
        // touchedLastFrame makes sure you can't hold down on screen to jump
        if (touchedLastFrame && Input.touchCount == 0)
        {
            touchedLastFrame = false;
            // destroys any existing grapling hooks
            Destroy(hook.curHook);
        }
        else if (!touchedLastFrame && Input.touchCount == 1)
        {
            touchedLastFrame = true;
            Touch touch = Input.GetTouch(0);
            Vector3 touchPosition = Camera.main.ScreenToWorldPoint(touch.position);
            touchPosition.z = 0f;
            if (hook.Throw(touchPosition))
                return;
            weapon.Use(touchPosition);
            Jump(touchPosition);
        }
    }

    // Checks if player is at the edge of the screen
    private void CheckScreenCollision()
    {
        Vector3 pos = Camera.main.WorldToViewportPoint(transform.position);

        if (pos.x < -0.05)
        {
            transform.position = new Vector3(Camera.main.ViewportToWorldPoint(new Vector2(1.05f, pos.y)).x, transform.position.y, transform.position.z);
            Destroy(hook.curHook);
        }

        if (1.05 < pos.x)
        {
            transform.position = new Vector3(Camera.main.ViewportToWorldPoint(new Vector2(0.05f, pos.y)).x, transform.position.y, transform.position.z);
            Destroy(hook.curHook);
        }
    }

    public void Respawn()
    {
        rb.velocity = Vector3.zero;
        rb.MoveRotation(0f);
        transform.position = new Vector3(0f, -12f, 0f);
    }

    public void Die()
    {
        GameObject.FindObjectOfType<AudioManager>().Play("Die_SFX", false);
        rb.velocity = Vector3.zero;
        rb.AddTorque(50f);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (destroyCount > 0 && collision.collider.tag == "Obstacle")
        {
            Destroy(collision.collider.gameObject);
            levelManager.m_camera.GetComponent<ScreenShakeController>().StartShake(0.75f, 0.5f);
            destroyCount--;
            return;
        }

        if (collision.collider.name == "Lava")
        {
            // pull up Game Over menu
        }
        else if (collision.collider.tag == "Obstacle")
        {
            levelManager.EndGame();
        }
        else if (collision.collider.tag == "Powerup")
        {
            collision.collider.GetComponentInParent<PowerupManager>().Use();
            GameObject.FindObjectOfType<AudioManager>().Play("Powerup_SFX", false);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (destroyCount > 0 && collision.tag == "Obstacle")
        {
            Destroy(collision.gameObject);
            levelManager.m_camera.GetComponent<ScreenShakeController>().StartShake(0.75f, 0.5f);
            destroyCount--;
            return;
        }

        if (collision.name == "Lava")
        {
            // pull up Game Over menu
        }
        else if (collision.tag == "Obstacle")
        {
            levelManager.EndGame();
        }
        else if (collision.tag == "Powerup")
        {
            GameObject.FindObjectOfType<AudioManager>().Play("Powerup_SFX", false);
            collision.GetComponentInParent<PowerupManager>().Use();
        }
    }

}
