using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.TextCore.Text;

public class AttackState : BaseState
{
    private float moveTimer;
    private float losePlayerTimer;
    private float shootTimer;
    public GameObject EnemyMuzlleEfect;
    public override void Enter()
    {
        
    }

    public override void Exit()
    {
        
    }

    public override void Perform()
    {
        if (enemy.CanSeePlayer())
        {
            losePlayerTimer = 0;
            moveTimer += Time.deltaTime;
            shootTimer += Time.deltaTime;
            enemy.transform.LookAt(enemy.Player.transform);
            if (shootTimer > enemy.fireRate)
            {
                Shoot();
            }
            if (moveTimer > Random.Range(3, 7))
            {
                enemy.Agent.SetDestination(enemy.transform.position + (Random.insideUnitSphere * 5));
                moveTimer = 0;
            }
            enemy.LastKnowPos=enemy.Player.transform.position;
        }
        else
        {
            losePlayerTimer -= Time.deltaTime;
            if (losePlayerTimer <= 8)
            {
                stateMachine.ChangeState(new SearchState());
            }
        }

    }
    public void Shoot()
    {
        Transform gunBarrel = enemy.gunBarrel;

        GameObject bullet=GameObject.Instantiate(Resources.Load("Prefabs/Bullet") as GameObject, gunBarrel.position,enemy.transform.rotation  );
        // Muzzle flash prefabini instantiate et
        if (EnemyMuzlleEfect!= null)
        {
            GameObject muzzleFlash = GameObject.Instantiate(EnemyMuzlleEfect, gunBarrel.position, gunBarrel.rotation, gunBarrel);
            UnityEngine.Object.Destroy(muzzleFlash, 0.1f); // Muzzle flash'i belirli bir süre sonra yok et
        }
        Vector3 shootDirection=(enemy.Player.transform.position- gunBarrel.transform.position).normalized;
        bullet.GetComponent<Rigidbody>().velocity = Quaternion.AngleAxis(Random.Range(-3f,3f),Vector3.up)*  shootDirection *40;
        shootTimer = 0;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
