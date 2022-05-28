using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InvLayerManageer : MonoBehaviour
{
    world nowWorld; 
    
    
    GameObject[] insideGameobject;
    GameObject[] tempInsideGameobject;

    GameObject[] outsideGameobject;

    Transform[] insideTransform;
    Transform[] outsideTransform;

    Vector3[] insidePos;
    Vector3[] outsidePos;

    enum world { outside,inside };
    public static InvLayerManageer instance;


    // Start is called before the first frame update
    void Start()
    {
        nowWorld = world.outside;
        outsideGameobject = GameObject.FindGameObjectsWithTag("outside");
        insidePos = new Vector3[outsideGameobject.Length];
        for (int i = 0; i < outsideGameobject.Length; i++)
        {
            outsidePos[outsideGameobject[i].GetComponent<nameObject>().id] = outsideGameobject[i].transform.position;
        }

    }

    void intoOutside()
    {
        nowWorld = world.outside;
        outsideGameobject = GameObject.FindGameObjectsWithTag("outside");
        for(int i = 0; i < outsideGameobject.Length; i++)
        {
            outsideTransform[outsideGameobject[i].GetComponent<nameObject>().id] = outsideGameobject[i].transform;
        }
        for (int i = 0; i < outsideTransform.Length; i++)
            outsideTransform[i].position = insidePos[i];
    }
    
    void changeGameobject()
    {
        for(int i = 0; i < insideGameobject.Length; i++)
        {
            GameObject temp = insideGameobject[i];
            GameObject nowObject = Instantiate(playerName.instance.nowNameObject) as GameObject;
            nowObject.transform.position = temp.transform.position;
            nowObject.AddComponent<nameObject>();
            nowObject.GetComponent<nameObject>().id = temp.GetComponent<nameObject>().id;
            Destroy(insideGameobject[i]);
        }
    }
    void intoInside()
    {
        nowWorld = world.inside;
        tempInsideGameobject = GameObject.FindGameObjectsWithTag("inside");
        for (int i = 0; i < tempInsideGameobject.Length; i++)
            insideGameobject[tempInsideGameobject[i].GetComponent<nameObject>().id] = tempInsideGameobject[i];
        for (int i = 0; i < insideGameobject.Length; i++)
        {
            insideTransform[i] = insideGameobject[i].transform;
        }
        for (int i = 0; i < insideTransform.Length; i++)
            insideTransform[i].position = outsidePos[i];

        changeGameobject();
    }

    void changeWorld()
    {
        if (nowWorld == world.outside)
        {
            for (int i = 0; i < outsideGameobject.Length; i++)
                outsidePos[outsideGameobject[i].GetComponent<nameObject>().id] = outsideGameobject[i].transform.position;
            intoInside();
        }
        else
        {
            for (int i = 0; i < insideGameobject.Length; i++)
                insidePos[insideGameobject[i].GetComponent<nameObject>().id] = insideGameobject[i].transform.position;
            intoOutside();
        }
    }

    private void Update()
    {
        
    }
}
