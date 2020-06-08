using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class TerminalControl : MonoBehaviour
{
    enum Screen
    {
        MainMenu,
        Password,
        Win
    }

    private Screen currentScreen = Screen.MainMenu;

    const string menuHint = "Napishite 'menu' chtob vernutsya v menu";
    
    private int level;
    private string password;
    private string[] Level1Passwords = {"Girya", "Jopa", "Kukla", "lapka", "Doska"};
    private string[] Level2Passwords = {"Kishki", "Sobaka", "Nozdrya", "Ruchka", "Mimozirya"};
    private string[] Level3Passwords = {"Krakazyabra", "Annilingus", "Laapenranta", "Pussyripper", "Eiyafladlkudl"};
    
    
    void Start()
    {
        print(Level1Passwords[3]);
        ShowMainMenu("user");
    }

    void ShowMainMenu(string playerName)
    {
        currentScreen = Screen.MainMenu;
        level = 0;
        Terminal.ClearScreen();
        Terminal.WriteLine("Privet " + playerName + " !");
        Terminal.WriteLine("Kakoi terminal ti hoshesh vzlomat");
        Terminal.WriteLine(" ");
        Terminal.WriteLine("Vvedite 1 - gorodskayz biblioteka");
        Terminal.WriteLine("Vvedite 2 - polic uchastok");
        Terminal.WriteLine("Vvedite 3 - spice korabl");
        Terminal.WriteLine("Vash vibor: ");
    }
    
    void OnUserInput(string input)
    {
        if (input == "menu")
        {
            ShowMainMenu("polzovatel");
        }
         
        else if (currentScreen == Screen.MainMenu)
        {
            RunMainMenu(input);
        }
        
        else if (currentScreen == Screen.Password)
        {
            CheckPassword(input);
        }
    }
    void RunMainMenu(string input)
    {

        bool isValidLevelNumber = (input == "1" || input == "2" || input == "3");

        if (isValidLevelNumber)
        {
            level = int.Parse(input);
            GameStart();
        }
        else
        {
            Terminal.WriteLine("Vvedite pravilnoe znachenie");
        }

        switch (input)
        {
            case "007":
                Terminal.WriteLine("Hello Mr Bond");
                break;
            case "Za Ordu!":
                Terminal.WriteLine("Sosi eldu!");
                break;
            case "21.06.1991":
                Terminal.WriteLine("Sveta horoshaya :3");
                break;
            case "Ya vas ne zval":
                Terminal.WriteLine("Idite nahui");
                break;
        }
    }

    void CheckPassword(string input)
    {

        if (input == password)
        {
            ShowWinScreen();
        }
        else
        {
            GameStart();
        }
    }

    void ShowWinScreen()
    {
        Terminal.ClearScreen();
        Reward();
    }

    void Reward()
    {
        currentScreen = Screen.Win;

        switch (level)
        {
        case 1:
        Terminal.WriteLine("Parol verniy! Derjite vashu knigu:");
        Terminal.WriteLine(
            @"
          ______ ______
        _/      Y      \_
       // ~~ ~~ | ~~ ~  \\
      // ~ ~ ~~ | ~~~ ~~ \\      
     //________.|.________\\     
    `----------`-'----------'
             ");
        break;
        case 2:
            Terminal.WriteLine("Parol verniy! Vot vash kluch :");
            Terminal.WriteLine(
                @"
           .--.
         /.-. '----------.
         \'-' .--''--'-'-'
           '-'
                ");
            break;
        case 3:
            Terminal.WriteLine("Parol verniy! Vot vash komp :");
            Terminal.WriteLine(
                @"
    .--.
    |__| .-------.
    |=.| |.-----.|
    |--| || UNT ||
    |  | |'-----'|
    |__|~')_____('
                ");
            break;
        }
        Terminal.WriteLine(menuHint);
    }
    
    void GameStart()
    {
        Terminal.ClearScreen();
        currentScreen = Screen.Password;

        switch (level)
        {    
            case 1:
                password = Level1Passwords[Random.Range(0, Level1Passwords.Length)];
                Terminal.WriteLine("Vi v gorodskoy biblioteke");
                break; 
            case 2:
                password = Level2Passwords[Random.Range(0, Level2Passwords.Length)]; 
                Terminal.WriteLine("Vi v polic uchastke");
                break;
            case 3:
                password = Level3Passwords[Random.Range(0, Level3Passwords.Length)];
                Terminal.WriteLine("Vi na kosmich karable");
                break;
            default:
                Debug.LogError("Takogo urovnya ne sushestvuet");
                break;
        }
  
        Terminal.WriteLine("Podskazka: " + password.Anagram());
        Terminal.WriteLine(menuHint);
        Terminal.WriteLine("Vvedite parol");
    }
}