using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static bool playerInAirlock = false;
    public static bool playerExitedAirlock = false;
    public static bool playerIsOutside = false; 

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //for airlock system
        if (playerExitedAirlock && playerIsOutside)
        {
            ZeroGravity();
        }
        if (playerExitedAirlock && !playerIsOutside)
        {
            NormalGravity();
        }
    }

    public void ZeroGravity()
    {
        PlayerMovement.gravity = -5f;
    }

    public void NormalGravity()
    {
        PlayerMovement.gravity = -45f;
    }
}
