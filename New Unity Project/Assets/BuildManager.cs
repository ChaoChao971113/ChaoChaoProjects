using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
public class BuildManager : MonoBehaviour
{
    public TurretData standardTurretData;
    public TurretData FireCannonData;

    public TurretData selectedTurretData;
    public Text moneyText;
    public GameObject MainCam;

   

    private int money = 1000;
    public Animator moneyAnimator;

    void UpdateMoney(int change=0)
    {
        money += change;
        moneyText.text = "$" + money;
    }
    void Update()
    {
       


        if (Input.GetMouseButtonDown(0))
        {
            if (EventSystem.current.IsPointerOverGameObject()==false)
            {
                Ray ray = MainCam.GetComponent<Camera>().ScreenPointToRay(Input.mousePosition);
                RaycastHit hit;
                bool isCollider = Physics.Raycast(ray, out hit, 1000, LayerMask.GetMask("MapCube"));
                if (isCollider)
                {
                   
                    Cube mapCube = hit.collider.GetComponent<Cube>();
                    if (selectedTurretData != null && mapCube.turretGo==null && MainCam.activeSelf == true)
                    {
                        Debug.Log("Try to build");
                        if (money>=selectedTurretData.cost)
                        {
                            UpdateMoney(-selectedTurretData.cost);
                            mapCube.BuildTurret(selectedTurretData.turretPrefab);
                        }
                        else
                        {
                            moneyAnimator.SetTrigger("money");
                        }
                    }
                    else if (mapCube.turretGo!=null)
                    {
                  
                        MainCam.SetActive(false);
                        GameObject new_view = mapCube.turretGo.transform.GetChild(0).gameObject;
                        new_view.SetActive(true);
                       

                        
                    }
                }
            }
        }
    }
    public void StandardSelected(bool isOn)
    {
        if (isOn)
        {
            selectedTurretData = standardTurretData;
        }
    }

    public void FireCannonSelected(bool isOn)
    {
        if (isOn)
        {
            selectedTurretData = FireCannonData;
        }
    }

   
}
