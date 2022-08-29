using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Photon.Pun;
using UnityEngine.SceneManagement;

public class networking : MonoBehaviourPunCallbacks
{
    [SerializeField] private TMP_InputField username_input;
    [SerializeField] private TMP_Text buttonText;
    [SerializeField] private GameObject fade;
    [SerializeField] private GameObject StartButtton;
   // [SerializeField] private Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        fade.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        bool enter = Input.GetKeyDown(KeyCode.Return);

        // OnClickConnect();
        /* int i = 0;
         int b = 0;
         while (i< username_input.text.Length)
         {
             if (username_input.text[i]=" ") {
                 b += 1;
                 if (b = 4) {
                     break;
                 }
             }
         }*/
        if (username_input.text.Length >=3)//->there actually has to be a name entered for the game button to be created 
        {
            StartButtton.SetActive(true);
            if (enter) {
                OnClickConnect();
            }
        }
        else
        {
         StartButtton.SetActive(false);
        }
    }

    public void OnClickConnect() {


        if (username_input.text.Length >= 3)//->there actually has to be a name entered for the game button to be created 
        {
           // StartButtton.SetActive(true);
            PhotonNetwork.NickName = username_input.text;
            buttonText.text = "Connecting...";
            PhotonNetwork.ConnectUsingSettings();
            //-do somthing 
        }
       

        Debug.Log("connected");
    }
    public override void OnConnectedToMaster() {
        //->
        fade.SetActive(true);
        StartCoroutine(coroutineB());
     //   SceneManager.LoadScene("Lobby");
    }
    IEnumerator coroutineB()
    {
        yield return new WaitForSeconds(2f);
        SceneManager.LoadScene("Lobby");
     
    }
       
}
