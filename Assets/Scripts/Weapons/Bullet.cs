using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [Header("Settings")]
    public float speed = 10f;
    public float lifeTime = 10;
    public int damage = 10;

    private void Awake()
    {
        Destroy(gameObject, lifeTime);
    }


    private void Update()
    {
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }


    private void OnCollisionEnter(Collision collision)
    {
        Damageable damageable = collision.gameObject.GetComponent<Damageable>();

        if (damageable != null)
        {
            damageable.ApplyDamage(damage);
        }

        Destroy(gameObject);
    }
}
