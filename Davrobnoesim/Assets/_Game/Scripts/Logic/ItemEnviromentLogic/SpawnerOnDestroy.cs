using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class SpawnerOnDestroy : MonoBehaviour, IDamagable
{
    [SerializeField] private int healthAmount = 100;
    [SerializeField] private GameObject enemyToSpawn = null;
    [SerializeField] private int enemyAmount = 1;
    [SerializeField] private float range = 1;

    public void DealDamage(int amount)
    {
        healthAmount -= amount;

        if (healthAmount <= 0)
        {
            for (int i = 0; i <= enemyAmount; i++)
            {
                float xOff = Random.value;
                float yOff = Random.value;
                Vector3 offset = new Vector3(xOff, yOff, 0);
                Instantiate(enemyToSpawn, transform.position + offset, Quaternion.identity);
            }

            Destroy(gameObject);
        }
    }
}

