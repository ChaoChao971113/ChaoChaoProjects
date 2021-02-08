using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSwitch : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject TurretCam;
    public GameObject Manager_cam;
    

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey("e"))
        {
            Manager_cam.SetActive(false);
            TurretCam.SetActive(true);
        }
    }
}
