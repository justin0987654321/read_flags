using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class card_detection : MonoBehaviour
{
    public GameObject white_card_deck;
    public GameObject red_card_deck;
    public GameObject whiteCard_parent;
    public GameObject redCard_parent;


    private GameObject textObject;
    private int Number_of_whitecards = 0;
    private int Number_of_RedCards = 0;

    private bool has_run_w = false;
    private bool has_run_r = false;

    int i = 0;
    int j = 0;
    int n = 0;
    int m = 0;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //if (white_card_deck.transform.childCount < 3)
        if (Number_of_whitecards > 1)
        {

            (white_card_deck.transform.GetChild(0)).GetChild(2).gameObject.SetActive(true);


            Destroy((white_card_deck.transform.GetChild(0)).gameObject.GetComponent<BoxCollider2D>());


            (white_card_deck.transform.GetChild(1)).GetChild(2).gameObject.SetActive(true);


            Destroy((white_card_deck.transform.GetChild(1)).gameObject.GetComponent<BoxCollider2D>());


            has_run_w = true;


        }


        //////////not running correctly 
        if (Number_of_whitecards <= 1 && has_run_w)
        {
            while (j < white_card_deck.transform.childCount)
            {
                (white_card_deck.transform.GetChild(j)).gameObject.AddComponent<BoxCollider2D>();

                j++;
            }
            j = 0;
            while (i < white_card_deck.transform.childCount)
            {
                (white_card_deck.transform.GetChild(i)).GetChild(2).gameObject.SetActive(false);
                i++;
            }
            i = 0;

            has_run_w = false;


            ///then the script should be added too robbaly use a while loop;
        }
        if (Number_of_RedCards > 0)
        {
            (red_card_deck.transform.GetChild(0)).GetChild(1).gameObject.SetActive(true);


            Destroy((red_card_deck.transform.GetChild(0)).gameObject.GetComponent<BoxCollider2D>());
            has_run_r = true;

        }
        if (Number_of_RedCards == 0 && has_run_r)
        {
            while (m < red_card_deck.transform.childCount)
            {
                (red_card_deck.transform.GetChild(m)).gameObject.AddComponent<BoxCollider2D>();

                m++;
            }
            j = 0;
            while (n < red_card_deck.transform.childCount)
            {
                (red_card_deck.transform.GetChild(n)).GetChild(1).gameObject.SetActive(false);
                n++;
            }
            n = 0;

            has_run_r = false;


            ///then the script should be added too robbaly use a while loop;
        }

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

        Debug.Log("Collision Detected");

        // collision.gameObject.transform.SetParent(new_parent.transform, false);

        textObject = collision.gameObject.transform.GetChild(0).gameObject;

        ///////////////////////////print the text component
        // Debug.Log(textObject.GetComponent<TMP_Text>().text);

        ////////////////////
        //Debug.Log(collision.gameObject.tag);
        if (IsWhite(collision.gameObject.tag))
        {
            Number_of_whitecards += 1;
            Debug.Log("number of white cards " + Number_of_whitecards);
            collision.gameObject.transform.SetParent(whiteCard_parent.transform, false);
        }
        if (IsRed(collision.gameObject.tag))
        {
            Number_of_RedCards += 1;
            Debug.Log("number of red cards " + Number_of_RedCards);
            collision.gameObject.transform.SetParent(redCard_parent.transform, false);
        }


    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (IsWhite(collision.gameObject.tag))
        {
            Number_of_whitecards -= 1;
            Debug.Log("number of white cards " + Number_of_whitecards);
            collision.gameObject.transform.SetParent(white_card_deck.transform, false);

        }
        if (IsRed(collision.gameObject.tag))
        {
            Number_of_RedCards -= 1;
            Debug.Log("number of red cards " + Number_of_RedCards);
            collision.gameObject.transform.SetParent(red_card_deck.transform, false);
        }
        Debug.Log("Collision over");
    }

}
