using Matey_s_Pie_Shop;

WelcomeScreen();

Utilities.InitializeStock();
Utilities.ShowMainMenu();

Console.WriteLine("Application shutting down...");
Console.ReadLine();

void WelcomeScreen()
{
    Console.ForegroundColor = ConsoleColor.Yellow;
    Console.WriteLine(@"
  __  __       _             _       _____ _         _____ _                                                    
 |  \/  |     | |           ( )     |  __ (_)       / ____| |                                                   
 | \  / | __ _| |_ ___ _   _|/ ___  | |__) |  ___  | (___ | |__   ___  _ __                                     
 | |\/| |/ _` | __/ _ \ | | | / __| |  ___/ |/ _ \  \___ \| '_ \ / _ \| '_ \                                    
 | |  | | (_| | ||  __/ |_| | \__ \ | |   | |  __/  ____) | | | | (_) | |_) |                                   
 |_|__|_|\__,_|\__\___|\__, |_|___/ |_|   |_|\___| |_____/|_| |_|\___/| .__/                                _   
 |_   _|                __/ | |                   |  \/  |            | |                                  | |  
   | |  _ ____   _____ |___/| |_ ___  _ __ _   _  | \  / | __ _ _ __  |_| _  __ _  ___ _ __ ___   ___ _ __ | |_ 
   | | | '_ \ \ / / _ \ '_ \| __/ _ \| '__| | | | | |\/| |/ _` | '_ \ / _` |/ _` |/ _ \ '_ ` _ \ / _ \ '_ \| __|
  _| |_| | | \ V /  __/ | | | || (_) | |  | |_| | | |  | | (_| | | | | (_| | (_| |  __/ | | | | |  __/ | | | |_ 
 |_____|_| |_|\_/ \___|_| |_|\__\___/|_|   \__, | |_|  |_|\__,_|_| |_|\__,_|\__, |\___|_| |_| |_|\___|_| |_|\__|
                                            __/ |                            __/ |                              
                                           |___/                            |___/                               
");
    Console.ResetColor();

    Console.WriteLine("Please enter a key to log in!");
    Console.ReadLine();

    //Console.Clear();
}