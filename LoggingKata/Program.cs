﻿using System;
using System.Linq;
using System.IO;
using GeoCoordinatePortable;

namespace LoggingKata
{
    class Program
    {
        static readonly ILog logger = new TacoLogger();
        const string csvPath = "TacoBell-US-AL.csv";

        static void Main(string[] args)
        {
            // TODO:  Find the two Taco Bells that are the furthest from one another.
            // HINT:  You'll need two nested forloops ---------------------------

            logger.LogInfo("Log initialized");

            // use File.ReadAllLines(path) to grab all the lines from your csv file
            // Log and error if you get 0 lines and a warning if you get 1 line
            var lines = File.ReadAllLines(csvPath);

            logger.LogInfo($"Lines: {lines[0]}");

            // Create a new instance of your TacoParser class
            var parser = new TacoParser();

            // Grab an IEnumerable of locations using the Select command: var locations = lines.Select(parser.Parse);
            var locations = lines.Select(parser.Parse).ToArray();

            // DON'T FORGET TO LOG YOUR STEPS

            // Now that your Parse method is completed, START BELOW ----------

            // TODO: Create two `ITrackable` variables with initial values of `null`. These will be used to store your two taco bells that are the farthest from each other.

            ITrackable locA = null;
            ITrackable locB = null;
            GeoCoordinate pin1 = new GeoCoordinate();
            GeoCoordinate pin2 = new GeoCoordinate();

            // Create a `double` variable to store the distance

            double distance = 0.00;


            // Include the Geolocation toolbox, so you can compare locations: `using GeoCoordinatePortable' - was done.

            //HINT NESTED LOOPS SECTION---------------------
            // Do a loop for your locations to grab each location as the origin (perhaps: `locA`)
            // will be looking through locations
            // TO-DO: loop through locations array 
            
            double longestDistance = 0.00;

            // Create a new corA Coordinate with your locA's lat and long

            for (int i = 0; i < locations.Length; i++)
            {
                pin1.Latitude = locations[i].Location.Latitude;
                pin1.Longitude = locations[i].Location.Longitude;

                for (int j = 0; j < locations.Length; j++)
                {
                    
                    pin2.Latitude = locations[j].Location.Latitude;
                    pin2.Longitude = locations[j].Location.Longitude;

                    longestDistance = pin1.GetDistanceTo(pin2);
                    // Now, do another loop on the locations with the scope of your first loop, so you can grab the "destination" location (perhaps: `locB`)
                    // Create a new Coordinate with your locB's lat and long
                    // Now, compare the two using `.GetDistanceTo()`, which returns a double
                    // If the distance is greater than the currently saved distance, update the distance and the two `ITrackable` variables you set above

                    if (longestDistance > distance)
                    {
                        locA = locations[i];
                        locB = locations[j];
                        distance = longestDistance;

                    }
                }
            }
            // Once you've looped through everything, you've found the two Taco Bells farthest away from each other.
            
            Console.WriteLine($"\n\nLocation 1 Name: {locA.Name}");
            Console.WriteLine($"Location 2 Name: {locB.Name}");
            Console.WriteLine($"The distance between two Taco Bell locations farthest away from each other is {Math.Round(distance * 0.000621371)} miles.");

        }
    }
}
