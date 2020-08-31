using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ScoreDisplay : MonoBehaviour
{
    public Text[] rollTexts, frameTexts;

    //private PinCount pinCount;
    void Start()
    {
       // pinCount = gameObject.GetComponent<PinCount>();
    }

    public void getpincount(int pincount)
    {
        if(rollTexts[0].text=="")
        {
            rollTexts[0].text = pincount.ToString();
        }
        else if(rollTexts[1].text=="")
        {
            rollTexts[1].text = pincount.ToString();
        }
        else if (rollTexts[2].text == "")
        {
            rollTexts[2].text = pincount.ToString();
        }
        else if (rollTexts[3].text == "")
        {
            rollTexts[3].text = pincount.ToString();
        }
        else if (rollTexts[4].text == "")
        {
            rollTexts[4].text = pincount.ToString();
        }
        else if (rollTexts[5].text == "")
        {
            rollTexts[5].text = pincount.ToString();
        }
        else if (rollTexts[6].text == "")
        {
            rollTexts[6].text = pincount.ToString();
        }
        else if (rollTexts[7].text == "")
        {
            rollTexts[7].text = pincount.ToString();

        }


    }
    public void FillRollCard(List<int> rolls)
    {

    }
    
}
