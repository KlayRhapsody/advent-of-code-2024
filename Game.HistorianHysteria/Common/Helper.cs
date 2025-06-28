namespace Game.HistorianHysteria.Common;

using System.Text.RegularExpressions;

public static class Helper
{
    public static List<long> ParseInts(this string input)
    {
        return Regex.Matches(input, @"-?\d+")
            .Select(x => long.Parse(x.Value))
            .ToList();
    }

    public static (List<long> left, List<long> right) ReadList(this TextReader text)
    {
        (List<long> left, List<long> right) = ([], []);

        string? line;
        while (!string.IsNullOrWhiteSpace(line = text.ReadLine()))
        {
            List<long> lineNum = line.ParseInts();

            if (lineNum.Count == 2)
            {
                left.Add(lineNum[0]);
                right.Add(lineNum[1]);
            }
        }

        return (left, right);
    }

    public static List<List<long>> ReadMultiList(this TextReader text)
    {
        List<List<long>> levels = [];

        string? line;
        while (!string.IsNullOrWhiteSpace(line = text.ReadLine()))
        {
            List<long> lineNums = line.ParseInts();

            levels.Add(lineNums);
        }

        return levels;
    }
}