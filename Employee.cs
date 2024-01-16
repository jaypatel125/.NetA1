//Jay Patel, 000881881 certify that this material is my original work.  No other person's work has been used without due acknowledgement.
//Date: 16/09/2023
//Assignment: 1

using System;
using Assignment_1;
using System.Collections;

namespace Assignment_1
{
    // Define the Employee class
    public class Employee
	{
        // Private fields to store employee information
        private string name;
        private int number;
        private decimal rate;
        private double hours;
        private decimal gross;

        // Constructor to initialize an Employee object
        public Employee(string name, int number, decimal rate, double hours)
		{
            this.name = name;
            this.number = number;
            this.rate = rate;
            this.hours = hours;
        }

        // Method to calculate the gross pay based on hours worked and hourly rate
        public void CalculateGross(double hours, decimal rate)
        {
            decimal regularPay;
            decimal overtimePay;
            double overtimeHours;

            if (hours <= 40)
            {
                gross = (decimal)hours * rate;
            }

            else {
                regularPay = 40 * rate;
                overtimeHours = hours - 40;
                overtimePay = (decimal)overtimeHours * (rate * 1.5m);
                gross = regularPay + overtimePay;
            }
            
        }

        // Method to get the gross pay
        public decimal GetGross()
        {
            CalculateGross(hours, rate);
            return this.gross;
        }

        // Method to get the hours worked
        public double GetHours()
        {
            return this.hours;
        }

        // Method to get the employee name
        public string GetName()
        {
            return this.name;
        }

        // Method to get the employee number
        public int GetNumber()
        {
            return this.number;
        }

        // Method to get the hourly rate
        public decimal GetRate()
        {
            return this.rate;
        }

        // Override the ToString method to provide a formatted string
        public override string ToString()
        {
            return $"{name} {number} {rate} {hours} {gross}";
        }

        // Method to set hours worked
        public void SetHours(double hours) {
            this.hours = hours;
        }

        // Method to set the employee name
        public void SetName(string name)
        {
            this.name = name;
        }

        // Method to get the employee number
        public void SetNumber(int number)
        {
            this.number = number;
        }

        // Method to get the hourly rate
        public void SetRate(decimal rate)
        {
            this.rate = rate;
        }
	}
}


