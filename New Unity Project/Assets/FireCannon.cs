using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireCannon : MonoBehaviour
{
    public List<GameObject> enemys = new List<GameObject>();


    private float mouse_speed = 100f;
    private bool player_mode;
    public GameObject main_cam;
    private float next_fire_time = 0f;
    public GameObject shoot_effect;
    private GameObject turret_cam;



    void OnTriggerEnter(Collider col)
    {
        if (col.tag == "Enemy")
        {
            enemys.Add(col.gameObject);
        }
    }
    void OnTriggerExit(Collider col)
    {
        if (col.tag == "Enemy")
        {
            enemys.Remove(col.gameObject);
        }
    }
    public float attackRateTime = 1;
    private float timer = 0;
    public ParticleSystem Fire_one;
    public ParticleSystem Fire_two;
    public Transform head;
    
    void Start()
    {
        timer = attackRateTime;

        player_mode = false;
        turret_cam = transform.GetChild(0).gameObject;
        main_cam = GameObject.FindGameObjectWithTag("MainCamera");
    }
    void Update()
    {

        if (turret_cam.activeSelf == true)
        {
            player_mode = true;
        }
        else
        {
            player_mode = false;
        }
        timer += Time.deltaTime;
        if (player_mode == false)
        {
            if (enemys.Count > 0 && timer >= attackRateTime)
            {
                timer = 0;
                Attack();
            }
            if (enemys.Count > 0 && enemys[0] != null)
            {
                Vector3 direction = enemys[0].transform.position - transform.position;
                Quaternion LookRotation = Quaternion.LookRotation(direction);
                Vector3 rotation = LookRotation.eulerAngles;
                head.rotation = Quaternion.Euler(0f, rotation.y, 0f);
                turret_cam.transform.rotation = Quaternion.Euler(0f, rotation.y, 0f);
            }
        }
        else
        {
            if (Input.GetKey("q"))
            {
                turret_cam.SetActive(false);
                main_cam.SetActive(true);
                return;
            }
            float mouse_x = Input.GetAxis("Mouse X") * mouse_speed * Time.deltaTime;
            float mouse_y = Input.GetAxis("Mouse Y") * mouse_speed * Time.deltaTime;

            // xRotation -= mouse_y;
            //xRotation = Mathf.Clamp(xRotation, -90f, 90f);

            //transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
            head.transform.Rotate(Vector3.up * mouse_x);
            turret_cam.transform.Rotate(Vector3.up * mouse_x);

            if (Input.GetButton("Fire1") && Time.time >= next_fire_time)
            {
                next_fire_time = Time.time + 1f / 20f;
                Shoot();
            }
        }
       
    }
    void Attack()
    {
        if (enemys[0] == null)
        {
            Renewenemys();
        }
        if (enemys.Count > 0)
        {
            Fire_one.Emit(10);
            Fire_two.Emit(10);
        }
        else
        {
            timer = attackRateTime;
        }

    }

    void Shoot()
    {
        Fire_one.Emit(1);
        Fire_two.Emit(1);
    }
    void Renewenemys()
    {
        List<GameObject> news = new List<GameObject>();

        for (int i = 0; i < enemys.Count; i++)
        {
            if (enemys[i] != null)
            {
                news.Add(enemys[i]);
            }
        }
        enemys = news;
    }
}
