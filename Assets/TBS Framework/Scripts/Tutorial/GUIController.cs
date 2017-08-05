using UnityEngine;
using System.Collections.Generic;

public class GUIController : MonoBehaviour
{
    public CellGrid CellGrid;
	public Transform UnitsParent;

    public Unit unit;
	public Unit unit1;

	int curPlayer = 0;
	int numPlayers = 4;

	public Unit curUnit;

    public EventStart eventStart;

	public List<Unit> units = new List<Unit>();
    public List<Cell> Path = new List<Cell>();


    void Start()
    {
		
    }

	void Update ()
    {

		if (Input.GetKeyDown(KeyCode.D))
        {
			Move ();
        }

    }

	public void Move(){
		int diceRoll = Random.Range(1, 7);
		Debug.Log("diceRoll: " + diceRoll);

		int NewLocation = curUnit.PathLocation + diceRoll;
		if (NewLocation > 23)
		{
			NewLocation = NewLocation % 24;
		}

		List<Cell> p;
		if (NewLocation < curUnit.PathLocation)
		{
			List<Cell> tail = Path.GetRange(curUnit.PathLocation, 24 - curUnit.PathLocation);
			List<Cell> head = Path.GetRange(0, NewLocation + 1);
			tail.Reverse();
			head.Reverse();
			head.AddRange(tail);
			p = head;
		} else
		{
			p = Path.GetRange(curUnit.PathLocation, diceRoll + 1);
			p.Reverse();
		}

		Cell destinationCell = Path[NewLocation];

		curUnit.Move(destinationCell, p);

		curUnit.PathLocation = NewLocation;

		//calls create event with the destination cell
		eventStart.createEvent(curUnit.PathLocation);
	}


	public void startTurn(){

		Cell startCell = Path[curUnit.PathLocation];
		List<Cell> pp = new List<Cell>();
		pp.Add(startCell);
		curUnit.Move(startCell, pp);
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
	
	public void endTurn()
	{
		curPlayer = curPlayer + 1;
		if (curPlayer >= numPlayers - 1) {
			curPlayer = curPlayer % numPlayers;
		} 
		Debug.Log ("New Player is " + curPlayer);
		curUnit = units [curPlayer];
		Debug.Log ("New Unit is" + curUnit);
	}

    public void startGame()
    {
        generatePath();
        for (int i = 0; i < UnitsParent.childCount; i++)
        {
            var child = UnitsParent.GetChild(i).GetComponent<Unit>();
            units.Add(child);
            curUnit = units[i];
            int randomIndex = Random.Range(0, 5);
            Cell startCell = Path[randomIndex];
            List<Cell> pp = new List<Cell>();
            pp.Add(startCell);
            curUnit.Move(startCell, pp);
            curUnit.PathLocation = randomIndex;
        }
        Debug.Log("Game started!");
    }


    public void generatePath()
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
    }
}
