using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Bullet : MonoBehaviour
{

    public RectTransform healthBar;

    void OnCollisionEnter(Collision collision)
    {
        var hit = collision.gameObject;
        var health = hit.GetComponent<Health>();

        if (health != null)
        {
            health.TakeDamage(10);
        }

        Destroy(gameObject);
    }

}
