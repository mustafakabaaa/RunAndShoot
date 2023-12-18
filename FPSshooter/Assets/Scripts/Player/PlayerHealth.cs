using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    public float health;
    public float lerpTimer;
    public float maxHealth = 100f;
    public float chipSpeed = 2f;
    public AudioSource medicSound;
    public Image healthBar;
    private bool canHeal=true;

    public DamageIndicator damageIndicator;
    void Start()
    {
        health = maxHealth;
        UpdateHealthUI(); // Baþlangýçta health barýný güncelle
    }

    void Update()
    {
        health = Mathf.Clamp(health, 0, maxHealth);
        UpdateHealthUI();

        if (health <= 0)
        {
            PlayerDead();
        }
        //Debug.Log(health);
        if (transform.position.y<=-50) 
        {
            health -= 50;
        
        }
       
    }
    void PlayerDead()
    {
        // Oyuncu öldüðünde yapýlacak iþlemler burada olacak
        Debug.Log("Oyuncu öldü!");
    }
    public void UpdateHealthUI()
    {
        float hFraction = health / maxHealth;
        float doluH = healthBar.fillAmount;

        if (doluH > hFraction)
        {
            lerpTimer += Time.deltaTime;
            float yüzdeTamam = Mathf.Pow(lerpTimer / chipSpeed, 2);
            yüzdeTamam = yüzdeTamam * yüzdeTamam;
            healthBar.fillAmount = Mathf.Lerp(doluH, hFraction, yüzdeTamam);
        }
        else
        {
            lerpTimer = 0f; // Eðer health artýyorsa, lerpTimer'ý sýfýrla
            healthBar.fillAmount = hFraction; // Health artýyorsa, direkt olarak hFraction'a ayarla
        }
    }
    public void Medic(float medica)
    {
        if (canHeal)
        {
            float maxHealtPlus = 45;
            if (medica > maxHealtPlus)
            {
                medica = maxHealtPlus;
            }
            float healTime = 3f;
            StartCoroutine(MedicCoroutine(medica, healTime));
            medicSound.Play();
            canHeal = false;
        }
        else
        {

        }
       
    }


    public void HasarAl(float hasar)
    {
        health -= hasar;
        health = Mathf.Clamp(health, 0, maxHealth); // Saðlýðý 0 ile maxHealth arasýnda tut
        UpdateHealthUI(); // Health güncellendikten sonra health barýný güncelle
        lerpTimer = 0f;

        // Hasar alýnfýðýnda DamageIndýcator calistir.
        if(damageIndicator!=null)
        {
            damageIndicator.ShowDamageIndicator();
        }
    }



    private IEnumerator MedicCoroutine(float medica, float totalHealTime)
    {
        float startingHealth = health;
        float targetHealth = Mathf.Clamp(health + medica, 0, maxHealth);

        float elapsedTime = 0f;

        while (elapsedTime < totalHealTime)
        {
            health = Mathf.Lerp(startingHealth, targetHealth, elapsedTime / totalHealTime);
            UpdateHealthUI();
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        health = targetHealth;
        UpdateHealthUI();
        canHeal = true;
    }


}
