//Page used for headers:
//https://fsymbols.com/generators/carty/
using System;

namespace projectP1{
  class Menus
  {
    //Prints title of the game
    public void welcome(){
      Console.WriteLine("╔═══╗────────────╔╗──╔╦═══╗");
      Console.WriteLine("║╔═╗║────────────║╚╗╔╝║╔═╗║");
      Console.WriteLine("║╚═╝╠══╦══╦╗╔╦══╗╚╗║║╔╩╝╔╝║");
      Console.WriteLine("║╔╗╔╣╔╗║╔╗║║║║║═╣─║╚╝║╔═╝╔╝");
      Console.WriteLine("║║║╚╣╚╝║╚╝║╚╝║║═╣─╚╗╔╝║║╚═╗");    
      Console.WriteLine("╚╝╚═╩══╩═╗╠══╩══╝──╚╝─╚═══╝");   
      Console.WriteLine("───────╔═╝║");    
      Console.WriteLine("───────╚══╝");  
    }
    //Prints the instructions of the game
    public void instructions(){
      Console.WriteLine("╔══╗─────╔╗────────╔╗");
      Console.WriteLine("╚╣╠╝────╔╝╚╗──────╔╝╚╗");
      Console.WriteLine("─║║╔═╗╔═╩╗╔╬═╦╗╔╦═╩╗╔╬╦══╦═╗╔══╗");
      Console.WriteLine("─║║║╔╗╣══╣║║╔╣║║║╔═╣║╠╣╔╗║╔╗╣══╣");
      Console.WriteLine("╔╣╠╣║║╠══║╚╣║║╚╝║╚═╣╚╣║╚╝║║║╠══║");
      Console.WriteLine("╚══╩╝╚╩══╩═╩╝╚══╩══╩═╩╩══╩╝╚╩══╝");
      Console.WriteLine("The player gets to choose which kind of adventurer to be, a Fighter, a Thief or a Wizard. The enemies are represented as 'R' for Rat, 'B' for Bat, 'S' for Skeleton, 'G' for Goblin and 'M' for Minotaur. The goal is to go through the three included levels without being killed by the monsters that will be chasing you.");
      Console.WriteLine("Now it's your turn to play!");
    }
    //Prints available classes
    public void chooseClass(){
      Console.WriteLine("Press the number of class you'd like to be: ");
      Console.WriteLine("1. Fighter");
      Console.WriteLine("2. Thief");
      Console.WriteLine("3. Wizard");
    }
    
    //Shows that the game has started
    public void startOfGame(){
      Console.WriteLine("╔═══╗───────╔╗");
      Console.WriteLine("║╔═╗║───────║║");
      Console.WriteLine("║╚═╝╠══╦══╦═╝╠╗─╔╗");
      Console.WriteLine("║╔╗╔╣║═╣╔╗║╔╗║║─║║");
      Console.WriteLine("║║║╚╣║═╣╔╗║╚╝║╚═╝║");
      Console.WriteLine("╚╝╚═╩══╩╝╚╩══╩═╗╔╝");
      Console.WriteLine("─────────────╔═╝║");
      Console.WriteLine("─────────────╚══╝");

      Console.WriteLine("╔╗─────╔╗");
      Console.WriteLine("║║────╔╝╚╗");
      Console.WriteLine("║║──╔═╩╗╔╬══╗");
      Console.WriteLine("║║─╔╣║═╣║║══╣");
      Console.WriteLine("║╚═╝║║═╣╚╬══║");
      Console.WriteLine("╚═══╩══╩═╩══╝");

      Console.WriteLine("╔═══╗──╔╗");
      Console.WriteLine("║╔═╗║──║║");
      Console.WriteLine("║║─╚╬══╣║");
      Console.WriteLine("║║╔═╣╔╗╠╝");
      Console.WriteLine("║╚╩═║╚╝╠╗");
      Console.WriteLine("╚═══╩══╩╝");
    }
    //If the player wins
    public void congratulations(){
      Console.WriteLine("╔═══╗─────────────╔╗───╔╗───╔╗──────────╔╗");
      Console.WriteLine("║╔═╗║────────────╔╝╚╗──║║──╔╝╚╗─────────║║");
      Console.WriteLine("║║─╚╬══╦═╗╔══╦═╦═╩╗╔╬╗╔╣║╔═╩╗╔╬╦══╦═╗╔══╣║");
      Console.WriteLine("║║─╔╣╔╗║╔╗╣╔╗║╔╣╔╗║║║║║║║║╔╗║║╠╣╔╗║╔╗╣══╬╝");
      Console.WriteLine("║╚═╝║╚╝║║║║╚╝║║║╔╗║╚╣╚╝║╚╣╔╗║╚╣║╚╝║║║╠══╠╗");
      Console.WriteLine("╚═══╩══╩╝╚╩═╗╠╝╚╝╚╩═╩══╩═╩╝╚╩═╩╩══╩╝╚╩══╩╝");
      Console.WriteLine("──────────╔═╝║");
      Console.WriteLine("──────────╚══╝");
    }
    //If the player's health reaches 0
    public void gameOver(){
      Console.WriteLine("╔═══╗─────────╔═══╗");
      Console.WriteLine("║╔═╗║─────────║╔═╗║");
      Console.WriteLine("║║─╚╬══╦╗╔╦══╗║║─║╠╗╔╦══╦═╗");
      Console.WriteLine("║║╔═╣╔╗║╚╝║║═╣║║─║║╚╝║║═╣╔╝");
      Console.WriteLine("║╚╩═║╔╗║║║║║═╣║╚═╝╠╗╔╣║═╣║");
      Console.WriteLine("╚═══╩╝╚╩╩╩╩══╝╚═══╝╚╝╚══╩╝");
    }
  }
}
