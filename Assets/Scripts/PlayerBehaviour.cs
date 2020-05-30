using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehaviour : MonoBehaviour
{
    private int score = 0;
    private float walkingSpeed = 0.2f;
    private float rotateSpeed = 2;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetAxis("Horizontal") != 0)
            transform.Rotate(Vector3.up * rotateSpeed * Input.GetAxis("Horizontal"));
        if (Input.GetAxis("Vertical") != 0)
            transform.position += transform.forward * walkingSpeed*Input.GetAxis("Vertical");
    }

    private void OnTriggerEnter(UnityEngine.Collider other)
    {
        if (other.gameObject.tag == "Collectable")
        {
            other.gameObject.SetActive(false);
            Destroy(other.gameObject);
            score++;
            print("Score: " + score);
        }
    }
}
