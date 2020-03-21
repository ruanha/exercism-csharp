using System;
using System.Collections.Generic;

public class SpaceAge
{
    private int Seconds;
    private Int64 EarthSecondsPerOrbit = 31557600;

    public SpaceAge(int seconds)
    {
        Seconds = seconds;
    }

    public double OnEarth() =>
        (double) Seconds / EarthSecondsPerOrbit;

    public double OnMercury() =>
        CalcSpaceAgeOn(Planet.Mercury); 

    public double OnVenus() =>
        CalcSpaceAgeOn(Planet.Venus);

    public double OnMars() =>
        CalcSpaceAgeOn(Planet.Mars);

    public double OnJupiter() => 
        CalcSpaceAgeOn(Planet.Jupiter);

    public double OnSaturn() =>
        CalcSpaceAgeOn(Planet.Saturn);

    public double OnUranus() =>
        CalcSpaceAgeOn(Planet.Uranus);

    public double OnNeptune() =>
        CalcSpaceAgeOn(Planet.Neptune);

    private double CalcSpaceAgeOn(Planet planet) =>
        (double) Seconds / (OrbitalPeriod[planet] * EarthSecondsPerOrbit);

    private static Dictionary<Planet, double> OrbitalPeriod = new Dictionary <Planet, double> {
        {Planet.Mercury, 0.2408467},
        {Planet.Venus, 0.61519726},
        {Planet.Mars, 1.8808158},
        {Planet.Jupiter, 11.862615},
        {Planet.Saturn, 29.447498},
        {Planet.Uranus, 84.016846},
        {Planet.Neptune, 164.79132}
    };

    private enum Planet {
        Mercury,
        Venus,
        Earth,
        Mars,
        Jupiter,
        Saturn,
        Uranus,
        Neptune
    }
}