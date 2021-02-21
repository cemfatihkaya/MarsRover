using MarsRover.Business.Services;
using MarsRover.Model;
using System;
using System.Text;

namespace MarsRover
{
    class Program
    {
        static void Main()
        {
            SetGlobalExceptionHandler();

            //First Rover
            var firstPlateau = new Plateau(new Position(5, 5));
            var firstRover = new RoverService(firstPlateau, new Position(1, 2), Directions.N);
            firstRover.Process("LMLMLMLMM");

            //Second Rover
            var secondPlateau = new Plateau(new Position(5, 5));
            var secondRover = new RoverService(secondPlateau, new Position(3, 3), Directions.E);
            secondRover.Process("MMRMMRMRRM");

            Print(firstRover, secondRover);

            Console.ReadKey();
        }

        static void Print(RoverService firstRover, RoverService secondRover)
        {
            var builder = new StringBuilder();
            builder.AppendLine($"{"Plateau max X and Y",25}  {"Starting coordinates",25}  {"Directions",25} {"Expected Result",25}");
            builder.AppendLine($"{"5,5",25} {"1 2 N",25} {"LMLMLMLMM",25} {firstRover.Print(),25} \t");
            builder.AppendLine($"{"5,5",25} {"3 3 E",25} {"MMRMMRMRRM",25} {secondRover.Print(),25} \t");
            Console.WriteLine(builder.ToString());
        }

        #region exception handler

        static void SetGlobalExceptionHandler()
        {
            AppDomain.CurrentDomain.UnhandledException += UnhandledExceptionTrapper;
        }

        static void UnhandledExceptionTrapper(object sender, UnhandledExceptionEventArgs e)
        {
            Console.WriteLine(e.ExceptionObject.ToString());
            Console.WriteLine("Press Enter to Exit");
            Console.ReadLine();
            Environment.Exit(0);
        }

        #endregion
    }
}