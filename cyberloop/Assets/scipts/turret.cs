using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : MonoBehaviour
{
    public Transform ShootPoint;
    public GameObject bulletPrefab;
    public float bulletSpeed = 10f;
    public float shootInterval = 5f;
    public bool flipBulletSprite = false;

    private SpriteRenderer bulletSpriteRenderer;

    void Start()
    {
        bulletSpriteRenderer = bulletPrefab.GetComponent<SpriteRenderer>();
        InvokeRepeating("ShootBullet", 0f, shootInterval);
    }

    void ShootBullet()
    {
        GameObject newBullet = Instantiate(bulletPrefab, ShootPoint.position, Quaternion.identity);
        Bullet bulletComponent = newBullet.GetComponent<Bullet>();
        if (bulletComponent != null)
        {
            // Set bullet speed
            bulletComponent.speed = bulletSpeed;

            // Set bullet direction
            if (flipBulletSprite)
            {
                // Flip SpriteRenderer on the x-axis
                bulletSpriteRenderer.flipX = true;
                bulletComponent.direction = Vector2.left;
            }
            else
            {
                bulletSpriteRenderer.flipX = false;
                bulletComponent.direction = Vector2.right;
            }
        }
    }
}
