using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamSwitch : MonoBehaviour
{

    public GameObject Camera_1;
    public GameObject Camera_2;
    public int Manager;
    // Start is called before the first frame update
    void Start()
    {
        
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
            Cam_2();
            Manager = 1;
        }
        else
        {
            Cam_1();
            Manager = 0;
        }
    }

    void Cam_1()
    {
        Camera_1.SetActive(true);
        Camera_2.SetActive(false);


    }

    void Cam_2()
    {
        Camera_1.SetActive(false);
        Camera_2.SetActive(true);

    }

}
