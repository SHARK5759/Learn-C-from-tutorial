using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hacker : MonoBehaviour
{
    string[] Level1Password = { "fish","bird","kid","sheep","self"};
    string[] Level2Password = {"rainbow","computer","telephone","bedroom","electronic" };
    //Game state
    int level;
    enum Screen { MainMenu, PassWord, Win };
    Screen CurrentScreen;
    string password;
    // Start is called before the first frame update
    void Start()
    {
       
        ShowMainMenu();
    }
    void ShowMainMenu()
    {
        CurrentScreen = Screen.MainMenu;
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
        else if (CurrentScreen == Screen.MainMenu)
        {
            RunMainMenu(input);
        }
        else if (CurrentScreen == Screen.PassWord)
        {
            CheckPassword(input);
        }


    }

    void CheckPassword(string input)
    {
        if (input == password)
        {
            Terminal.WriteLine("Good Job!");
        }
        else
        {
            Terminal.WriteLine("sorry you are wrong");
        }
    }

    void RunMainMenu(string input)
    {
        if (input == "1")
        {
            level = 1;
            password = Level1Password[2];
            StartGame();
        }
        else if (input == "2")
        {
            level = 2;
            password = Level2Password[3];
            StartGame();
        }
        else if (input == "3")
        {
            level = 3;
            password = "counterbalance";
            StartGame();
        }
        else
        {
            Terminal.WriteLine("wrong number");
        }
    }

    private void StartGame()
    {
        CurrentScreen = Screen.PassWord;
        Terminal.WriteLine("You have chosen level " + level);
        Terminal.WriteLine("Please input your password");
    }
}
