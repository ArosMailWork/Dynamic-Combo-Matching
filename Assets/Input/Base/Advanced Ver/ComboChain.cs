using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComboChain : MonoBehaviour
{
    public List<InputQueue> inputHistory = new List<InputQueue>();
    
    public void Chain_AddMove(InputQueue input)
    {
        inputHistory.Add(input);
    }
    
    public void Chain_AddCombineMove(IComboCommand action, int comboSequenceLength)
    {
        // Check if there are enough inputs in history to remove
        if (inputHistory.Count >= comboSequenceLength)
        {
            // Remove the last 'comboSequenceLength' inputs from the history
            inputHistory.RemoveRange(inputHistory.Count - comboSequenceLength, comboSequenceLength);
        }
        
        // Add the combine move as a new input
        var input = new InputQueue { action = action };
        inputHistory.Add(input);
    }
}
