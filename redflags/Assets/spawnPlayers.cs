using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using TMPro;
using Photon.Realtime;
using UnityEngine.SceneManagement;
public class spawnPlayers : MonoBehaviourPunCallbacks
    //,IPunObservable
{

    [SerializeField] private GameObject player_prefab;
    [SerializeField] private GameObject player_prefab_2;
    [SerializeField] private GameObject canvas;
       //public TextAsset file;
    public TMP_Text[] text;
    [SerializeField]
    public Transform[] spawnPoints;
    int MynumberInRoom;
    Player[] allPlayers;
    public GameObject[] placement_holder;
    public 
    bool hasRun = false;
    int join_index = 0;
    int randomNumber = 0;
    Transform spawnPoint;


    public GameObject pplayers;

    void Start()
    {
        int y = 0;

        foreach (Player player in PhotonNetwork.PlayerList)
             {
                 randomNumber++;
               
             }
         randomNumber = randomNumber - 1;
        join_index = randomNumber;
        // text[randomNumber].text = PhotonNetwork.NickName;
       // if (randomNumber == 0) { spawnPoint = spawnPoints[randomNumber]; }
        //else
        //spawnPoint = spawnPoints[randomNumber-1];

        //while (y != 4)
        // {
        if (randomNumber == 0)
        {
            spawnPoint = spawnPoints[randomNumber];
            PhotonNetwork.Instantiate(player_prefab_2.name, spawnPoint.position, Quaternion.identity);
            pplayers.SetActive(false);
        }
        else {
            spawnPoint = spawnPoints[randomNumber - 1];
            PhotonNetwork.Instantiate(player_prefab.name, spawnPoint.position, Quaternion.identity);
           
        }
          
        
            


    }


    void Update()
    {
        if (randomNumber != 0)
        {
            if (!hasRun)
            {
                for (int i = 0; i < PhotonNetwork.PlayerList.Length - 1; i++)
                {

                    text[i].text = PhotonNetwork.PlayerList[i + 1].NickName;
                    placement_holder[i].gameObject.SetActive(true);


                }

                join_index = PhotonNetwork.PlayerList.Length;


            }
            if (PhotonNetwork.PlayerList.Length > join_index)
            {

                hasRun = false;
                // Debug.Log("runnuing");
            }
           
            if (PhotonNetwork.PlayerList.Length == join_index)
            {

                hasRun = true;
          
            }

        }
      

       
    }



















}
