using UnityEngine;

public class ClueEvaluator : MonoBehaviour
{
    // Reference to the clue container collection
    public ClueContainerCollection clueContainers;

    // Display areas
    public Tweenable choiceArea;
    public Tweenable explanationArea;

    private Clue currentClue;

    public void Evaluate(Clue clue)
    {
        // Store the current clue information
        currentClue = clue;

        // Display the evaluator area
        choiceArea.Enter();
    }
    
    public void ChooseClueType(ClueType choice)
    {
        // Correct Choice
        if(choice == currentClue.clueInfo.type)
        {
            //explanationText.text = currentClue.clueInfo.correctDescription;
        }

        // Incorrect Choice
        else
        {
            //explanationText.text = currentClue.clueInfo.incorrectDescription;
        }

        // Search through all the clue containers
        for (int i = 0; i < clueContainers.collection.Count; i++)
        {
            // If found a matching clue
            if (currentClue.clueInfo == clueContainers.collection[i].clue)
            {
                // Reveal it
                clueContainers.collection[i].Reveal();
            }
        }

        choiceArea.Exit();
        explanationArea.Enter();
    }
}