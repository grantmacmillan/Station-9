using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CrewMember : MonoBehaviour
{
    public bool inRange = false;
    public GameObject interactPrompt;

    public int crewMembersSaved = 0;
    public TextMeshProUGUI savedCounterText;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
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

    public void Rescue()
    {
        PlayerMovement.crewMembersRescued++;
        savedCounterText.text = "Crew Saved: " + PlayerMovement.crewMembersRescued;
        Destroy(gameObject);
        interactPrompt.SetActive(false);
    }
}
