using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class cshGameManager : MonoBehaviourPun // 점수와 게임 오버 여부 및 게임 UI를 관리하는 게임 매니저 스크립트
{
    public Button joinButton;
    public GameObject Item1;
    public GameObject Item2;
    public GameObject Item3;
    public float time;
    public float time1;

    public void Connect()
    {
        PhotonNetwork.Disconnect();
        SceneManager.LoadScene("Lobby");        
    }

    public static cshGameManager instance // 외부에서 싱글톤 오브젝트를 가져올때 사용할 프로퍼티
    {
        get
        {
            // 만약 싱글톤 변수에 아직 오브젝트가 할당되지 않았다면
            if (m_instance == null)
            {
                // 씬에서 GameManager 오브젝트를 찾아 할당
                m_instance = FindObjectOfType<cshGameManager>();
            }

            // 싱글톤 오브젝트를 반환
            return m_instance;
        }
    }

    private static cshGameManager m_instance; // 싱글톤이 할당될 static 변수

    public GameObject PlayerPrefab; // 생성할 VR 플레이어 캐릭터
    public GameObject SpawnPosPrefab; // 생성할 VR 플레이어 캐릭터의 위치


    private void Awake()
    {
        // 씬에 싱글톤 오브젝트가 된 다른 GameManager 오브젝트가 있다면
        if (instance != this)
        {
            // 자신을 파괴
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        // 생성할 랜덤 위치 지정
        Vector3 randomSpawnPos = SpawnPosPrefab.transform.position;//Random.insideUnitSphere * 5f;
        // 네트워크상의 모든 클라이언트에서 생성 실행  
        // 해당 게임 오브젝트의 주도권은 생성 메서드를 직접 실행한 클라이언트에 있음
        PhotonNetwork.Instantiate(PlayerPrefab.name, randomSpawnPos, Quaternion.identity);
    }
    [PunRPC]
    public void trashSpawn(){
        {
            int num = Random.Range(0, 3);
            if (time >= 1.0)
            {
                if(num==0){
                    PhotonNetwork.Instantiate(Item1.name, new Vector3(Random.Range(-13.0f, 13.0f), 1.3f, Random.Range(30.0f, 50.0f)), Quaternion.identity);
                }
                else if(num==1){
                    PhotonNetwork.Instantiate(Item2.name, new Vector3(Random.Range(-13.0f, 13.0f), 1.3f, Random.Range(30.0f, 50.0f)), Quaternion.identity);
                }
                else{
                    PhotonNetwork.Instantiate(Item3.name, new Vector3(Random.Range(-13.0f, 13.0f), 1.3f, Random.Range(30.0f, 50.0f)), Quaternion.identity);
                }
                time = 0.0f;
            }
            time += Time.deltaTime;
            time1+=Time.deltaTime;
        }
    }

    void Update()
    {
        trashSpawn();
    }
}
