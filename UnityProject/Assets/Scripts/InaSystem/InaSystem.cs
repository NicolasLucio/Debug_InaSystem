using System.Linq;
using UnityEngine;

/*
//========================

*/

public class InaSystem : MonoBehaviour
{
    public int howManyIndex = 1;


    [HideInInspector] public int[] numberMistakes;
    [HideInInspector] public int[] numberCorrects;

    [HideInInspector] public int[] results;
    [HideInInspector] public int maxResult;
    [HideInInspector] public int maxIndex;
    

    void Start()
    {
        numberMistakes = new int[howManyIndex];
        numberCorrects = new int[howManyIndex];
        results = new int[howManyIndex];
    }    
  
    public void CollectInfo(int whichIndex, bool isCorrect)
    {
        if (whichIndex < howManyIndex)
        {
            if (isCorrect)
            {
                numberCorrects[whichIndex] += 1;
            }
            else
            {
                numberMistakes[whichIndex] += 1;
            }
        }        
    }

    public void CalculateResults()
    {
        for (int i = 0; i < howManyIndex; i++)
        {
            results[i] = numberMistakes[i] - numberCorrects[i];
        }

        //CheckIndex
        maxResult = results.Max();
        maxIndex = results.ToList().IndexOf(maxResult);
    }

    public void SendResult()
    {
        //== Manual Debug
        // This will only have a utility inGame
    }

    //======= Debug
    // Can have PlayerPref
    public void CleanInfo()
    {
        for (int i = 0; i < howManyIndex; i++)
        {
            numberMistakes[i] = 0;
            numberCorrects[i] = 0;
        }
    }
}
