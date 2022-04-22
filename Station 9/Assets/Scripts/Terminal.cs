using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Terminal : MonoBehaviour
{
    public static bool terminalIsOpen = false; //not open by default
    public bool inRange = false;

    public GameObject door;

    public GameObject terminalUI; //UI pannel that we want to open
    public GameObject interactPrompt;
    public GameObject playerUI;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && inRange == true) 
        {
            OpenTerminal();
        }
    }

    public void OpenTerminal()
    {
        interactPrompt.SetActive(false);
        playerUI.SetActive(false);
        terminalUI.SetActive(true); //sets terminal visable to player in game view
        terminalIsOpen = true;
        Cursor.lockState = CursorLockMode.None;
        PlayerMovement.canMove = false;
    }

    public void CloseTerminal()
    {
        interactPrompt.SetActive(true);
        playerUI.SetActive(true);
        terminalUI.SetActive(false); //sets terminal NOT visable to player in game view
        terminalIsOpen = false;
        Cursor.lockState = CursorLockMode.Locked;
        PlayerMovement.canMove = true;
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

    public void OpenDoor()
    {
        door.SetActive(false);
    }

    public void CloseDoor()
    {
        door.SetActive(true);
    }

}
