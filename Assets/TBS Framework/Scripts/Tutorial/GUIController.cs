using UnityEngine;
using System.Collections.Generic;

public class GUIController : MonoBehaviour
{
    public CellGrid CellGrid;
	public Transform UnitsParent;

    public Unit unit;
	public Unit unit1;

	int curPlayer = 0;
	int numPlayers;

	public Unit curUnit;

    public EventStart eventStart;

	public List<Unit> units = new List<Unit>();



    void Start()
    {
		for (int i = 0; i < UnitsParent.childCount; i++) {
			var child = UnitsParent.GetChild (i).GetComponent<Unit> ();
			units.Add (child);
		}
		curUnit = units[curPlayer];
		foreach (Unit c in units) {
			Debug.Log (c);
		}
		numPlayers = units.Count;
		Debug.Log ("Current unit is " + units[0]);
        Debug.Log("Game started!");
		Debug.Log ("Press 'Start Your Turn', then Press D to move");
    }

	void Update ()
    {
        if(Input.GetKeyDown(KeyCode.N))
        {
            CellGrid.EndTurn(); //User ends his turn by pressing "n" on keyboard.
        }
		if (Input.GetKeyDown (KeyCode.E)) 
		{
			endTurn ();
		}

		if (Input.GetKeyDown(KeyCode.D))
        {
			Move ();
        }

        if (Input.GetKeyDown(KeyCode.G))
        {
			startTurn ();
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
		Debug.Log("PathLocation updated to: " + NewLocation);

		List<Cell> p;
		if (NewLocation < curUnit.PathLocation)
		{
			List<Cell> tail = curUnit.Path.GetRange(curUnit.PathLocation, 24 - curUnit.PathLocation);
			List<Cell> head = curUnit.Path.GetRange(0, NewLocation + 1);
			tail.Reverse();
			head.Reverse();
			head.AddRange(tail);
			p = head;
		} else
		{
			p = curUnit.Path.GetRange(curUnit.PathLocation, diceRoll + 1);
			p.Reverse();
		}
		Debug.Log("movement path p at Count: " + p.Count);

		Cell destinationCell = curUnit.Path[NewLocation];

		curUnit.Move(destinationCell, p);

		curUnit.PathLocation = NewLocation;

		//calls create event with the destination cell
		eventStart.createEvent(curUnit.PathLocation);
		Debug.Log ("Press the End Turn button on the bottom right when you're done with your turn");
	}

	public void startTurn(){
		for (int col = 1; col < 8; col++)
		{
			int[] coord = new int[2] { 2, col };
			Cell targetCell = CellGrid.Cells[CoordToIndex(coord, 10)].GetComponent<Cell>();
			curUnit.Path.Add(targetCell);
		}
		for (int row = 3; row < 8; row++)
		{
			int[] coord = new int[2] { row, 7 };
			Cell targetCell = CellGrid.Cells[CoordToIndex(coord, 10)].GetComponent<Cell>();
			curUnit.Path.Add(targetCell);
		}
		for (int col = 7; col >= 1; col--)
		{
			int[] coord = new int[2] { 8, col };
			Cell targetCell = CellGrid.Cells[CoordToIndex(coord, 10)].GetComponent<Cell>();
			curUnit.Path.Add(targetCell);
		}
		for (int row = 7; row >= 3; row--)
		{
			int[] coord = new int[2] { row, 1 };
			Cell targetCell = CellGrid.Cells[CoordToIndex(coord, 10)].GetComponent<Cell>();
			curUnit.Path.Add(targetCell);
		}

		Debug.Log("Path generated at Count: " + curUnit.Path.Count);

		Cell startCell = curUnit.Path[curUnit.PathLocation];
		List<Cell> pp = new List<Cell>();
		pp.Add(startCell);
		curUnit.Move(startCell, pp);
		Debug.Log("Player starting at PathLocation: " + curUnit.PathLocation);
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
		Debug.Log ("Turn has ended!");
		curPlayer = curPlayer + 1;
		if (curPlayer >= numPlayers - 1) {
			curPlayer = curPlayer % numPlayers;
		} 
		Debug.Log ("New Player is " + curPlayer);
		curUnit = units [curPlayer];
		Debug.Log ("New Unit is" + curUnit);
	}
//    public void GeneratePath()
//    {
//        for (int col = 1; col < 8; col++)
//        {
//            int[] coord = new int[2] { 2, col };
//            Cell targetCell = CellGrid.Cells[CoordToIndex(coord, 10)].GetComponent<Cell>();
//            Path.Add(targetCell);
//        }
//        for (int row = 3; row < 8; row++)
//        {
//            int[] coord = new int[2] { row, 7 };
//            Cell targetCell = CellGrid.Cells[CoordToIndex(coord, 10)].GetComponent<Cell>();
//            Path.Add(targetCell);
//        }
//        for (int col = 1; col < 8; col++)
//        {
//            int[] coord = new int[2] { 8, col };
//            Cell targetCell = CellGrid.Cells[CoordToIndex(coord, 10)].GetComponent<Cell>();
//            Path.Add(targetCell);
//        }
//        for (int row = 3; row < 8; row++)
//        {
//            int[] coord = new int[2] { row, 1 };
//            Cell targetCell = CellGrid.Cells[CoordToIndex(coord, 10)].GetComponent<Cell>();
//            Path.Add(targetCell);
//        }
//    }
}
