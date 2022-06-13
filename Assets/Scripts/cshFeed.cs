using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cshFeed : MonoBehaviour
{
    public GameObject Fish;
    public GameObject Part;
    
    public void OnClick()
    {
        Instantiate(Fish, new Vector3(0.4f,1.7f,24.5f), Quaternion.identity);
        Instantiate(Part, new Vector3(0.0f,8.7f,25.7f), Quaternion.identity);
    }
}
