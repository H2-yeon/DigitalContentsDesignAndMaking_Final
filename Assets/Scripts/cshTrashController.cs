using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class cshTrashController : MonoBehaviourPun
{
    public int score=0;
    [PunRPC]
    public void RPCDamage()
    {
        Destroy(gameObject);
        score++;
    }
}
