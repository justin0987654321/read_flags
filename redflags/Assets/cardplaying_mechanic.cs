using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using TMPro;
using Photon.Realtime;
public class cardplaying_mechanic : MonoBehaviourPun
{
    // Start is called before the first frame update
    //public GameObject[] objects;
    public GameObject objects;
  //  public GameObject[] player_atribute;
    string Card_text;
    string[] cardname = new string[3];
    int numberOfWhiteCards = 0;
    public TMP_Text[] text;
    private TMP_Text child;
   // public int randomNumber = 0;
    //public  TMP_Text text;
    void Start()
    {
      
    }

    // Update is called once per frame
    void Update()
    {
       // Debug.Log("actual number" + randomNumber);
    }
    public string final_()
    {
        string[] gsh;
    }
    public bool IsRed(string objectTag)
    {
        if (objectTag == "red_card")
            return true;
        else
            return false;
    }
    public bool IsWhite(string objectTag)
    {
        if (objectTag == "white_card")
            return true;
        else
            return false;
    }
 
    private void OnTriggerEnter2D(Collider2D collision)
    {
        int randomNumber = 0;
        GameObject obj = this.gameObject;
        if (obj.tag == "playerObj" && (collision.gameObject.tag == "red_card" || collision.gameObject.tag == "white_card"))
        {

            Card_text = collision.transform.GetChild(0).gameObject.GetComponent<TMP_Text>().text;

            numberOfWhiteCards += 1;
         
            base.photonView.RPC("RPC_CardPlayed",RpcTarget.All, Card_text , photonView.OwnerActorNr-1);
        }


    }
    ///work on this
    private void OnTriggerExit2D(Collider2D collision)
    {
        GameObject obj = this.gameObject;
        if (obj.tag=="playerObj" && (collision.gameObject.tag== "red_card" || collision.gameObject.tag=="white_card"))
        {
            numberOfWhiteCards -= 1;



            base.photonView.RPC("RPC_CardTakenAway", RpcTarget.All, collision.transform.GetChild(0).gameObject.GetComponent<TMP_Text>().text);
        }

    }

    [PunRPC]
    private void RPC_CardPlayed(string Card_text, int ranNum)
    {
        
        child = Instantiate(text[1], GameObject.Find("player_atributes").transform.GetChild(0).transform.GetChild(ranNum).transform);
        Debug.Log("number Passed :" + ranNum);
        child.text = Card_text;

    }

    [PunRPC]
    private void RPC_CardTakenAway(string colisionOverCard)
    {
        int i=0;
        int j = 0;
       // Transform[] children;
        GameObject ParentOfChildTdelete = GameObject.Find("player_atributes").transform.GetChild(0).gameObject;
        int children = ParentOfChildTdelete.transform.childCount;

       // Debug.Log(children);
        while (i != children) {

            if (ParentOfChildTdelete.transform.GetChild(i).gameObject.transform.childCount > 0) {

                while (j != ParentOfChildTdelete.transform.GetChild(i).gameObject.transform.childCount) {
                    if (ParentOfChildTdelete.transform.GetChild(i).transform.GetChild(j).gameObject.GetComponent<TMP_Text>().text == colisionOverCard)
                    {
                        Debug.Log(ParentOfChildTdelete.transform.GetChild(i).transform.GetChild(j).gameObject.name);
                        Destroy(ParentOfChildTdelete.transform.GetChild(i).transform.GetChild(j).gameObject);
                    }
                    j++;
                }

            }
            i++;


        }
    }


}


