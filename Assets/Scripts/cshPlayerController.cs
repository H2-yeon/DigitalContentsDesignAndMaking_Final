using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class cshPlayerController : MonoBehaviourPun
{
    private Animator m_animator;
    private Vector3 m_velocity;
    private cshGetArea m_getArea = null;
    public cshJoystick sJoystick;
    public GameObject m_UI;
    public float m_Speed = 4.0f;
    public int score=0;

//    private bool Get = false;

    void Start()
    {
        m_animator = GetComponent<Animator>();
        m_getArea = GetComponentInChildren<cshGetArea>();

    }

    void Update()
    {
        if (!photonView.IsMine)
        {
            m_UI.SetActive(false);
            return;
        }

        PlayerMove();
        score=GetComponent<cshTrashController>().score;
        print(score);
    }

    public bool CanGet()
    {
        return 0 < m_getArea.colliders.Count;
    }

    private void PlayerMove()
    {
        CharacterController controller = GetComponent<CharacterController>();
        float gravity = 20.0f;
        if (controller.isGrounded)
        {
            float h = sJoystick.GetHorizontalValue();
            float v = sJoystick.GetVerticalValue();
            m_velocity = new Vector3(h, 0, v);
            m_velocity = m_velocity.normalized;
            
            m_animator.SetFloat("speed", m_velocity.magnitude);
            
            if (m_velocity.magnitude > 0.5)
            {
                transform.LookAt(transform.position + m_velocity);
            }
        }
        m_velocity.y -= gravity * Time.deltaTime;
        controller.Move(m_velocity * m_Speed * Time.deltaTime);

        //m_isGrounded = controller.isGrounded;
    }

    public void OnVirtualPadGet()
    {
        if (this == null) { return; }

        m_animator.SetTrigger("Get");

        Vector3 center = Vector3.zero;
        int cnt = m_getArea.colliders.Count;
        int cntBreak = 0;

        for (int i = 0; i < m_getArea.colliders.Count; ++i)
        {
            var collider = m_getArea.colliders[i];
            center += collider.transform.localPosition;

            var trash = collider.GetComponent<cshTrashController>();
            if (trash != null)
            {
                PhotonView pv = trash.gameObject.GetComponent<PhotonView>();
                int id = collider.gameObject.GetComponent<PhotonView>().ViewID;
                pv.RPC("RPCDamage", RpcTarget.All, id);
                m_getArea.colliders.Clear();
            }
            else
            {
                int id = collider.gameObject.GetComponent<PhotonView>().ViewID;
                photonView.RPC("RPCDestroy", RpcTarget.All, id);
                m_getArea.colliders.Clear();
            }
        }
        if (cntBreak > 0) m_getArea.colliders.Clear();

        center /= cnt;
        center.y = transform.localPosition.y;
        transform.LookAt(center);
    }
    [PunRPC]
    public void RPCDestroy(int id)
    {
        Destroy(PhotonView.Find(id).gameObject);
    }

}

