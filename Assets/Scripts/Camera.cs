using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour
{
    public GameObject Player;
    private Vector3 offset = new Vector3(0f, 2f, -5f);
    public bool betrachter;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame    
    void LateUpdate()
    {
        if (betrachter)
        {
            Quaternion targetRotaiton = Quaternion.Slerp(transform.rotation, Player.transform.rotation, 0.05f);
            transform.position = Player.transform.position + (targetRotaiton * offset);
            transform.rotation = targetRotaiton;
        }
        else
        {
            transform.position = Player.transform.position;
            transform.rotation = Player.transform.rotation;
        }
    }
}
