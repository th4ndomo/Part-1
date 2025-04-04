using System.IO;

namespace Part_1
{
    //import the system.media
    using System.Media;
    using System;
    using System.Runtime.CompilerServices;
    using System.Collections;
    using System.Drawing;

    public class Chatbot
    {
        //Constructor
        public Chatbot()
        {
            

            //now we get where the project is
            string project_location = AppDomain.CurrentDomain.BaseDirectory;

            //check if it is getting the directory
            Console.WriteLine(project_location);

            //now lets replace the bin\debug\so it can get the sound
            string updated_path = project_location.Replace("bin\\Debug\\","");
            //combining the wav name as Voice AI.wav with updated path
            string full_path = Path.Combine(updated_path, "Audio.wav");

            //Passing sound to Play_Sound method
            Play_Sound(full_path);

            //Calling Ascii Art method
            Ascii_Art();

            // Creating an ArrayList to store topics and chatbot responses
            ArrayList topics = new ArrayList
            {

                new string[] { "phishing", "AI:Phishing is a cyber attack where attackers impersonate trusted entities to steal sensitive information like passwords and credit card numbers." },
                new string[] { "password safety", "AI:Password safety involves using strong, unique passwords for each account, enabling multi-factor authentication, and never sharing your credentials." },
                new string[] { "safe browsing", "AI:Safe browsing includes avoiding suspicious links, keeping software updated, and using security tools like antivirus software and browser extensions." }
            };
            string userInput;

            //ASCII Logo
            Console.WriteLine("===================================================================================================================================================================================================================");
            //Welcoming the user
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("AI:Hello!Welcome to the Cybersecurity Awareness Bot.I'm here to help you stay safe online.");
            Console.WriteLine("==================================================================================================");

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("AI:What is your name?");
            Console.WriteLine("==================================================================================================");

            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("User:");
            string userName = Console.ReadLine();
            Console.WriteLine("==================================================================================================");

            //After entering name application will greet user with their name
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("AI:Hi " + userName + ",how are you?");
            Console.WriteLine("==================================================================================================");

            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("User:");
            string respsonse1 = Console.ReadLine();
            Console.WriteLine("==================================================================================================");

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("AI:Glad to hear that!How can I help you today?");
            Console.WriteLine("==================================================================================================");

            //User has to ask this question "What can i ask you about?".
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("User:");
            string ask1 = Console.ReadLine();
            Console.WriteLine("==================================================================================================");

            //Creating do while to allow chatbot to interact with the user until user types exit
            do
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("AI:You can ask me about phishing, password safety, and safe browsing.");
                Console.WriteLine("==================================================================================================");

                //After user enters their topic the chatbot will search for their input
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write("User:");
                userInput = Console.ReadLine()?.Trim().ToLower();
                Console.WriteLine("==================================================================================================");

                bool topicFound = false;

                //If the user input matches the topic, the chatbot will respond with the message
                foreach (string[] topic in topics)
                {

                    if (userInput == topic[0])
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine(topic[1]);
                        topicFound = true;
                        break;
                    }//end of if statement
                }//end of for loop

                //if statement for to ask user to enter again if the input doesnt match any of the topics
                if (!topicFound && userInput != "exit")
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("AI:I didn't quite understand.Could you rephrase?");
                    Console.WriteLine("==================================================================================================");
                }
                if (userInput != "exit")
                {
                    Console.WriteLine("AI:Anything else I can help you with?If not,type 'exit' to quit.");
                }

            } while (userInput != "exit");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("AI:Thank you for using Chatbot.Stay safe online!");

        }//end of constructor

        //method to play sound
        private void Play_Sound(string full_path)
        {
            //try and cath
            try
            {
                //or play sound
                using (SoundPlayer player = new SoundPlayer(full_path))
                {
                    //play sound till end use this
                    player.PlaySync();

                }//end of using

            }catch (Exception error)
            {
                //then show the error message
                Console.WriteLine(error.Message);

            }//end of catch

        }//end of method

        private void Ascii_Art()
        {
            //getting the full path
            string path_project = AppDomain.CurrentDomain.BaseDirectory;

            //then replace the bin\\debug\\
            string new_path_project = path_project.Replace("bin\\Debug\\", "");

            //combining the prject full path with the image name
            string full_path = Path.Combine(new_path_project, "Prog Log.jpeg");

            Bitmap image = new Bitmap(full_path);
            image = new Bitmap(image, new Size(210, 200));

            //For loop,for inner and outer
            for (int height = 0; height < image.Height; height++)
            {
                for (int width = 0; width < image.Width; width++)
                {
                    Color pixelColor = image.GetPixel(width, height);
                    int color = (pixelColor.R + pixelColor.G + pixelColor.B) / 3;

                    //using char
                    char ascii_design = color > 200 ? '.' : color > 150 ? '*' : color > 100 ? '0' : color > 50 ? '#' : '@';
                    Console.Write(ascii_design);//output of design

                }//end of the inner for loop 
                Console.WriteLine();
            }//end of the for loop outer
        }

    }//end of class

}//end of namespace