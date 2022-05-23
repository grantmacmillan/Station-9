using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Map : MonoBehaviour
{

    public GameObject terminalUI;
    public GameObject mapUI;

    public GameObject securityNorthDoor;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OpenMap()
    {
        terminalUI.SetActive(false);
        mapUI.SetActive(true);
    }
    public void OpenDoor()
    {
        securityNorthDoor.SetActive(false);
    }
    public void CloseMap()
    {
        mapUI.SetActive(false);
        terminalUI.SetActive(true);
    }
}
