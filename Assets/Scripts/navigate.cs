using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class navigate : MonoBehaviour
{

    public GameObject player;
    public GameObject cam;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("OVRCameraRig Variant");
        cam = GameObject.Find("CenterEyeAnchor");

    }

    // Update is called once per frame
    void Update()
    {

        // Movement 
        Vector3 direction;
        Vector2 joystickInput = OVRInput.Get(OVRInput.Axis2D.SecondaryThumbstick);

        Vector3 camForward = cam.transform.forward;
        camForward.y = 0;
        camForward.Normalize();

        Vector3 camRight = cam.transform.right;
        camRight.y = 0;
        camRight.Normalize();



        direction = (camForward * joystickInput.y + camRight * joystickInput.x) * 0.1f;
        player.transform.position += direction;


        //heigth manager
        if (OVRInput.GetDown(OVRInput.Button.One))
        {
            player.transform.position += 0.01f*Vector3.up;
        }
        if (OVRInput.GetDown(OVRInput.Button.Two))
        {
            player.transform.position -= 0.01f * Vector3.up;
        }
   
    }
}
