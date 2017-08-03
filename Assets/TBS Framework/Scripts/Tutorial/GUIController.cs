using UnityEngine;
using System.Collections.Generic;

public class GUIController : MonoBehaviour
{
    public CellGrid CellGrid;
    public Unit unit;

    public EventStart eventStart;

    public List<Cell> Path = new List<Cell>();
    public int PathLocation = 0;

    void Start()
    {
        Debug.Log("Game started!");
    }

	void Update ()
    {
        if(Input.GetKeyDown(KeyCode.N))
        {
            CellGrid.EndTurn(); //User ends his turn by pressing "n" on keyboard.
        }

        if (Input.GetMouseButtonDown(0))
        {
            int diceRoll = Random.Range(1, 7);
            Debug.Log("diceRoll: " + diceRoll);
            
            int NewLocation = PathLocation + diceRoll;
            if (NewLocation > 23)
            {
                NewLocation = NewLocation % 24;
            }
            Debug.Log("PathLocation updated to: " + NewLocation);

            List<Cell> p;
            if (NewLocation < PathLocation)
            {
                List<Cell> tail = Path.GetRange(PathLocation, 24 - PathLocation);
                List<Cell> head = Path.GetRange(0, NewLocation + 1);
                tail.Reverse();
                head.Reverse();
                head.AddRange(tail);
                p = head;
            } else
            {
                p = Path.GetRange(PathLocation, diceRoll + 1);
                p.Reverse();
            }
            Debug.Log("movement path p at Count: " + p.Count);
            
            Cell destinationCell = Path[NewLocation];

            unit.Move(destinationCell, p);

            PathLocation = NewLocation;

            //calls create event with the destination cell
            eventStart.createEvent(PathLocation);
        }

        if (Input.GetKeyDown(KeyCode.G))
        {
            for (int col = 1; col < 8; col++)
            {
                int[] coord = new int[2] { 2, col };
                Cell targetCell = CellGrid.Cells[CoordToIndex(coord, 10)].GetComponent<Cell>();
                Path.Add(targetCell);
            }
            for (int row = 3; row < 8; row++)
            {
                int[] coord = new int[2] { row, 7 };
                Cell targetCell = CellGrid.Cells[CoordToIndex(coord, 10)].GetComponent<Cell>();
                Path.Add(targetCell);
            }
            for (int col = 7; col >= 1; col--)
            {
                int[] coord = new int[2] { 8, col };
                Cell targetCell = CellGrid.Cells[CoordToIndex(coord, 10)].GetComponent<Cell>();
                Path.Add(targetCell);
            }
            for (int row = 7; row >= 3; row--)
            {
                int[] coord = new int[2] { row, 1 };
                Cell targetCell = CellGrid.Cells[CoordToIndex(coord, 10)].GetComponent<Cell>();
                Path.Add(targetCell);
            }
            
            Debug.Log("Path generated at Count: " + Path.Count);

            Cell startCell = Path[PathLocation];
            List<Cell> pp = new List<Cell>();
            pp.Add(startCell);
            unit.Move(startCell, pp);
            Debug.Log("Player starting at PathLocation: " + PathLocation);
        }



    }

    public int[] IndexToCoord(int index, int width, int height)
    {
        int row = index / width;
        int col = index % height;

        return new int[ 2 ] { row, col };
    }

    public int CoordToIndex(int[] coord, int width)
    {
        return coord[0] * width + coord[1];
    }

    public void GeneratePath()
    {
        for (int col = 1; col < 8; col++)
        {
            int[] coord = new int[2] { 2, col };
            Cell targetCell = CellGrid.Cells[CoordToIndex(coord, 10)].GetComponent<Cell>();
            Path.Add(targetCell);
        }
        for (int row = 3; row < 8; row++)
        {
            int[] coord = new int[2] { row, 7 };
            Cell targetCell = CellGrid.Cells[CoordToIndex(coord, 10)].GetComponent<Cell>();
            Path.Add(targetCell);
        }
        for (int col = 1; col < 8; col++)
        {
            int[] coord = new int[2] { 8, col };
            Cell targetCell = CellGrid.Cells[CoordToIndex(coord, 10)].GetComponent<Cell>();
            Path.Add(targetCell);
        }
        for (int row = 3; row < 8; row++)
        {
            int[] coord = new int[2] { row, 1 };
            Cell targetCell = CellGrid.Cells[CoordToIndex(coord, 10)].GetComponent<Cell>();
            Path.Add(targetCell);
        }
    }
}
