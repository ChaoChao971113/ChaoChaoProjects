using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : MonoBehaviour
{
    public List<GameObject> enemys = new List<GameObject>();
    //public GameObject main_cam;
    private GameObject turret_cam;
    private float mouse_speed = 100f;
    private bool player_mode;
    public GameObject main_cam;
    private float next_fire_time = 0f;
    public GameObject shoot_effect;
    

   

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
    public GameObject bulletPrefab;
    public Transform bulletPosition;
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
        timer += Time.deltaTime;
        if (turret_cam.activeSelf == true)
        {
            player_mode = true;
        }
        else
        {
            player_mode = false;
        }
        if (player_mode == false)
        {
            if (enemys.Count > 0 && timer >= attackRateTime)
            {
                timer = 0;
                Attack();
            }
            if (enemys.Count > 0 && enemys[0] != null)
            {
                Vector3 targetPosition = enemys[0].transform.position;
                targetPosition.y = head.position.y;
                head.LookAt(targetPosition);
                turret_cam.transform.LookAt(targetPosition);
               
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
        if (enemys[0]==null)
        {
            Renewenemys();
        }
        if (enemys.Count>0)
        {
            GameObject bullet = GameObject.Instantiate(bulletPrefab, bulletPosition.position, bulletPosition.rotation);
            bullet.GetComponent<Bullet>().Settarget(enemys[0].transform);
        }
        else
        {
            timer = attackRateTime;
        }
        
    }
    //Attack Mode for player mode
    void Shoot()
    {
        GameObject effect = GameObject.Instantiate(shoot_effect, bulletPosition.position, Quaternion.identity);
        Destroy(effect, 1);
        RaycastHit target;
        if (Physics.Raycast(bulletPosition.position, bulletPosition.forward, out target, 20))
        {
            if (target.transform.tag == "Enemy")
            {
                target.transform.gameObject.GetComponent<Enemy1>().Damage(50);
            }
        }

       
        
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
