using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InvLayerManageer : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(this.gameObject);   
    }
}
