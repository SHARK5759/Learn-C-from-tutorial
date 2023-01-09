using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hacker : MonoBehaviour
{
    //Game state
    // Start is called before the first frame update
    void Start()
    {
        ShowMainMenu();
    }
    void ShowMainMenu()
    {
        Terminal.ClearScreen();
        Terminal.WriteLine("Hello L");
        Terminal.WriteLine("What would you like to hack into?\n");
        Terminal.WriteLine("Press 1 for the local library");
        Terminal.WriteLine("Press 2 for the police station");
        Terminal.WriteLine("Press 3 for the NASA\n");
        Terminal.WriteLine("Enter your selection");
    }

    void OnUserInput(string input)
    {
        if (input == "menu")
        {
            ShowMainMenu();
        }
        else if (input == "1")
        {
            StartGame(1);
        }
        else if (input == "2")
        {
            StartGame(2);
        }
        else if (input == "3")
        {
            StartGame(3);
        }
        else
        {
            Terminal.WriteLine("wrong number");
        }
            
        
    }
    private void StartGame(int level)
    {
        Terminal.WriteLine("You have chosen level"+level);
    }
}
