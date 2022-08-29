using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class roomItem : MonoBehaviour
{
   
    [SerializeField] private TMP_Text roomName;

    lobbyManager manager;
    private void Start() {
        manager = FindObjectOfType<lobbyManager>();
    }

    public void SetRoomName(string _roomName) {
        roomName.text = _roomName;
    }
    public void OnClickJumoIntoRoom() {
        manager.JoinRoom(roomName.text);
    }
}
