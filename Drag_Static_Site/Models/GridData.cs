namespace Drag_Static_Site.Models;

public class GridData
{
    public GridItem       Header    { get; set; } = new();
    public List<GridItem> GridItems { get; set; } = new();
}