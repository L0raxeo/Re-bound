using UnityEngine;

public class PlayerBehavior : MonoBehaviour
{

    public Rigidbody2D rb;
    public Weapon weapon;
    public ThrowHook hook;
    public LevelManager levelManager;

    private bool touchedLastFrame = false;

    private void Update()
    {
        CheckInput();
        CheckScreenCollision();
    }

    private void Jump(Vector2 touchPosition)
    {
        float xThrust = -250 * (touchPosition.x - transform.position.x); // xSlope
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

    private void CheckInput()
    {
        if (touchedLastFrame && Input.touchCount == 0)
        {
            touchedLastFrame = false;
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

    public void Die()
    {
        rb.velocity = Vector3.zero;
        rb.AddTorque(50f);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.name == "Lava")
        {
            // pull up Game Over menu
        }
        else if (collision.collider.tag == "Obstacle")
        {
            // die
        }
        else if (collision.collider.tag == "Powerup")
        {
            
        }
    }

}
