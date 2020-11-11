using DG.Tweening;
using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

/*
//========================
    Documentação super interessante aqui, que não significa 
    que eu to com preguiça ou algo do tipo.
*/

public class InaDebug : MonoBehaviour
{
    public InaSystem inaScript;

    public TextMeshProUGUI correctsTextbox;
    public TextMeshProUGUI mistakesTextbox;

    public TextMeshProUGUI resultsTextbox;

    public TextMeshProUGUI getTextbox;
    public TextMeshProUGUI chanceTextbox;

    public Image feedbackImage;

    private float gameDificulty = 0;
   
    void Start()
    {
        StartCoroutine(FeedbackImage());
        inaScript = FindObjectOfType<InaSystem>();
        Refresh();
    }

    private void FixedUpdate()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
    }

    public void Refresh()
    {
        //Corrects
        correctsTextbox.text = "";
        foreach(int aux in inaScript.numberCorrects)
        {
            correctsTextbox.text = correctsTextbox.text + aux.ToString() + "\n";
        }

        //Mistakes
        mistakesTextbox.text = "";
        foreach(int aux in inaScript.numberMistakes)
        {
            mistakesTextbox.text = mistakesTextbox.text + aux.ToString() + "\n";
        }

        //Results
        resultsTextbox.text = "";
        foreach(int aux in inaScript.results)
        {
            resultsTextbox.text = resultsTextbox.text + aux.ToString() + "\n";
        }

        chanceTextbox.text = "Chance Result";
    }
    

    public void DebugButtonRight(int whichOne)
    {
        StartCoroutine(FeedbackImage());
        inaScript.CollectInfo(whichOne, true);
        Refresh();
    }

    public void DebugButtonWrong (int whichOne)
    {
        StartCoroutine(FeedbackImage());
        inaScript.CollectInfo(whichOne, false);
        Refresh();
    }

    public void ResetResults()
    {
        StartCoroutine(FeedbackImage());
        inaScript.CleanInfo();
        Refresh();
    }

    public void ResultsButton()
    {
        StartCoroutine(FeedbackImage());
        inaScript.CalculateResults();
        Refresh();
    }

    public void GetButton()
    {
        StartCoroutine(FeedbackImage());
        getTextbox.text = "";
        getTextbox.text = "Index: " + inaScript.maxIndex.ToString() + "\n" + "Result: " + inaScript.maxResult.ToString();

        //Show Chance
        string tempText = "";
        if (gameDificulty == 0)
        {
            tempText = "25%";
        }
        else if (gameDificulty == 1)
        {
            tempText = "50%";
        }
        else if (gameDificulty == 2)
        {
            tempText = "75%";
        }
        chanceTextbox.text = "Chance: " + tempText;
    }   

    public void DifficultyChanger(float which)
    {
        gameDificulty = which;
    }

    IEnumerator FeedbackImage()
    {
        feedbackImage.DOFade(1.0f, 0.25f);
        yield return new WaitForSecondsRealtime(0.75f);
        feedbackImage.DOFade(0.0f, 0.25f);
    }
}
