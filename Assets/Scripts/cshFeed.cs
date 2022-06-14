using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class cshFeed : MonoBehaviour
{
    public GameObject Fish;
    public GameObject Part;
    public GameObject Panel;
    public Button Button;

    public void OnClick()
    {
        Instantiate(Fish, new Vector3(0.4f,1.7f,24.5f), Quaternion.identity);
        Instantiate(Part, new Vector3(0.0f,8.7f,25.7f), Quaternion.identity);
    }

    public void showPanel()
    {
        Invoke("invoke", 1.5f);
    }
    public void showBtn()
    {
        Invoke("invokeBtn", 2.5f);
    }
    public void invoke()
    {
        Panel.gameObject.SetActive(true);
    }
    public void invokeBtn()
    {
        Button.interactable = true;
    }
}
