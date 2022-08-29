using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using TMPro;
using Photon.Realtime;
using UnityEngine.SceneManagement;
public class endround_script : MonoBehaviour
{
    public TMP_Text text_1;
    int randomNumber = 0;
    public GameObject SmashOrPasParent;
    public GameObject timer;
    public GameObject allPlayerUi;

    public GameObject master;
    public GameObject master_2;
    public GameObject[] smashORpass;
   // public GameObject[] textHolder;
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

    public GameObject cam_;
    public GameObject cam_1; 
    // Start is called before the first frame update
    bool roundover = false;
    int val = 10;
    void Start()
    {
        foreach (Player player in PhotonNetwork.PlayerList)
        {
            randomNumber++;

        }
        randomNumber = randomNumber - 1;
        StartCoroutine(coroutineA());
        if (randomNumber == 0)
        {
            timer.SetActive(false);
        }
        else
            allPlayerUi.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        if (randomNumber == 0&& roundover)
        {
            SmashOrPasParent.SetActive(true);
            Debug.Log("AAAActivate");
            // do somthing
        }
        if(randomNumber>0 && roundover) {
            

            StartCoroutine(MoveToGameScene());
        }
        if (randomNumber == 0 && roundover) 
        {
            /*while (m != PhotonNetwork.PlayerList.Length-1)
            {
                smashORpass[m].SetActive(true);
            }*/
            while (j != 4)
            {
                if (platerAtributeHolder[j].transform.childCount > 0)
                {



                    while (i != platerAtributeHolder[j].transform.childCount)
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
    }

    IEnumerator coroutineA()
    {
        while (val != 0)
        {
            text_1.text ="time left :" + val.ToString();
            yield return new WaitForSeconds(3f);

            val--;
        }
        roundover = true;
    }
    private IEnumerator MoveToGameScene()
    {
        // allPlayerUi.SetActive(false);
        cam_.SetActive(false);
        cam_1.SetActive(true);
        timer.SetActive(false);
        yield return new WaitForSeconds(7f);

        Debug.Log("Switch scene");
     
      //  PhotonNetwork.LoadLevel("game scene");
      
            yield return null;
      
    }
}