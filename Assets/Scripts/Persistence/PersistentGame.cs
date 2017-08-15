using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;

public class PersistentGame : MonoBehaviour
{
    private GameObject DataObj;
    private GameObject CellGridObj;
    private GameObject CanvasObj;
    private GameObject UnitsParentObj;

    private Data Data;
    private CellGrid CellGrid;
    private EventStart eventStart;
    private Canvas canvas;

    private Transform UnitsParent;
    public Text DiceText;

    private DisplayManager displayManager;

    int curPlayer = 0;
    int numPlayers = 4;

    private Unit curUnit;

    private List<Unit> units = new List<Unit>();
    private List<Cell> Path = new List<Cell>();

    private Boolean initialized = false;

    void Start()
    {
        
    }

    public void GUIStart()
    {
        UnitsParentObj = GameObject.Find("Units Parent");
        UnitsParent = UnitsParentObj.transform;

        DataObj = GameObject.Find("DataObj");
        Data = DataObj.GetComponent<Data>();

        CellGridObj = GameObject.Find("CellGrid");
        CellGrid = CellGridObj.GetComponent<CellGrid>();

        CanvasObj = GameObject.Find("Canvas");
        canvas = CanvasObj.GetComponent<Canvas>();

        eventStart = gameObject.GetComponent<EventStart>();

        displayManager = DisplayManager.Instance();

        if (initialized)
        {
            resumeGame();
        }
        else
        {
            startGame();
            initialized = true;
        }
    }
    

    public void GUIMove()
    {
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
        }
        else
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

        return new int[2] { row, col };
    }

    public int CoordToIndex(int[] coord, int width)
    {
        return coord[0] * width + coord[1];
    }

    public void GUIEndTurn()
    {
        updatePlayerUI();
        curPlayer = curPlayer + 1;
        if (curPlayer >= numPlayers)
        {
            curPlayer = curPlayer % numPlayers;
        }
        curUnit = units[curPlayer];
    }

    public void startGame()
    {
        Data.initializeData();
        Path = CellGrid.generatePath();
        DiceText.text = "";
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
        curUnit = units[0];
        updatePlayerUI();
    }

    public void resumeGame()
    {
        for (int i = 0; i < UnitsParent.childCount; i++)
        {
            var u = units[i];
            Cell toCell = Path[u.PathLocation];
            List<Cell> pp = new List<Cell>();
            pp.Add(toCell);
            u.Move(toCell, pp);
        }
        updatePlayerUI();
    }

    public void updatePlayerUI()
    {

        Transform playerUI = canvas.transform.Find("Player UI");
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

    public DisplayManager getDisplayManager()
    {
        return displayManager;
    }

    public Boolean getInit()
    {
        return initialized;
    }

    public void toggleInit()
    {
        initialized = !initialized;
    }

    public Unit getCurUnit()
    {
        if(curUnit == null)
        {
            UnitsParentObj = GameObject.Find("Units Parent");
            UnitsParent = UnitsParentObj.transform;
            curUnit = UnitsParent.GetChild(0).GetComponent<Unit>();
            return curUnit;
        } else
        {
            return curUnit;

        }
    }

    public int getPlayerNum()
    {
        return curPlayer;
    }

}
