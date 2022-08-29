using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine.SceneManagement;
public class leaveRoom : MonoBehaviourPunCallbacks
{
  
 
    public void LeaveRoom()
    {

        PhotonNetwork.LeaveRoom();

    }
    public override void OnLeftRoom()
    {
        SceneManager.LoadScene("Lobby");
        //PhotonNetwork.LoadLevel("Lobby");

    }
}
