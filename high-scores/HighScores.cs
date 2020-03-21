using System.Collections.Generic;
using System.Linq;

public class HighScores
{
    private List<int> scores;
    public HighScores(List<int> list) => scores = list;

    public List<int> Scores() => scores;

    public int Latest() => scores.Last();

    public int PersonalBest() => scores.DefaultIfEmpty().Max();

    public List<int> PersonalTopThree() => scores
        .OrderByDescending(x => x)
        .Take(3)
        .ToList();
}