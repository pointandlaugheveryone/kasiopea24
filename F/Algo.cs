class Algo {
    public static long TernarySearch(long days, long logs, long cost, long limit) { // better for non-uniform functions
        long left = 0;  // minimum log days
        long right = days;  // maximum log days
        long maxHouses = 0;

        while (left <= right) {
            long mid1 = left + (right - left) / 3;
            long mid2 = right - (right - left) / 3;

            long houses1 = CalculateHouses(days, logs, cost, limit, mid1);
            long houses2 = CalculateHouses(days, logs, cost, limit, mid2);
            maxHouses = Math.Max(maxHouses, Math.Max(houses1, houses2));

            if (houses1 < houses2) { left = mid1 + 1; } 

            else { right = mid2 - 1; }
        }

        return maxHouses;
    }

    public static long CalculateHouses(long days, long logs, long cost, long limit, long logDays) {
        if (logDays > days) return 0;  // not enough days to build
        long buildDays = days - logDays;
        long totalLogs = logs * (days * logDays - logDays * (logDays + 1) / 2);

        long maxHousesByLogs = totalLogs / cost;
        long maxHousesByDays = buildDays * limit;

        return Math.Min(maxHousesByLogs, maxHousesByDays);
    }
}