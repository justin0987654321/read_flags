using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine.SceneManagement;

public class lobbyManager : MonoBehaviourPunCallbacks
{
    // Start is called before the first frame update
    [SerializeField] private TMP_InputField room_inputFeild;
    [SerializeField] private GameObject lobbyPanel;
    [SerializeField] private GameObject roomPanel;
    [SerializeField] public TMP_Text roomName;
    [SerializeField] public Transform ContentObject;
    private int rooms_created = 0;
    public roomItem RoomButtton;

    List<roomItem> roomNamesList_ = new List<roomItem>();
    void Start()
    {
        PhotonNetwork.JoinLobby();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OnClickCreate() {
        if (room_inputFeild.text.Length >= 2 && rooms_created == 0)
        {
            PhotonNetwork.CreateRoom(room_inputFeild.text, new RoomOptions() { MaxPlayers = 5 }, null);

        }

    }
    public void JoinRoom(string roomName) {
        ////used by other players to join 
        PhotonNetwork.JoinRoom(roomName);//???
                                         //Debug.Log("joined room");
                                         // PhotonNetwork.LoadLevel("game scene");


    }
    public override void OnJoinedRoom() {

        roomName.text = "Room name :" + PhotonNetwork.CurrentRoom.Name;
        // PhotonNetwork.LoadLevelAsync("game scene");
        //PhotonNetwork.IsMessageQueueRunning = false;

        if (PhotonNetwork.IsMasterClient) {
            PhotonNetwork.AutomaticallySyncScene = true;
        }
       

        StartCoroutine(MoveToGameScene());
      //  PhotonNetwork.LoadLevel("game scene");
    }
  /*  public void LeaveRoom() {

        PhotonNetwork.LeaveRoom();

    }
    public override void OnLeftRoom() {
        SceneManager.LoadScene("Lobby");
        //PhotonNetwork.LoadLevel("Lobby");

    }*/
    public override void OnRoomListUpdate(List<RoomInfo> roomlist) {
        //when called do somthing

        UpdateRoomList(roomlist);
    }
   
    void UpdateRoomList(List<RoomInfo> list) {

       // roomItem newroom = Instantiate(RoomButtton, ContentObject);
        
       
        foreach (roomItem item in roomNamesList_) {
            Destroy(item.gameObject);
        }
        roomNamesList_.Clear();
       
        foreach (RoomInfo room  in list) {
            roomItem newroom = Instantiate(RoomButtton, ContentObject);
            newroom.SetRoomName(room.Name);
            roomNamesList_.Add(newroom);
           // this.gameObject.SetActive(true);
            Debug.Log("working");
        }
        
        
    }
    /*
    public override void OnConnectedToMaster()
    {
        PhotonNetwork.JoinLobby();
    }*/

    private IEnumerator MoveToGameScene()
    {
        // Temporary disable processing of futher network messages
        PhotonNetwork.IsMessageQueueRunning = false;
        PhotonNetwork.LoadLevel("game scene");
        // LoadNewScene(newSceneName); // custom method to load the new scene by name
        while (PhotonNetwork.LevelLoadingProgress < 1)
        {
            yield return null;
            Debug.Log("building scene");
        }
       PhotonNetwork.IsMessageQueueRunning = true;
    }
}
