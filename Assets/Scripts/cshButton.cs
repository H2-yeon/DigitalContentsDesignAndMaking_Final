using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class cshButton : MonoBehaviour
{
    public Button btnJump;
    public Button btnGet;
    public cshPlayerController sPlayer;
    void Start()
    {
        // btnJump.gameObject.SetActive(true);
        // btnJump.onClick.RemoveAllListeners();
        // btnJump.onClick.AddListener(OnClickJumpButton);
        btnGet.gameObject.SetActive(true);
        btnGet.onClick.RemoveAllListeners();
        btnGet.onClick.AddListener(OnClickGetButton);
    }
    void Update()
    {
        UpdateButton();
    }

    private void UpdateButton()
    {
        bool canGet = sPlayer.CanGet();
        btnGet.gameObject.SetActive(canGet);
        // btnJump.gameObject.SetActive(!canGet);
    }

    // private void OnClickJumpButton()
    // {
    //     sPlayer.OnVirtualPadJump();
    // }

    private void OnClickGetButton()
    {
        sPlayer.OnVirtualPadGet();
    }
}

