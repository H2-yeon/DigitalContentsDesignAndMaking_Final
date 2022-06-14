using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class cshTrash : MonoBehaviourPun
{
    public float time;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (time >= 15.0)
        {
            PhotonNetwork.Destroy(gameObject);
        }
        time += Time.deltaTime;
    }
}
