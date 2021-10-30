using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class boxSpawner : MonoBehaviour {

    public GameObject box1;

    public GameObject box2;

    public GameObject boxCreater;

    float pos;

    public void Spawner()
    {
        pos = box1.transform.position.y;

        Instantiate(box1, new Vector3(box1.transform.position.x, pos+5f, 0f), Quaternion.identity);
        Instantiate(box2, new Vector3(box2.transform.position.x, pos +5f, 0f), Quaternion.identity);
        Instantiate(boxCreater, new Vector3(box2.transform.position.x, pos + 5f, 0f), Quaternion.identity);
    }


}
