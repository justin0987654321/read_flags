using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using TMPro;
using Photon.Realtime;


public class tinderButtonScripts : MonoBehaviourPun
{
    public GameObject tt;
    public GameObject[] obj_1;
    public GameObject[] obj;
    int randomNumber = 0;
    int[] array1 = new int[5];
    int a = 0;
    public TMP_Text text;
    public TMP_Text text_1;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (a == 0) {

        }
        if (a != 0)
        {

        }
        if (PhotonNetwork.PlayerList.Length - 1 == 1)
        {
            obj_1[0].SetActive(false);
            obj_1[1].SetActive(false);
        }
        /* foreach (Player player in PhotonNetwork.PlayerList)
         {
             randomNumber++;

         }
         randomNumber = randomNumber - 1;*/

    }
    public void Onclickleft() {
        if (a!= 0)
        {
            a -= 1;
            obj[a].SetActive(false);
            obj[a - 1].SetActive(true);
            text_1.text = PhotonNetwork.PlayerList[a + 1].NickName;
            Debug.Log("this is a:" + a);
        }
    
        else
        {
            Debug.Log("card not  exsisting");
        }


    }
    public void OnclickRight()
    {
      

       if (a != PhotonNetwork.PlayerList.Length - 1)
        {
        a += 1; 
        obj[a].SetActive(false);
        obj[a].SetActive(true);
        text_1.text = PhotonNetwork.PlayerList[a + 1].NickName;
        Debug.Log("this is a :" + a);

       }
       else
      {
        Debug.Log("card not  exsisting");
      }
    }
    public void OnclickAccept()
    {
        base.photonView.RPC("winner", RpcTarget.All, PhotonNetwork.PlayerList[a+1].NickName);
    }
    public void OnclickDeny()
    {

    }

    [PunRPC]
    private void winner(string player)
    {
        text.text = player;
        tt.SetActive(true);
    }
}
