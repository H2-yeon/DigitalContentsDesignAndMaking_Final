using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class cshAct : MonoBehaviour
{
    public float time;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (time >= 1.0)
        {
            this.gameObject.SetActive(false);
            time = 0.0f;
        }
        time += Time.deltaTime;
    }
}
