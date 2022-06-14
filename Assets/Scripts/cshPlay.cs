using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class cshPlay : MonoBehaviour
{
    public GameObject Part;
    public GameObject Panel;
    public Button Button;

    public void OnClick()
    {
        Instantiate(Part, new Vector3(0.0f,2.3f,25.5f), Quaternion.identity);
    }

    public void showPanel()
    {
        Invoke("invoke", 1.0f);
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
