using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.AI;

public class CrewMember : MonoBehaviour
{
    public NavMeshAgent agent;
    public Transform rescuePoint;

    public LayerMask whatIsGround;

    //wandering
    public Vector3 walkPoint;
    bool walkPointSet;
    public float walkPointRange;

    //rescue
    public bool beingRescued = false;

    public bool inRange = false;
    public GameObject interactPrompt;

    public int crewMembersSaved = 0;
    public TextMeshProUGUI savedCounterText;
    private void Awake()
    {
        rescuePoint = GameObject.Find("RescuePoint").transform; //find the player in the scene
        agent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!beingRescued)
        {
            Wandering();
        }

        if (Input.GetKeyDown(KeyCode.E) && inRange == true)
        {
            Rescue();
        }

        
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            inRange = true;
            interactPrompt.SetActive(true);
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            inRange = false;
            interactPrompt.SetActive(false);
        }
    }

    

    private void Wandering()
    {
        if (!walkPointSet)
        {
            SearchWalkPoint();
        }

        if (walkPointSet)
        {
            agent.SetDestination(walkPoint);
        }

        Vector3 distanceToWalkPoint = transform.position - walkPoint;

        //walkpoint reached
        if (distanceToWalkPoint.magnitude < 1.0f)
        {
            walkPointSet = false;
        }
    }
    private void SearchWalkPoint()
    {
        //make a random point that is in the range
        float randomZ = Random.Range(-walkPointRange, walkPointRange);
        float randomX = Random.Range(-walkPointRange, walkPointRange);

        walkPoint = new Vector3(transform.position.x + randomX, transform.position.y, transform.position.z + randomZ);

        if (Physics.Raycast(walkPoint, -transform.up, 2.0f, whatIsGround))
        {
            walkPointSet = true;
        }
    }

    public void Rescue()
    {
        beingRescued = true;
        PlayerMovement.crewMembersRescued++;
        savedCounterText.text = "Crew Saved: " + PlayerMovement.crewMembersRescued;
        agent.SetDestination(rescuePoint.position);
        interactPrompt.SetActive(false);
    }
}
