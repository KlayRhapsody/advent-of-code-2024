using Game.HistorianHysteria.Common;

namespace Game.HistorianHysteria.Example;

public static class RunDay2Example
{
    public static void CheckRedNosedReports()
    {
        List<List<long>> levels = Console.In.ReadMultiList();

        int safeCount = 0;

        foreach (var level in levels)
        {
            if (level.Count < 1)
                continue;

            if (level.Count == 1)
            {
                safeCount++;
                continue;
            }

            bool direct = isIncreasing(level[0], level[1]);
            for (int i = 0; i < level.Count - 1; i++)
            {
                if (direct != isIncreasing(level[i], level[i + 1])
                    || !IsValidNext(level[i], level[i + 1]))
                {
                    break;
                }

                if (i == level.Count - 2)
                    safeCount++;
            }
        }

        Console.WriteLine($"Safe Levels Count: {safeCount}");
    }

    private static bool isIncreasing(long x, long y)
    {
        return x < y;
    }

    private static bool IsValidNext(long x, long y)
    {
        if (x == y) return false;

        if (Math.Abs(x - y) > 3) return false;

        return true;
    }

    public static void CheckRedNosedReportsByLinq()
    {
        List<List<long>> levels = Console.In.ReadMultiList();

        var safeCount = levels.Count(IsSafe);

        Console.WriteLine($"Safe Levels Count: {safeCount}");
    }

    private static bool IsSafe(this List<long> level)
    {
        return level.Count < 2 || level.IsSafe(Math.Sign(level[1] - level[0]));
    }

    private static bool IsSafe(this List<long> level, int diffSign)
    {
        return level.ToPairs().All(pair => pair.IsSafe(diffSign));
    }

    private static IEnumerable<(long prev, long next)> ToPairs(this List<long> level)
    {
        return level.Zip(level.Skip(1));
    }

    private static bool IsSafe(this (long prev, long next) pair, int diffSign)
    {
        return Math.Sign(pair.next - pair.prev) == diffSign &&
            Math.Abs(pair.next - pair.prev) >= 1 &&
            Math.Abs(pair.next - pair.prev) <= 3;
    }
}