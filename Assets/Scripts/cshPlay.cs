using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cshPlay : MonoBehaviour
{
    public GameObject Part;

    public void OnClick()
    {
        Instantiate(Part, new Vector3(0.0f,2.3f,25.5f), Quaternion.identity);
    }
}
