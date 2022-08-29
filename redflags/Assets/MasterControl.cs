using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using TMPro;
using Photon.Realtime;
using UnityEngine.SceneManagement;

public class MasterControl : MonoBehaviourPun
{
    public GameObject master;
    public GameObject master_2;
    public GameObject[] smashORpass;
    public GameObject[] textHolder;
    public TMP_Text[] text;
    public int fadeTime;
    public float FlickerTime = 1f;
    bool hasrun = false;
    bool hasrun_2 = false;
    int i = 0;
    int j = 0;
    int m = 0;
    int uu = 0;
    int ii = 0;
    int x = 0;
    public GameObject[] platerAtributeHolder;
    public GameObject spawnobject;
    // Start is called before the first frame update
    int randomNumber = 0;
    void Start()
    {

        foreach (Player player in PhotonNetwork.PlayerList)
        {
            randomNumber++;

        }
        randomNumber = randomNumber - 1;
        textHolder[0].SetActive(true);

        Debug.Log("ugh :"+photonView.OwnerActorNr);
        if (randomNumber == 0)
        {
            master.SetActive(true);
           // smashORpass[ii].SetActive(true);
        }
        if (randomNumber != 0)
            master.SetActive(false);


        if (fadeTime > 0)
        {
            fadeTime = 1;
        }
      
       // text[0].VertexColor;
    }
    /*public bool CardwasPlayed() {
        return true;
    }*/

    // Update is called once per frame
    void Update()
    {

        if (PhotonNetwork.PlayerList.Length > 1 && !hasrun && randomNumber==0)
        {

         
                smashORpass[ii].SetActive(true);
                master.SetActive(false);
               // master_2.SetActive(true);

                 hasrun = true;

        }
        if (PhotonNetwork.PlayerList.Length < 1 && !hasrun)
            {
            

            StartCoroutine(FadeCoroutine());

           /* while (ii != PhotonNetwork.PlayerList.Length - 1)
            {
                smashORpass[ii].SetActive(true);
                ii++;
            }*/

            hasrun = true;

            }

      /*  while (x!=4)
        {
            platerAtributeHolder[uu].transform.childCount

        }*/
        if (platerAtributeHolder[uu].transform.childCount > 0)
           {
            Debug.Log("looooool");
            hasrun_2 = true;
            uu += 1;
         
           }

        //////remember to edit 1->2
        if (PhotonNetwork.PlayerList.Length > 1 && hasrun_2)
        {
            /*while (m != PhotonNetwork.PlayerList.Length-1)
            {
                smashORpass[m].SetActive(true);
            }*/
            while (j != 4)
            {
                if (platerAtributeHolder[j].transform.childCount > 0){



                    while (i != platerAtributeHolder[j].transform.childCount )
                    {
                        // smashORpass[i].SetActive(true);
                        Debug.Log("number of times run " + i);
                        GameObject child = Instantiate(spawnobject, smashORpass[j].transform);
                        // child = Instantiate(spawnobject, smashORpass[0].transform);
                        child.transform.GetChild(0).transform.GetChild(0).gameObject.GetComponent<TMP_Text>().text = platerAtributeHolder[j].transform.GetChild(i).gameObject.GetComponent<TMP_Text>().text;
                        i++;
                    }
                }
                j++;
            }
            hasrun_2 = false;
        }


        /* if (!hasrun_2)
        {
            hasrun_2 = true;
          
            smashORpass[0].SetActive(true);
            GameObject child = Instantiate(spawnobject, smashORpass[0].transform);
            child.transform.GetChild(0).gameObject.GetComponent<TMP_Text>().text = platerAtributeHolder[0].transform.GetChild(0).gameObject.GetComponent<TMP_Text>().text;
          
        }*/

        /*if (platerAtributeHolder[0].transform.childCount > 0)
        {
            child.transform.GetChild(0).gameObject.GetComponent<TMP_Text>().text = platerAtributeHolder[0].transform.GetChild(0).gameObject.GetComponent<TMP_Text>().text;
        }*/





    }
    ///flicker;
    IEnumerator FadeCoroutine()
    {
        //remember to edit 2->3
        while (PhotonNetwork.PlayerList.Length < 1) {
            float waitTime = 0;
            yield return new WaitForSeconds(1f);
            while (waitTime < 1)
            {
                text[0].fontMaterial.SetColor("_FaceColor", Color.Lerp(Color.clear, Color.white, waitTime));
                yield return null;
                waitTime += Time.deltaTime / fadeTime;


            }

            yield return new WaitForSeconds(1f);

            while (waitTime > 0)
            {
               
                text[0].fontMaterial.SetColor("_FaceColor", Color.Lerp(Color.clear, Color.white, waitTime));
                yield return null;
                waitTime -= Time.deltaTime / fadeTime;


            }
        }

    }
}
