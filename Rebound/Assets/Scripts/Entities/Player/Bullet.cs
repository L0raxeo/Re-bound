using UnityEngine;

public class Bullet : MonoBehaviour
{

    public Rigidbody2D rb;

    public GameObject explosion;

    private Weapon weapon;
    private Vector2 targetPosition;
    private Vector3 lastPosition;

    void Start()
    {
        weapon = GameObject.FindObjectOfType<Weapon>();
        targetPosition = weapon.targetPosition;
    }

    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, targetPosition, 50f * Time.deltaTime);
        if (transform.position == lastPosition) Die();
        else lastPosition = transform.position;
    }

    private void Die()
    {
        Instantiate(explosion, transform.position, Quaternion.identity);
        GameObject.FindObjectOfType<AudioManager>().Play("Explosion_SFX", false);
        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Die();
    }

}
