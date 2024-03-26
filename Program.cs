using System;

namespace CircleApplication
{
    class Circle
    {

        public double Radius { get; set; }

        // Center coordinates of the circle
        public double X { get; set; }
        public double Y { get; set; }

        public Circle(double radius, double x, double y)
        {
            Radius = radius;
            X = x;
            Y = y;
        }

        // Method to calculate the area of the circle
        public double CalculateArea()
        {
            return Math.PI * Radius * Radius;
        }

        // Method to calculate the perimeter of the circle
        public double CalculatePerimeter()
        {
            return 2 * Math.PI * Radius;
        }

        // Method to check if the given point lies within the circle
        public bool ContainsPoint(double pointX, double pointY)
        {
            double distance = Math.Sqrt((pointX - X) * (pointX - X) + (pointY - Y) * (pointY - Y));
            return distance <= Radius;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {

            Console.Write("Enter the number of circles you want to create: ");
            int numberOfCircles = int.Parse(Console.ReadLine());

            // Create an array of circles with the specified number of elements
            Circle[] circles = new Circle[numberOfCircles];

            // Loop through each circle and prompt the user to input its details
            for (int i = 0; i < numberOfCircles; i++)
            {
                Console.WriteLine($"Enter details for circle {i + 1}:");
                Console.Write("Radius: ");
                double radius = double.Parse(Console.ReadLine());
                Console.Write("X coordinate of center: ");
                double x = double.Parse(Console.ReadLine());
                Console.Write("Y coordinate of center: ");
                double y = double.Parse(Console.ReadLine());

                // Create a new circle object with the given details
                circles[i] = new Circle(radius, x, y);
            }

            // Print the information of each circle, including its area and perimeter
            PrintCirclesInfo(circles);


            Console.WriteLine("Enter a point to check (X Y): ");
            string[] point = Console.ReadLine().Split(' ');
            double pointX = double.Parse(point[0]);
            double pointY = double.Parse(point[1]);

            // Check if the point lies within any of the circles and print the result
            CheckPointInCircles(circles, pointX, pointY);
        }

        // Method to print the information of each circle, including its area and perimeter
        static void PrintCirclesInfo(Circle[] circles)
        {
            for (int i = 0; i < circles.Length; i++)
            {
                Console.WriteLine($"Circle {i + 1}: Area = {circles[i].CalculateArea()}, Perimeter = {circles[i].CalculatePerimeter()}");
            }
        }

        // Method to check if the given point lies within any of the circles and print the result
        static void CheckPointInCircles(Circle[] circles, double pointX, double pointY)
        {
            for (int i = 0; i < circles.Length; i++)
            {
                if (circles[i].ContainsPoint(pointX, pointY))
                {
                    Console.WriteLine($"Point ({pointX}, {pointY}) is inside circle {i + 1}");
                }
                else
                {
                    Console.WriteLine($"Point ({pointX}, {pointY}) is not inside circle {i + 1}");
                }
            }
        }
    }
}