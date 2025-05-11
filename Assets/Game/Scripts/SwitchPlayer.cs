using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchPlayer : MonoBehaviour
{

    public GameObject Camera_1;
    public GameObject Camera_2;

    public GameObject Drone;
    public GameObject Player;

    public GameObject DroneCamScript;
    public GameObject PlayerCamScript;


    public int Manager = 0;



    // Start is called before the first frame update
    void Start()
    {
        Drone.GetComponent<DroneMovement>().enabled = false;
        Player.GetComponent<PlayerMovement>().enabled = true;
        DroneCamScript.GetComponent<DroneCam>().enabled = false;
        PlayerCamScript.GetComponent<PlayerCam>().enabled = true;

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            SwitchCamera();
        }
    }

    public void SwitchCamera()
    {
        if (Manager == 0)
        {
            DroneS();
            Manager = 1;
        }
        else
        {
            PlayerS();
            Manager = 0;
        }
    }

    void DroneS()
    {
        Camera_1.SetActive(true);
        Camera_2.SetActive(false);
        Drone.GetComponent<DroneMovement>().enabled = true;
        Player.GetComponent<PlayerMovement>().enabled = false;
        DroneCamScript.GetComponent<DroneCam>().enabled = true;
        PlayerCamScript.GetComponent<PlayerCam>().enabled = false;
    }

    void PlayerS()
    {
        Camera_1.SetActive(false);
        Camera_2.SetActive(true);
        Player.GetComponent<PlayerMovement>().enabled = true;
        Drone.GetComponent<DroneMovement>().enabled = false;
        DroneCamScript.GetComponent<DroneCam>().enabled = false;
        PlayerCamScript.GetComponent<PlayerCam>().enabled = true;
    }





}
