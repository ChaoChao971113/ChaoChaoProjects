using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Cube : MonoBehaviour
{
    [HideInInspector]
    public GameObject turretGo;
    public GameObject buildEffect;

    private Renderer render;

     void Start()
    {
        render = GetComponent<Renderer>();

    }

    public void BuildTurret(GameObject turretPrefab)
    {
        Debug.Log("Building");

        turretGo = GameObject.Instantiate(turretPrefab,transform.position,Quaternion.identity);
       // GameObject effect = GameObject.Instantiate(buildEffect,transform.position, Quaternion.identity);
        //Destroy(effect, 4);
    }

    private void OnMouseEnter()
    {
        render.material.color = Color.red;
    }

    private void OnMouseExit()
    {
        render.material.color = Color.white;
    }
}

