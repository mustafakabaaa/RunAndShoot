using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class Enemy : MonoBehaviour
{
    private Vector3 lastKnowPos;
    private StateMachine stateMachine;
    private NavMeshAgent agent;
    private GameObject player;

    public Vector3 LastKnowPos { get => lastKnowPos;set=> lastKnowPos= value; }
    public NavMeshAgent Agent { get => agent;}
    public GameObject Player { get=>player; }
    public GameObject debugSphere;
    


    public Path path;
    [Header("sight Values")]
    public float sightDistance=20f;
    public float fieldOfView=80f;
    public float eyeHeight;

    [Header("Weapon Values")]
    public Transform gunBarrel;
    [Range(0.1f, 10)]
    public float fireRate;
    //Debug purposes.
    [SerializeField]
    private string currentState;
    // Start is called before the first frame update
    void Start()
    {
        stateMachine=GetComponent<StateMachine>();
        agent=GetComponent<NavMeshAgent>();
        stateMachine.Initialise();
        player = GameObject.FindGameObjectWithTag("Player");
    }
    private void Update()
    {
        CanSeePlayer();
        currentState=stateMachine.activeState.ToString();
        debugSphere.transform.position = lastKnowPos;
    }
    public bool CanSeePlayer()
    {
        if (player != null)
        {
            if (Vector3.Distance(transform.position, player.transform.position) < sightDistance)
            {
                Vector3 targetDirection = player.transform.position - transform.position - (Vector3.up * eyeHeight);
                float angleToPlayer = Vector3.Angle(targetDirection, transform.forward);

                if (angleToPlayer >= -fieldOfView && angleToPlayer <= fieldOfView)
                {
                    Vector3 rayStartPoint = transform.position + (Vector3.up * eyeHeight);
                    Ray ray = new Ray(rayStartPoint, targetDirection);

                    RaycastHit hitInfo = new RaycastHit();
                    if (Physics.Raycast(ray, out hitInfo, sightDistance))
                    {
                        if (hitInfo.transform.gameObject == player)
                        {
                            Debug.DrawRay(ray.origin, ray.direction * sightDistance);
                            return true;
                        }
                    }
                }
            }
        }
        return false;
    }


}
