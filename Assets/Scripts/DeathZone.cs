using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathZone : MonoBehaviour
{
    public GameObject Player;
    public HealthBar currenthealth;

    void OnTriggerEnter(Collider collider)
    {
        currenthealth.SetHealth(0);
        Destroy(collider.gameObject);
        SceneManager.LoadScene("Death");
        Cursor.lockState = CursorLockMode.Confined;
        Cursor.visible = true;
    }
}
