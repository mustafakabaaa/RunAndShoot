
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class EnemyHealth : MonoBehaviour
{
    private float health;
    public float lerpTimer;
    public float maxHealth = 100f;
    [SerializeField]
    private UnityEngine.UI.Image healthBarSprite;
    // Start is called before the first frame update
    void Start()
    {
        health = maxHealth;


    }

    // Update is called once per frame
    void Update()
    {
        UpdateHealthBArEnemy(maxHealth,health);
        //Debug.Log("Enemy Health:" + health);
        if (health <= 0)
        {
            Invoke("DestroyEnemy", 1f);
        }
    }
    public void TakeDamageEnemy(float damage)
    {
        health -= damage;
        health=Mathf.Clamp(health, 0, maxHealth);
        //UpdateHealthEnemyUI();
        
        //Debug.Log("Enemy Shoot");
    }
    public void UpdateHealthBArEnemy(float maxhealth,float currentHealth)
    {
        
        healthBarSprite.fillAmount=currentHealth/maxhealth; 
    }
    public void DestroyEnemy()
    {
        Destroy(this.gameObject);

    }
}
