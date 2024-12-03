/*

keeping this here for future reference
-----------------------------------------

class Traverse {
    public static long IterativeDFS(City startNode, City? parent)
    {
        Stack<City> stack = new();
        startNode.IsVisited = true;
        stack.Push(startNode);

        while (stack.Count > 0) {    
            City node = stack.Pop();
            
            foreach (City neighbor in node.neighbors) {
                if (!neighbor.IsVisited) {
                    neighbor.IsVisited = true;
                    stack.Push(neighbor); 
                }
            }
        }

 // I am not sure what to return here
        return 0;
    }
}

*/