using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;

public class ButtonEventHandler : MonoBehaviour, IVirtualButtonEventHandler
{
    public Transform Player;
    int walk = 0;
    int rotate = 0;
    float walkingSpeed = 0.2f;
    float rotationSpeed = 2;
    // Start is called before the first frame update
    void Start()
    {
        VirtualButtonBehaviour[] vbs = GetComponentsInChildren<VirtualButtonBehaviour>();
        for (int i = 0; i < vbs.Length; ++i)
        {
            vbs[i].RegisterEventHandler(this);
            Debug.Log(vbs[i].VirtualButtonName);
        }
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (walk != 0)
            Player.position += Player.forward*walk*walkingSpeed;
        if(rotate!=0)
            Player.Rotate(Vector3.up * (rotate*rotationSpeed));

    }
    public void OnButtonPressed(VirtualButtonBehaviour vb)

    {
        Debug.Log(vb.VirtualButtonName);
        switch (vb.VirtualButtonName)
        {
            case "forwards":
                walk = 1;
                break;
            case "backwards":
                walk = -1;
                break;
            case "left":
                rotate = -1;
                break;
            case "right":
                rotate = 1;
                break;

        }

    }
    public void OnButtonReleased(VirtualButtonBehaviour vb)
    {
        if (vb.VirtualButtonName == "forwards" || vb.VirtualButtonName == "backwards")
        {
            walk = 0;
        }
        else
            rotate = 0;
      
    }
}
