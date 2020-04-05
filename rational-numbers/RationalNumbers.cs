using System;
using System.Diagnostics;
using System.Linq;
using System.Collections.Generic;

public static class RealNumberExtension
{
    public static double Expreal(this int realNumber, RationalNumber r) =>
        r.Expreal(realNumber);
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
        var gcd = GreatestCommonFactor(numerator, denominator);
        if (numerator == 0) denominator = 1;
        this.numerator = numerator / gcd;
        this.denominator = denominator / gcd;
    }
    
    public static RationalNumber operator +(RationalNumber r1, RationalNumber r2) =>
        new RationalNumber(
            r1.numerator * r2.denominator + r2.numerator * r1.denominator,
            r1.denominator * r2.denominator);

    public static RationalNumber operator -(RationalNumber r1, RationalNumber r2) =>
        new RationalNumber(
            r1.numerator * r2.denominator - r2.numerator * r1.denominator,
            r1.denominator * r2.denominator);

    public static RationalNumber operator *(RationalNumber r1, RationalNumber r2) =>
        new RationalNumber(
            r1.numerator * r2.numerator,
            r1.denominator * r2.denominator);

    public static RationalNumber operator /(RationalNumber r1, RationalNumber r2) =>
        new RationalNumber(
            r1.numerator * r2.denominator,
            r2.numerator * r1.denominator);

    public RationalNumber Abs() =>
        new RationalNumber(
            Math.Abs(numerator),
            Math.Abs(denominator));

    public RationalNumber Reduce() => this;

    private static int GreatestCommonFactor(int num, int den)
    {
        int n = Math.Abs(num);
        var numeratorFactors = Factors(n);

        int d = Math.Abs(den);
        var denominatorFactors = Enumerable
            .Range(2, d)
            .Where(x => d % x == 0).ToList();

        var factor = numeratorFactors
            .FirstOrDefault(x => denominatorFactors.Contains(x));

        if (factor == 0) factor = 1;
        return factor;
    }

    private static List<int> Factors(int number) {
        return Enumerable.Range(2, number).Where(x => number % x == 0).ToList();
    }

    public RationalNumber Exprational(int power) =>
        new RationalNumber(
            (int)Math.Pow((double)numerator, Math.Abs(power)),
            (int)Math.Pow((double)denominator, Math.Abs(power)));

    public double Expreal(int baseNumber) =>
        Math.Pow(Math.Pow(baseNumber, 1.0 / denominator), numerator);
}