using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class Hacker : MonoBehaviour
{
    string MenuHint = "you can type menu at any time ";
    string[] Level1Password = { "fish", "bird", "kid", "sheep", "self" };
    string[] Level2Password = { "rainbow", "computer", "telephone", "bedroom", "electronic" };
    string[] Level3Password = { "background", "disappoint", "earthquake", "interested", "understand" };
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
    void RunMainMenu(string input)
    {
        bool isValidLevelNumber = (input == "1" || input == "2" || input == "3");
        if (isValidLevelNumber)
        {
            level = int.Parse(input);//强制转换

            AskForPassword();
        }
        else
        {
            Terminal.WriteLine("wrong number");
            Terminal.WriteLine(MenuHint);
        }
    }
    void AskForPassword()
    {
        CurrentScreen = Screen.PassWord;
        Terminal.ClearScreen();
        SetRandomPassword();
        Terminal.WriteLine("Enter your password, hint: "+password.Anagram());
        Terminal.WriteLine(MenuHint);
    }

    void SetRandomPassword()
    {
        switch (level)
        {
            case 1:
                password = Level1Password[Random.Range(0, Level1Password.Length)];
                break;
            case 2:
                password = Level2Password[Random.Range(0, Level2Password.Length)];
                break;
            case 3:
                password = Level3Password[Random.Range(0, Level3Password.Length)];
                break;
            default:
                Debug.LogError("Invalid level number");
                break;
        }
    }

    void CheckPassword(string input)
    {
        if (input == password)
        {
            DisplayWinScreen();
        }
        else
        {
            AskForPassword();
        }
    }

    void DisplayWinScreen()
    {
        CurrentScreen = Screen.Win;
        Terminal.ClearScreen();
        ShowWinScreen();
        Terminal.WriteLine(MenuHint);
    }

    void ShowWinScreen()
    {
        switch (level)
        {
            case 1:
               Terminal.WriteLine("have a book...");
               Terminal.WriteLine(@"
        ________
       /       //
      /       //
     /_______//      
    (_______(/                                    
                          " );
                break;
            case 2:
                Terminal.WriteLine("have a cow...");
                Terminal.WriteLine(@"
╭┐┌╮
╭┘└┘└╮
└┐．．┌┘——╮
╭┴——┤★　　├╮
│ｏ　ｏ│　　　│●
╰┬——╯　　　│
　 \__|__/_____／
");
                break;
            case 3:
                Terminal.WriteLine("have a tank...");
                Terminal.WriteLine(@"
~●█〓██▄▄▄▄▄▄ ●　●　●
▄▅██████▅▄▃▂
██████████████
◥⊙▲⊙▲⊙▲⊙▲⊙▲⊙▲◤
"); break;
            default:
                Debug.LogError("Invalid level reached");
                break;
        }
        
    }

   

   

}
