using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFire : MonoBehaviour
{
    PlayerMotor motor;

    public float fireRate = 0.5f;
    private float shootTimer = 0f;
    public GameObject muzzleFlashPrefab;
    public Transform gunBarrel;

    private PlayerAmmo playerAmmo;
    private GameObject muzzleFlashInstance;
    public float eyeHeight = 1.5f;
    public float eyeHeight2 = 5f;
    private Enemy enemy;
    private bool isFire;
    public AudioSource fireSound;
    [SerializeField] private float bulletSpeed=80f;
    Vector3 shootDirection;

    void Start()
    {
        motor = FindObjectOfType<PlayerMotor>();
        playerAmmo = GetComponent<PlayerAmmo>();
        enemy = FindObjectOfType<Enemy>(); // enemy deðiþkenini baþlatýn
        if (motor == null)
        {
            Debug.LogError("PlayerMotor not found in the scene!");
        }
        fireSound.Stop(); // Ýlk baþta sesi durdur
        fireSound.loop = false; // Döngüyü kapalý yap
        fireSound.playOnAwake = false; // Oynatmayý baþlatmayý kapat
        fireSound.volume = 1.0f; // Ýsteðe baðlý: Ses seviyesi
    }

    void Update()
    {
        shootTimer += Time.deltaTime;

        if (Input.GetMouseButton(0) && shootTimer >= fireRate && playerAmmo.CanShoot() && !playerAmmo.isReloading)
        {
            isFire = true;
            playerAmmo.Shoot();
            shootTimer = 0f;
            FireGun();
            
            //ateþ edildigini haber ver
        }
        else
        {
            isFire = false;
        }
    }
    void FireGun()
    {
        fireSound.Play();

    }

    public void Shoot()
    {
        if (!playerAmmo.CanShoot() || playerAmmo.isReloading)
        {
            // Player cannot shoot during reloading
            return;
        }

        Ray ray = Camera.main.ScreenPointToRay(new Vector3(Screen.width / 2, Screen.height / 2, 0));
        RaycastHit hitInfo;

        if (Physics.Raycast(ray, out hitInfo))
        {
            GameObject bullet = GameObject.Instantiate(Resources.Load("Prefabs/PlayerBullet") as GameObject, gunBarrel.position, Quaternion.LookRotation(hitInfo.point - gunBarrel.position));

            Vector3 shootDirection = (hitInfo.point - gunBarrel.transform.position).normalized;
            bullet.GetComponent<Rigidbody>().velocity = shootDirection * bulletSpeed;

            if (muzzleFlashPrefab != null)
            {
                if (muzzleFlashInstance != null)
                {
                    Destroy(muzzleFlashInstance);
                }

                // Muzzle flash efektini gunBarrel'in ucuna yerleþtir
                muzzleFlashInstance = GameObject.Instantiate(muzzleFlashPrefab, gunBarrel.position, gunBarrel.rotation, gunBarrel);
                Destroy(muzzleFlashInstance, 0.1f);
            }

            Debug.DrawRay(ray.origin, ray.direction * hitInfo.distance, Color.red, 1.0f);
            Debug.Log("Shoot!");
        }
        else
        {
             shootDirection = ray.direction;

            Vector3 adjustedGunBarrelPosition = gunBarrel.position + Vector3.up * eyeHeight2;

            Ray adjustedRay= new Ray(adjustedGunBarrelPosition,ray.direction);

            RaycastHit adjustedHitInfo=new RaycastHit();
            
            GameObject bullet = GameObject.Instantiate(Resources.Load("Prefabs/PlayerBullet") as GameObject, gunBarrel.position, Quaternion.LookRotation(shootDirection));

            bullet.GetComponent<Rigidbody>().velocity = shootDirection.normalized * bulletSpeed;
            
            if (Physics.Raycast(adjustedRay, out adjustedHitInfo, 100))
            {
                shootDirection=(adjustedHitInfo.point-adjustedGunBarrelPosition).normalized;
            }

            if (muzzleFlashPrefab != null)
            {
                if (muzzleFlashInstance != null)
                {
                    Destroy(muzzleFlashInstance);
                }

                // Muzzle flash efektini gunBarrel'in ucuna yerleþtir
                muzzleFlashInstance = GameObject.Instantiate(muzzleFlashPrefab, gunBarrel.position, gunBarrel.rotation, gunBarrel);
                Destroy(muzzleFlashInstance, 0.1f);
            }

            Debug.DrawRay(ray.origin, ray.direction * 100f, Color.blue, 1.0f);
            Debug.Log("Shoot!");
        }
    }
}
