using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DroneCamLocation : MonoBehaviour
{
    public Transform Cam;
    public Transform CamPOI;
    public Transform DroneObj;
    public Transform orientation;

    float HorizontalInput;
    float VerticalInput;

    float TiltX;
    float TiltZ;

    public float angle;

    public float Radius;
    public float UpShift;
    public float ViewCorrection;

    public float sensX;
    public float sensY;

    float xRotation;
    float yRotation;



    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 viewDir = transform.position - new Vector3(transform.position.x, transform.position.y, transform.position.z);
        transform.forward = viewDir.normalized;

        transform.position = CamPOI.position;
        

        Vector3 Droneposition = new Vector3 (transform.position.x, transform.position.y + UpShift, transform.position.z - Radius);
        Cam.position = Droneposition;

        float mouseY = Input.GetAxisRaw("Mouse Y") * Time.deltaTime * sensY;
        float mouseX = Input.GetAxisRaw("Mouse X") * Time.deltaTime * sensX;

        HorizontalInput = Input.GetAxisRaw("Horizontal");
        VerticalInput = Input.GetAxisRaw("Vertical");


        yRotation += mouseX;
        xRotation += mouseY;

        xRotation = Mathf.Clamp(xRotation, -90f - ViewCorrection, 90f - ViewCorrection);
            
        // Rotate CamY
        transform.rotation = Quaternion.Euler(xRotation + ViewCorrection,yRotation, 0);
        DroneObj.rotation = Quaternion.Euler(TiltX, yRotation, TiltZ);
        orientation.rotation = Quaternion.Euler(xRotation, yRotation, 0);

        TiltX = VerticalInput * angle;
       TiltZ = HorizontalInput * angle * -1f;
    }
}
