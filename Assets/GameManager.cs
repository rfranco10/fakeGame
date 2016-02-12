using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {

	public string[] definitions;
    public string[] answers;
    public Text definitionTextBox;
    public Text[] buttonTextArray;
    public Text feedbackTextBox;
    int currentCorrectAnswerIndex;


    
	// Use this for initialization
	void Start () {
        GenerateNewProblem();
	}
	
	// Update is called once per frame
	void Update () {
        
    }

    void GenerateNewProblem()
    {
        int currentAnswerIndex = GetRandomIndex();
        int incorrectAnswerIndex1 = GetRandomIndex();
        int incorrectAnswerIndex2 = GetRandomIndex();
        int incorrectAnswerIndex3 = GetRandomIndex();

        while (incorrectAnswerIndex1 == currentAnswerIndex)
        {
            incorrectAnswerIndex1 = GetRandomIndex();
        }

        while (incorrectAnswerIndex2 == currentAnswerIndex || incorrectAnswerIndex2 == incorrectAnswerIndex1)
        {
            incorrectAnswerIndex2 = GetRandomIndex();
        }

        while (incorrectAnswerIndex3 == currentAnswerIndex || incorrectAnswerIndex3 == incorrectAnswerIndex1 || incorrectAnswerIndex3 == incorrectAnswerIndex2)
        {
            incorrectAnswerIndex3 = GetRandomIndex();
        }

        definitionTextBox.text = definitions[currentAnswerIndex];

        ShuffleButtonArray(buttonTextArray);

        buttonTextArray[0].text = answers[currentAnswerIndex];
        buttonTextArray[1].text = answers[incorrectAnswerIndex1];
        buttonTextArray[2].text = answers[incorrectAnswerIndex2];
        buttonTextArray[3].text = answers[incorrectAnswerIndex3];

        //set current answer outside of method scope
        currentCorrectAnswerIndex = currentAnswerIndex;
    }

    //random integer
    int GetRandomIndex()
    {
        int index;
        index = Random.Range(0,definitions.Length);
        return index;
    }

    void ShuffleButtonArray(Text[] items)
    {
        for (int index = 0; index < items.Length; index++)
        {
            Text temp = items[index];
            int randomIndex = Random.Range(0, items.Length - 1);
            items[index] = items[randomIndex];
            items[randomIndex] = temp;
        }     
    }

    //event listener for mouse clicks
    public void GradeAnswer(Text buttonClicked)
    {
        if (buttonClicked.text == answers[currentCorrectAnswerIndex])
        {
            Debug.Log("correct answer");
            feedbackTextBox.text = "Great job!";
        }
        else
        {
            Debug.Log("incorrect");
            feedbackTextBox.text = "Incorrect.  Try the next one.";
        }

        GenerateNewProblem();

    }
}
