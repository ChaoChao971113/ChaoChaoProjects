using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Exploding : MonoBehaviour
{
    public float cubesize = 0.2f;
    public int cubesInRow = 5;
    float cubePivotDistance;
    Vector3 cubesPivot;
    public static Exploding Instance;

    public float explosion_Force = 50f;
    public float explosion_Radius = 4f;
    public float explosion_Upward = 0.4f;
    // Start is called before the first frame update
    void Start()
    {
        cubePivotDistance = cubesize * cubesInRow / 2;
        cubesPivot = new Vector3(cubePivotDistance, cubePivotDistance, cubePivotDistance);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    
    public void Explode()
    {
        gameObject.SetActive(false);
     
        for (int i = 0; i < cubesInRow; i++)
        {
            for (int j = 0; j < cubesInRow; j++)
            {
                for (int m = 0; m < cubesInRow; m++)
                {
                    create_peices(i, j, m);
                }
            }
        }

        Vector3 explosion_Position = transform.position;
        Collider[] colliders = Physics.OverlapSphere(explosion_Position, explosion_Radius);
        foreach (Collider hit in colliders)
        {
            //get rigidbody from collider object
            Rigidbody rb = hit.GetComponent<Rigidbody>();
            if (rb != null)
            {
                //add explosion force to this body with given parameters
                rb.AddExplosionForce(explosion_Force, transform.position, explosion_Radius, explosion_Upward);
            }
        }
    }

    private void create_peices(int i, int j, int m)
    {
        GameObject piece;
        piece = GameObject.CreatePrimitive(PrimitiveType.Cube);
        piece.transform.position = transform.position + new Vector3(cubesize*i,cubesize*j,cubesize*m)-cubesPivot;
        piece.transform.localScale = new Vector3(cubesize, cubesize, cubesize);

        piece.AddComponent<Rigidbody>();
        piece.GetComponent<Rigidbody>().mass = 0.2f;

        Destroy(piece, UnityEngine.Random.Range(0.5f, 5f));


    }
}
