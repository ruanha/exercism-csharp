using System;
using System.Diagnostics;
using System.Linq;
using System.Collections.Generic;

public static class RealNumberExtension
{
    public static double Expreal(this int realNumber, RationalNumber r)
    {
        throw new NotImplementedException("You need to implement this extension method.");
    }
}

public struct RationalNumber
{
    private int numerator;
    private int denominator;
    public RationalNumber(int numerator, int denominator)
    {
        this.numerator = numerator;
        this.denominator = denominator;
    }
    
    /*
    The sum of two rational numbers r1 = a1/b1 and r2 = a2/b2 is
    r1 + r2 = a1/b1 + a2/b2 = (a1 * b2 + a2 * b1) / (b1 * b2).
    */
    public static RationalNumber operator +(RationalNumber r1, RationalNumber r2)
    {
        /*
        The sum of two rational numbers r1 = a1/b1 and r2 = a2/b2 is
         r1 + r2 = a1/b1 + a2/b2 = (a1 * b2 + a2 * b1) / (b1 * b2).
         */
        return new RationalNumber(
            r1.numerator * r2.denominator + r2.numerator * r1.denominator,
            r1.denominator * r2.denominator).Reduce();
    }

    public static RationalNumber operator -(RationalNumber r1, RationalNumber r2)
    {
        /*
        The difference of two rational numbers r1 = a1/b1 and r2 = a2/b2 is
        r1 - r2 = a1/b1 - a2/b2 = (a1 * b2 - a2 * b1) / (b1 * b2).
        */
        int n = r1.numerator * r2.denominator - r2.numerator * r1.denominator;
        int d = r1.denominator * r2.denominator;
        if (n == 0) return new RationalNumber(n, 1);
        if (d == 0) throw new ArgumentException();
        return new RationalNumber(n, d);
    }

    /**
    * The product (multiplication) of two rational numbers r1 = a1/b1 and r2 = a2/b2 is
    * r1 * r2 = (a1 * a2) / (b1 * b2).
    */
    public static RationalNumber operator *(RationalNumber r1, RationalNumber r2)
    {
        int n = r1.numerator * r2.numerator;
        int d = r1.denominator * r2.denominator;
        if (n == 0) return new RationalNumber(n, 1);
        if (d == 0) throw new ArgumentException();
        return new RationalNumber(n, d).Reduce();
    }

    public static RationalNumber operator /(RationalNumber r1, RationalNumber r2)
    {
        throw new NotImplementedException("You need to implement this operator.");
    }

    public RationalNumber Abs()
    {
        throw new NotImplementedException("You need to implement this function.");
    }

    public RationalNumber Reduce()
    {
        int n = Math.Abs(numerator);
        var numeratorFactors = Enumerable
            .Range(1, n)
            .Where(x => n % x == 0);

        int d = Math.Abs(denominator);
        var denominatorFactors = Enumerable
            .Range(2, d)
            .Where(x => d % n == 0);

        var factor = numeratorFactors
            .FirstOrDefault(x => denominatorFactors.Contains(x));
        numerator /= factor;
        denominator /= factor;
        return new RationalNumber(numerator, denominator);
    }

    public RationalNumber Exprational(int power)
    {
        throw new NotImplementedException("You need to implement this function.");
    }

    public double Expreal(int baseNumber)
    {
        throw new NotImplementedException("You need to implement this function.");
    }
}