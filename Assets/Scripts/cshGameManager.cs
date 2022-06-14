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
    public Button Btn;
    public GameObject text;
    public GameObject text1;
    public GameObject Panel;
    public int a=0;

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
        PhotonNetwork.Instantiate(PlayerPrefab.name, new Vector3(Random.Range(-4.0f, 4.0f), 1.0f, Random.Range(37.0f, 41.0f)), Quaternion.identity);
    }
    [PunRPC]
    public void trashSpawn(){
        {
            if (PhotonNetwork.IsMasterClient&&PhotonNetwork.PlayerList.Length==2&&time1<60.0)
            {
                int num = Random.Range(0, 3);
                if (time >= 2.0)
                {
                    if(num==0){
                        PhotonNetwork.InstantiateRoomObject(Item1.name, new Vector3(Random.Range(-12.0f, 12.0f), 0.5f, Random.Range(30.0f, 50.0f)), Quaternion.identity);
                    }
                    else if(num==1){
                        PhotonNetwork.InstantiateRoomObject(Item2.name, new Vector3(Random.Range(-12.0f, 12.0f), 0.5f, Random.Range(30.0f, 50.0f)), Quaternion.identity);
                    }
                    else{
                        PhotonNetwork.InstantiateRoomObject(Item3.name, new Vector3(Random.Range(-12.0f, 12.0f), 0.5f, Random.Range(30.0f, 50.0f)), Quaternion.identity);
                    }
                    time = 0.0f;
                }
                time += Time.deltaTime;
            }
        }
        if(PhotonNetwork.PlayerList.Length==1&&a==0){
            text.gameObject.SetActive(true);
        }
        if(PhotonNetwork.PlayerList.Length==2){
            a++;
            PhotonNetwork.CurrentRoom.IsOpen = false;
            PhotonNetwork.CurrentRoom.IsVisible =false;
            text.gameObject.SetActive(false);
            text1.gameObject.SetActive(true);
            Btn.interactable = false;
            time1+=Time.deltaTime;
            if(time1>=60.0){
                text1.gameObject.SetActive(false);
                Panel.gameObject.SetActive(true);
            }
        }
        if(time1>=60.0){
            Btn.interactable = true;
        }
    }

    void Update()
    {
        trashSpawn();
    }
}
