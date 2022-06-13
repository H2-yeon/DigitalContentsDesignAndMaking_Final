using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LobbyAnimation : MonoBehaviour
{
    public Animator m_animator;
    public GameObject sPlayer;

    void Awake()
    {
        m_animator = GetComponent<Animator>();

    }
    // Start is called before the first frame update
    public void OnClick()
    {
        m_animator.SetTrigger("Feed");
    }
    public void OnClick1()
    {
        m_animator.SetTrigger("Play");
    }
}
