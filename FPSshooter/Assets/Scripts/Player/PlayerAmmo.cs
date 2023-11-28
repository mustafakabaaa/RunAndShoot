using System.Collections;
using TMPro;
using UnityEngine;

public class PlayerAmmo : MonoBehaviour
{
    public int magazineCapacity = 30;
    private int currentAmmo;

    public float reloadTime = 4f;
    public bool isReloading = false;
    public TextMeshProUGUI ammoText;
    public TextMeshProUGUI reloadText;
   
    public AudioSource reloadedSound;

    private void Start()
    {
        currentAmmo = magazineCapacity;

        UpdateAmmoUI();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.R) && !isReloading && currentAmmo < magazineCapacity)
        {
            StartCoroutine(Reload());
        }
    }

    public bool CanShoot()
    {
        return currentAmmo > 0;
    }

    public void Shoot()
    {
        if (CanShoot())
        {
            // Reduce ammo count
            currentAmmo--;
            UpdateAmmoUI();
            // Call the Shoot function from PlayerFire
            GetComponent<PlayerFire>().Shoot();
        }
        else
        {
            // Handle out of ammo case if needed
        }
    }

    IEnumerator Reload()
    {
        isReloading = true;
        // Optional: Play reload animation or sound
        if(reloadText != null)
        {
            reloadText.text = "Reloading...";
            reloadedSound.Play();
        }
        yield return new WaitForSeconds(reloadTime);
        currentAmmo = magazineCapacity;
        UpdateAmmoUI();
        isReloading = false;

        if (reloadText != null)
        {
           
            reloadText.text = "";
        }
    }

    void UpdateAmmoUI()
    {
        if (ammoText != null)
        {
            ammoText.text = currentAmmo.ToString();
        }
    }
}
