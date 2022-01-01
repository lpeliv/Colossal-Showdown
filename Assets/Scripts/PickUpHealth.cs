using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpHealth : MonoBehaviour
{
    public HealthBar Health;
    public GameObject Player;
    public GameObject Bottle;

    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject == Player)
        {
            other.GetComponent<PlayerHealth>().currentHealth = 100;
            Health.SetHealth(100);
            Destroy(Bottle);
        }
    }
}
