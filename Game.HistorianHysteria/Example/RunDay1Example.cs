namespace Game.HistorianHysteria.Example;

using Game.HistorianHysteria.Common;

public static class RunDay1Example
{
    public static void HistorianHysteria()
    {
        (List<long> left, List<long> right) = Console.In.ReadList();

        left.Sort();
        right.Sort();

        long sum = 0;

        for (int i = 0; i < left.Count; i++)
        {
            sum += Math.Abs(left[i] - right[i]);
        }

        Console.WriteLine($"Distance: {sum}");
    }

    public static void HistorianHysteriaByLinq()
    {
        (List<long> left, List<long> right) = Console.In.ReadList();

        long total = left
            .Order()
            .Zip(right.Order(), (l, r) => Math.Abs(l - r))
            .Sum();

        Console.WriteLine($"Distance: {total}");
    }

    public static void CalculateSimilarityScore()
    {
        (List<long> left, List<long> right) = Console.In.ReadList();
        Dictionary<long, long> numberCountMap = [];
        long similarityScore = 0;

        foreach (var number in right)
        {
            if (numberCountMap.ContainsKey(number))
            {
                numberCountMap[number]++;
            }
            else
            {
                numberCountMap[number] = 1;
            }
        }

        foreach (var number in left)
        {
            if (numberCountMap.ContainsKey(number))
            {
                similarityScore += number * numberCountMap[number];
            }
        }

        Console.WriteLine($"Similarity Score: {similarityScore}");
    }

    public static void CalculateSimilarityScoreByLinq()
    {
        (List<long> left, List<long> right) = Console.In.ReadList();

        long similarityScore = left.Join(right, l => l, r => r, (l, r) => r).Sum();

        Console.WriteLine($"Similarity Score: {similarityScore}");
    }
}