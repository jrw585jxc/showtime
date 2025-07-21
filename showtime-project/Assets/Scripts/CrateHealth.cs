using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrateHealth : MonoBehaviour
{
    public float initialHealth = 100;
    public float currentHealth;
    // Start is called before the first frame update
    void Start()
    {
        currentHealth = initialHealth;
    }

    // Update is called once per frame
    public void TakeDamage(float damage)
    {
        currentHealth -= damage;
        if (currentHealth <= 0) { Destroy(gameObject); }
    }
}
