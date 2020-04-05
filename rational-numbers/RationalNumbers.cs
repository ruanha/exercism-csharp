using System;
using System.Diagnostics;
using System.Linq;
using System.Collections.Generic;

public static class RealNumberExtension
{
    public static double Expreal(this int realNumber, RationalNumber r)
    {
        return r.Expreal(realNumber);
    }
}

public struct RationalNumber
{
    private int numerator;
    private int denominator;
    public RationalNumber(int numerator, int denominator)
    {
        if (denominator == 0)
            throw new ArgumentOutOfRangeException("denominator cannot be zero");
        if (denominator < 1) {
            numerator *= -1;
            denominator *= -1;
        }
        this.numerator = numerator;
        this.denominator = denominator;
    }
    
    public static RationalNumber operator +(RationalNumber r1, RationalNumber r2)
    {
        return new RationalNumber(
            r1.numerator * r2.denominator + r2.numerator * r1.denominator,
            r1.denominator * r2.denominator).Reduce();
    }

    public static RationalNumber operator -(RationalNumber r1, RationalNumber r2)
    {
        int n = r1.numerator * r2.denominator - r2.numerator * r1.denominator;
        int d = r1.denominator * r2.denominator;
        if (n == 0) return new RationalNumber(n, 1);
        if (d == 0) throw new ArgumentException();
        return new RationalNumber(n, d);
    }

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
        if (r2.numerator * r1.denominator == 0)
            throw new ArgumentException();
        return new RationalNumber(
            r1.numerator * r2.denominator, 
            r2.numerator * r1.denominator).Reduce();
    }

    public RationalNumber Abs()
    {
        return new RationalNumber(Math.Abs(numerator), Math.Abs(denominator));
    }

    public RationalNumber Reduce()
    {
        int n = Math.Abs(numerator);
        var numeratorFactors = Enumerable
            .Range(1, n)
            .Where(x => n % x == 0).ToList();

        int d = Math.Abs(denominator);
        var denominatorFactors = Enumerable
            .Range(2, d)
            .Where(x => d % x == 0).ToList();

        var factor = numeratorFactors
            .FirstOrDefault(x => denominatorFactors.Contains(x));

        if (factor == 0) factor = 1;
        if (numerator == 0) denominator = 1;
        numerator /= factor;
        denominator /= factor;
        return new RationalNumber(numerator, denominator);
    }

    public RationalNumber Exprational(int power)
    {
        return new RationalNumber(
            (int)Math.Pow((double)numerator, Math.Abs(power)),
            (int)Math.Pow((double)denominator, Math.Abs(power))
        ).Reduce();
    }

    public double Expreal(int baseNumber)
    {
        return Math.Pow(Math.Pow(baseNumber, 1.0 / denominator), numerator);
    }
}