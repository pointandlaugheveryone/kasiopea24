class DFS
{
    public static void GetParents(City current, City? parent) {
        current.Parent = parent;
        
        foreach (var neighbor in current.neighbors) {
            if (neighbor != parent) { 
                GetParents(neighbor, current);  // recursively assign parents to neighbors
            }
        }
    }

    public static void GetDistance(City current, int depth, Dictionary<int, int> teamAncestors, long[] ans) {
        int distance;

        if (teamAncestors.TryGetValue(current.teamID, out int ancestorDepth)) {
            distance = depth - ancestorDepth;  // distance to nearest team node
        } 
        else { distance = depth; }  // Distance to root for nodes with no team

        // exclude root and parent
        if (current.ID != current.Parent?.ID && current.ID != ans.Length - 1) {
            ans[current.ID] = distance;
        }

        int? previousDepth = null;
        if (current.teamID != 0) { // Exclude. root.
            if (teamAncestors.ContainsKey(current.teamID)) {  // if theres an ancestor, store its depth
                previousDepth = teamAncestors[current.teamID];
            }

            teamAncestors[current.teamID] = depth;
        }

        foreach (var neighbor in current.neighbors) {
            if (neighbor != current.Parent) {
                GetDistance(neighbor, depth + 1, teamAncestors, ans);
            }
        }

        if (current.teamID != 0) {
            if (previousDepth.HasValue) {
                teamAncestors[current.teamID] = previousDepth.Value;
            } 
            else {
                teamAncestors.Remove(current.teamID);
            }
        }
    }
}