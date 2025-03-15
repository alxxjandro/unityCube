using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveObject : MonoBehaviour
{
    float x, y, z;
    public Vector3 speed;
    void Update()
    {
        transform.position = new Vector3(x, y, z);
        x += speed.x * Time.deltaTime;
        y += speed.y * Time.deltaTime;
        z += speed.z * Time.deltaTime;
        // en una computadora potente seria 0.008, y en una menos potente 0.050

    }
}