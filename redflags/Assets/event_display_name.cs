using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using TMPro;
using Photon.Realtime;
using UnityEngine.SceneManagement;
using ExitGames.Client.Photon;
public class event_display_name : MonoBehaviourPun
{
    public TMP_Text[] text;
    public GameObject[] objj;
    private const byte TEXT_SEND_EVENT = 0;
    int randomNumber =0 ;
    Player[] allPlayers;
    // Start is called before the first frame update
    void Start()
    {

        foreach (Player player in PhotonNetwork.PlayerList)
        {
            randomNumber++;
        
        }
        randomNumber = randomNumber - 1;
    }

    // Update is called once per frame
    void Update()
    {


        
    }
    public void OOnclick_() {

       
            spawn_name();
            Debug.Log("pressed");
        

    }
    private void spawn_name() {
        bool ISAActive = false;
        string Name = PhotonNetwork.PlayerList[randomNumber].NickName;

       // text[randomNumber].text = Name;
        objj[randomNumber].SetActive(ISAActive);

        object[] datas = new object[]{ISAActive};
        RaiseEventOptions raiseEventOptions = new RaiseEventOptions { Receivers = ReceiverGroup.All };

        PhotonNetwork.RaiseEvent(TEXT_SEND_EVENT,datas, raiseEventOptions, SendOptions.SendReliable);


    }
    private void OnEnable()
    {
        PhotonNetwork.AddCallbackTarget(this);
        PhotonNetwork.NetworkingClient.EventReceived+= NetworkingClient_EventReceived;
    }

    private void OnDisable()
    {
        PhotonNetwork.RemoveCallbackTarget(this);
        PhotonNetwork.NetworkingClient.EventReceived -= NetworkingClient_EventReceived;
    }
    private void NetworkingClient_EventReceived(EventData obj) {

          //byte eventCode = photonEvent.Code;
        //throw new System.NotImplementedException();
        if (obj.Code == TEXT_SEND_EVENT)
        {
            object[] datas = (object[])obj.CustomData;
            bool ISAActive = (bool)datas[0];
           // string Name = (string)datas[1];

           // text[randomNumber].text = Name;
            objj[randomNumber].SetActive(ISAActive);

        }
    }
}
