using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Panel : MonoBehaviour
{
    private static Panel instance;
    public static Panel Instance
    {
        get { return instance; }
    }
    protected virtual void Awake()
    {
        RemoveCanvas();
        if (instance != null)
            Destroy(gameObject);
        else
            instance = (Panel)this;
    }
    public static bool IsInitialized
    {
        get { return instance != null; }
    }
    protected virtual void OnDestroy()
    {
        if (instance == this)
        {
            instance = null;
        }
    }
    public void RemoveCanvas()
    {
        GetComponent<CanvasGroup>().alpha = 0;
    }
    // Start is called before the first frame update

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            GetComponent<CanvasGroup>().alpha = 1;
            Time.timeScale = 0;

        }

    }
    
}
