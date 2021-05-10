using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{

    public GameObject player;
    public GameObject bullet;
    public GameObject muzzle;

    public ParticleSystem explosion;

    public Vector2 targetPosition;
    private Vector2 baseTouchPosition;

    private void Update()
    {
        baseTouchPosition = new Vector2(transform.position.x, -15f);
    }

    public void Use(Vector2 targetPosition)
    {
        this.targetPosition = targetPosition;

        RotateWeapon();
        Shoot();
    }

    public void Shoot()
    {
        Instantiate(bullet, muzzle.transform.position, Quaternion.Euler(0f, 0f, transform.rotation.z + GetAngleToPosition(targetPosition)));
        explosion.Clear();
        explosion.Play();
    }

    public void RotateWeapon()
    {
        transform.rotation = Quaternion.Euler(0f, 0f, transform.rotation.z + GetAngleToPosition(targetPosition));
    }

    private float GetAngleToPosition(Vector2 targetPosition)
    {
        float sideA = GetSide(player.transform.position, baseTouchPosition);
        float sideB = GetSide(player.transform.position, targetPosition);
        float sideC = GetSide(baseTouchPosition, targetPosition);

        float angle = GetTargetAngle(sideA, sideB, sideC) * Mathf.Rad2Deg;

        if (targetPosition.x < player.transform.position.x)
            angle = angle * -1;

        return angle;
    }

    private float GetSide(Vector2 pointA, Vector2 pointB)
    {
        // Mathf.Sqrt(Mathf.Pow((pointA.x - pointB.x), 2) + Mathf.Pow(pointA.y - pointB.y, 2)) // distance formula
        return Vector2.Distance(pointA, pointB);
    }

    private float GetTargetAngle(float a, float b, float c)
    {
        float aSquared = Mathf.Pow(a, 2f);
        float bSquared = Mathf.Pow(b, 2f);
        float cSquared = Mathf.Pow(c, 2f);

        return Mathf.Acos((aSquared + bSquared - cSquared) / (2 * a * b));
    }

}
