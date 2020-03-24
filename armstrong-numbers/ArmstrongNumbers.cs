using System;

public static class ArmstrongNumbers
{
    public static bool IsArmstrongNumber(int number) =>
        ArmstrongSum(number) == number;


    private static int ArmstrongSum(int number) {
        int numberOfDigits = number.ToString().Length;
        double sum = 0;
        while ( number > 0) {
            int digit = number % 10;
            sum += Math.Pow(digit, numberOfDigits);
            number /= 10;
        }
        return (int)sum;
    }
}