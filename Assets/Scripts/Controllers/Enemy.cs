
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using TMPro;
using UnityEngine.SceneManagement;

public class Enemy : MonoBehaviour
{
    [SerializeField] ParticleSystem collectParticle = null;
    [SerializeField] public int AttackDamage = 10;
  
    public GameObject DamageIndicator;
    int damage = 20;
    public int maxHealth = 100;
    public int currentHealth;
    public HealthBar healthBar;

    public float lookRadius = 10f;

    Transform target;
    NavMeshAgent agent;

    //Attacking
    public float AttackSpeed = 1f;
    public float canAttack;
    public float AttackDistance = 3f;

    void Start()
    {

        target = PlayerManager.instance.player.transform;

        agent = GetComponent<NavMeshAgent>();
        
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);

    }

    void Update()
    {
        if (target != null)
        {
            
            float distance = Vector3.Distance(target.position, transform.position);

            if (distance <= lookRadius)
            {
                agent.SetDestination(target.position);

                if (distance <= agent.stoppingDistance)
                {
                    //Attacking player

                    if (AttackSpeed <= canAttack)
                    {
                        target.GetComponent<PlayerHealth>().TakeDamage(AttackDamage);
                        canAttack = 0f;
                    }

                    else
                        canAttack += Time.deltaTime;

                    //

                    FaceTarget();
                }

                else if (distance <= AttackDistance)
                {
                    if (AttackSpeed <= canAttack)
                    {
                        target.GetComponent<PlayerHealth>().TakeDamage(AttackDamage);
                        canAttack = 0f;
                    }

                    else
                        canAttack += Time.deltaTime;

                }
            }
            canAttack += Time.deltaTime;
        }

    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        healthBar.SetHealth(currentHealth);

        if (DamageIndicator && currentHealth >= 0)
        {
            ShowDamageTaken();
        }

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    void ShowDamageTaken()
    {
        GameObject go = Instantiate(DamageIndicator, transform.position, Quaternion.identity, transform);
        go.GetComponent<TextMeshPro>().text = damage.ToString();
         go.transform.LookAt(transform.position + target.forward);
        go.transform.localEulerAngles = new Vector3(0, 180, 0);
    }

    void Die()
    {

        //Add ragdoll

        GetComponent<Collider>().enabled = false;
        this.enabled = false;

        
        Destroy(gameObject, 0.5f);
        Collect();

        if (gameObject.name.Equals("BossPlaceholder"))
        {
            GameObject.Find("PlayerPrefabReal").SendMessage("Finish");
            
            SceneManager.LoadScene("Victory");
            Cursor.lockState = CursorLockMode.Confined;
            Cursor.visible = true;

            
        }
        
    }

    public void Collect()
    {
        //play graphics
        collectParticle.Play();
    }

    void FaceTarget()
    {
        Vector3 direction = (target.position - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * 5f);
    }

}
