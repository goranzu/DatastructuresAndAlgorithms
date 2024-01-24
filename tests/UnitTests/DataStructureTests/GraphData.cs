namespace UnitTests.DataStructureTests;

public class GraphData
{
    public List<List<int>> lijnlijst { get; set; }
    public List<List<int>> verbindingslijst { get; set; }
    public List<List<int>> verbindingsmatrix { get; set; }
    public List<List<double>> lijnlijst_gewogen { get; set; }
    public List<List<List<double>>> verbindingslijst_gewogen { get; set; }
    public List<List<double>> verbindingsmatrix_gewogen { get; set; }
}