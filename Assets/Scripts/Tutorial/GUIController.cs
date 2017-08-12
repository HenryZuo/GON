using UnityEngine;
using System.Collections.Generic;
using System;
using UnityEngine.UI;

public class GUIController : MonoBehaviour
{
    public CellGrid CellGrid;
	public Transform UnitsParent;
    public Data Data;
    public Text DiceText;
    private DisplayManager displayManager;


    int curPlayer = 0;
	int numPlayers = 4;

	public Unit curUnit;

    public EventStart eventStart;

	public List<Unit> units = new List<Unit>();
    public List<Cell> Path = new List<Cell>();

    void Start()
    {
        startGame();
        displayManager = DisplayManager.Instance();
        DiceText.text = "";
    }

	void Update ()
    {

    }

	public void Move(){
		int diceRoll = UnityEngine.Random.Range(1, 7);
        displayManager.DisplayDiceRoll("You rolled a " + diceRoll.ToString());
        // DiceText.text = diceRoll.ToString();

        int NewLocation = curUnit.PathLocation + diceRoll;
		if (NewLocation > 117)
		{
			NewLocation = NewLocation % 118;
		}

		List<Cell> p;
		if (NewLocation < curUnit.PathLocation)
		{
			List<Cell> tail = Path.GetRange(curUnit.PathLocation, 118 - curUnit.PathLocation);
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
        updatePlayerUI();
        curPlayer = curPlayer + 1;
		if (curPlayer >= numPlayers - 1) {
			curPlayer = curPlayer % numPlayers;
		}
		curUnit = units [curPlayer];
	}

    public void startGame()
    {
        Data.initializeData();
        Path = CellGrid.generatePath();
        for (int i = 0; i < UnitsParent.childCount; i++)
        {
            var child = UnitsParent.GetChild(i).GetComponent<Unit>();
            units.Add(child);
            curUnit = units[i];
            int randomIndex = UnityEngine.Random.Range(0, 5);
            Cell startCell = Path[randomIndex];
            List<Cell> pp = new List<Cell>();
            pp.Add(startCell);
            curUnit.Move(startCell, pp);
            curUnit.PathLocation = randomIndex;
        }
        updatePlayerUI();
    }

    public void updatePlayerUI()
    {
        Transform playerUI = transform.Find("Canvas").Find("Player UI");
        for (int i = 0; i < playerUI.childCount - 1; i++)
        {
            Transform stats = playerUI.GetChild(i).Find("Stats");
            for (int j = 0; j < stats.childCount; j++)
            {
                string newVal;
                switch (j)
                {                    
                    case 0:
                        newVal = Data.getPlayerAttribute(i, "wealth");
                        stats.GetChild(j).GetChild(1).GetComponent<Text>().text = newVal;
                        break;
                    case 1:
                        newVal = Data.getPlayerAttribute(i, "soldiers");
                        stats.GetChild(j).GetChild(1).GetComponent<Text>().text = newVal;
                        break;
                    case 2:
                        newVal = Data.getPlayerAttribute(i, "generals").Split(',').Length.ToString();
                        stats.GetChild(j).GetChild(1).GetComponent<Text>().text = newVal;
                        break;
                    case 3:
                        newVal = Data.getPlayerAttribute(i, "castle").Split(',').Length.ToString();
                        stats.GetChild(j).GetChild(1).GetComponent<Text>().text = newVal;
                        break;
                    default:
                        Debug.Log("updatePlayerUI() is at default case");
                        break;
                }
            }
        }
    }
    
}
