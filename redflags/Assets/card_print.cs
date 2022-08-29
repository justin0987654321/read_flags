using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;
using System.Data;
using System.Text;
using Random = UnityEngine.Random;
public class card_print : MonoBehaviour
{
    public float frame = 0.2f;
    public float slit_time = 0.0002f;
    public float del_time = 6f;
    public float del_time_2 = 3f;
    public TMP_Text text;
    public int line_length = 30;
    public GameObject gameObject_;

    private string buffer_string;
    public int CharactersPerParagraph = 150;
    public TextAsset file;
    string textval;
    // Start is called before the first frame update


    void Start()
    {
       string[] dataLines = file.text.Split('\n');
       string[][] dataPairs = new string[dataLines.Length][];
       int lineNum = 0;
          foreach (string line in dataLines)
          {
            dataPairs[lineNum++] = line.Split('.');
         
           // Debug.Log(lineNum);
          }

        //textval = dataPairs[Random.Range(0, lineNum )][Random.Range(0, lineNum )];
        //textval = dataLines[Random.Range(0, lineNum)];
        textval = dataLines[Random.Range(0, lineNum)];
        if (string.IsNullOrWhiteSpace(textval)==true)
        {
            gameObject_.SetActive(true);
        }

       // Debug.Log(textval);
        StartCoroutine(coroutineA());

    }

    // Update is called once per frame
  
    void Update()
    {

    }

    IEnumerator coroutineA()
    {

       // Debug.Log("coroutineA created");
        int b = 0;
        int q = 0;
        //code_end = 1;///////////////////////////where code_end is
        for (int i = 0; i < textval.Length; i++)
        {
            //code_end = 1;
            q++;

            b++;
           yield return new WaitForSeconds(frame);


            //ends line after 30 words 

            if (b > line_length && char.IsWhiteSpace(textval[i]))
            {
                text.text += "\n";

                //textval[i]="\n";

                // break ;
                b = 0;
            }
            //creates paragraph after every 100 words 
            if (q > CharactersPerParagraph && char.IsWhiteSpace(textval[i]))
            {
                yield return new WaitForSeconds(del_time_2);
                text.text = " ";
                q = 0;
            }
            //plays sound and prints letters
            text.text += Char.ToString(textval[i]);
            // s1.Play();
            /*yield return new WaitForSeconds(slit_time);
            s1.Stop();*/
            //if voice acting is usesd then take sound code outside for loop 
        }
        //s1.Stop();
        //code_end = true ;// use only in other script controling sprite selection "yes or no"
        //yield return new WaitForSeconds(del_time);
        //text.text = " ";


        //Debug.Log("coroutineA running again");
    }
}
