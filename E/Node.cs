class City {
    public int ID { get; }
    public int teamID { get; }
    public List<City> neighbors { get; }
    public City? Parent { get; set; }

    public City(int ID, int teamID) {
        this.ID = ID;
        this.teamID = teamID;
        neighbors = new List<City>();
        Parent = null;
    }

    public void AddNeighbors(City neighbor) {
        neighbors.Add(neighbor);
        neighbor.neighbors.Add(this);
    }
}