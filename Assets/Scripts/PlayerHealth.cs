using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{

    public int MaxHealth = 100;
    public int currentHealth;

    public HealthBar healthBar;

    public GameObject Player;

    void Start()
    {
        currentHealth = MaxHealth;
        healthBar.SetMaxHealth(MaxHealth);
    }


    void Update()
    {

        if (currentHealth <= 0)
        {

            if (Player.name.Equals("Player"))
            {
                SceneManager.LoadScene("Death");
                Cursor.lockState = CursorLockMode.Confined;
                Cursor.visible = true;

            }
            Debug.Log("Player died");

            Destroy(Player, 0.5f);
        }
    }

    


    public void TakeDamage(int damage)
    {

        currentHealth -= damage;

        healthBar.SetHealth(currentHealth);
    }
}
