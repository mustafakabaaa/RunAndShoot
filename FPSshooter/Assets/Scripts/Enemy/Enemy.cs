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

    // Getter and setter for the last known player position
    public Vector3 LastKnowPos { get => lastKnowPos; set => lastKnowPos = value; }

    // Getter for the NavMeshAgent
    public NavMeshAgent Agent { get => agent; }

    // Getter for the player GameObject
    public GameObject Player { get => player; }

    public GameObject debugSphere;

    public Path path;

    [Header("Sight Values")]
    // Sight distance for detecting the player
    public float sightDistance = 20f;

    // Field of view angle for detecting the player
    public float fieldOfView = 80f;

    // Height of the eyes for calculating the sight ray origin
    public float eyeHeight;

    [Header("Weapon Values")]
    // Transform representing the gun barrel
    public Transform gunBarrel;

    // Fire rate for the enemy's weapon
    [Range(0.1f, 10)]
    public float fireRate;

    // For debug purposes, displays the current state of the state machine
    [SerializeField]
    private string currentState;

    // Start is called before the first frame update
    void Start()
    {
        // Initialize the state machine
        stateMachine = GetComponent<StateMachine>();

        // Get the NavMeshAgent component
        agent = GetComponent<NavMeshAgent>();

        // Initialize the state machine
        stateMachine.Initialise();

        // Find the player GameObject by tag
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    private void Update()
    {
        // Check if the enemy can see the player
        CanSeePlayer();

        // Update the currentState string for debug purposes
        currentState = stateMachine.activeState.ToString();

        // Update the position of the debug sphere to the last known player position
        debugSphere.transform.position = lastKnowPos;
    }

    // Checks if the enemy can see the player
    public bool CanSeePlayer()
    {
        if (player != null)
        {
            // Check if the player is within the sight distance
            if (Vector3.Distance(transform.position, player.transform.position) < sightDistance)
            {
                // Calculate the direction to the player and the angle to the player
                Vector3 targetDirection = player.transform.position - transform.position - (Vector3.up * eyeHeight);
                float angleToPlayer = Vector3.Angle(targetDirection, transform.forward);

                // Check if the player is within the field of view
                if (angleToPlayer >= -fieldOfView && angleToPlayer <= fieldOfView)
                {
                    // Create a ray from the enemy's eyes towards the player
                    Vector3 rayStartPoint = transform.position + (Vector3.up * eyeHeight);
                    Ray ray = new Ray(rayStartPoint, targetDirection);

                    // Cast the ray to detect obstacles between the enemy and the player
                    RaycastHit hitInfo = new RaycastHit();
                    if (Physics.Raycast(ray, out hitInfo, sightDistance))
                    {
                        // If the ray hits the player, return true
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

    // Called when a sound is detected (for future functionality)
    public void OnSoundDetected()
    {
        Debug.Log("OnSoundDetected function is called.");
        // Add other actions here
        stateMachine.ChangeState(new AttackState());
    }
}
