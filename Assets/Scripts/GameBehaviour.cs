using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class GameBehaviour : MonoBehaviour
{
    public Transform myPrefab;

    // Start is called before the first frame update
    void Start()
    {
        int numOfCollectibles = UnityEngine.Random.Range(5, 10);
        Vector3[] usedPos = new Vector3[numOfCollectibles];
        for (var i = 0; i <numOfCollectibles; ++i)
        {
            Vector3 position = new Vector3(UnityEngine.Random.Range(-5, 5), 0, UnityEngine.Random.Range(-5, 5));
            while (Array.Exists(usedPos, pos => pos == position))
            {
                position = new Vector3(UnityEngine.Random.Range(-5, 5), 0, UnityEngine.Random.Range(-5, 5));               
            }
            usedPos[i] = position;
            var collectable = Instantiate(myPrefab, position, Quaternion.Euler(new Vector3(0, UnityEngine.Random.Range(0, 360), 90)));
            collectable.transform.parent = gameObject.transform;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
