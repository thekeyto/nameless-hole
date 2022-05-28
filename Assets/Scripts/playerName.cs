using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerName : MonoBehaviour
{
    // Start is called before the first frame update

    public GameObject nowNameObject;

    public static playerName instance;
    void Start()
    {
        if (instance != null) Destroy(instance);
        instance = this;
    }

    public void setNameObject()
    {
        Ray myRay = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        Physics.Raycast(myRay, out hit);
        if (hit.collider.tag == "nameObject") instance.nowNameObject = hit.collider.gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
