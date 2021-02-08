using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ViewController : MonoBehaviour
{
    public float speed = 1;
    public float mousespeed = 60;
    void Update()
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");
        float m = Input.GetAxis("Mouse ScrollWheel");
        transform.Translate(new Vector3(h * speed, mousespeed * m, v * speed) * Time.deltaTime, Space.World);

    }
}
