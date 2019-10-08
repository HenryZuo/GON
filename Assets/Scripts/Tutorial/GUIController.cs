using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;

public class GUIController : MonoBehaviour
{
    private GameObject CellGridObj;
    private GameObject CanvasObj;
    private GameObject UnitsParentObj;
    private GameObject DiceTextObj;

    private Data Data;
    private CellGrid CellGrid;
    private EventStart eventStart;
    private Canvas canvas;

    private Transform UnitsParent;
    private Text DiceText;

    private DisplayManager displayManager;

    //curPlayerMarkers
    private GameObject playerUIArrows;
    List<Transform> playerMarkers = new List<Transform>();

    int curPlayer = 0;
    int numPlayers = 4;

    private Unit curUnit;

    private List<Unit> units = new List<Unit>();
    private List<Cell> Path = new List<Cell>();

    //int to store number of ais, should be populated at menu screen
    private int num_ais = 2;

    private Boolean initialized = false;
    private int diceRoll;

    public Material StarkBlue;
    public Material LannisterRed;
    public Material TargayrenRed;
    public Material TyrellGreen;
    public Material NoOneWhite;

    private Transform flags;
    private List<GameObject> flag_list = new List<GameObject>();

    public void Start()
    {
        playerUIArrows = GameObject.Find("Player UI Arrows");
        playerMarkers.Add(playerUIArrows.transform.GetChild(0).GetChild(0).GetChild(0));
        playerMarkers.Add(playerUIArrows.transform.GetChild(1).GetChild(0).GetChild(0));
        playerMarkers.Add(playerUIArrows.transform.GetChild(2).GetChild(0).GetChild(0));
        playerMarkers.Add(playerUIArrows.transform.GetChild(3).GetChild(0).GetChild(0));

        UnitsParentObj = GameObject.Find("Units Parent");
        //UnitsParent = UnitsParentObj.transform;

        CellGridObj = GameObject.Find("CellGrid");
        CellGrid = CellGridObj.GetComponent<CellGrid>();

        CanvasObj = GameObject.Find("Canvas");
        canvas = CanvasObj.GetComponent<Canvas>();

        DiceTextObj = GameObject.Find("Dice Text");
        DiceText = DiceTextObj.GetComponent<Text>();

        eventStart = gameObject.GetComponent<EventStart>();
        Data = gameObject.GetComponent<Data>();

        displayManager = DisplayManager.Instance();

        if (initialized)
        {
            resumeGame();
        }
        else
        {
            startGame();
            //populate ai fields
            for (var i = 3; i >= 4 - num_ais; i--)
            {
                units[i].setAi();
            }
            if (units[0].isAi())
            {
                handleAiMove();
            }
        }

        //initialize flags
        flags = GameObject.Find("Flags").transform;
        //change flag colors
        updateFlags();
    }

    private void updateFlags()
    {
        for (var i = 0; i < flags.childCount; i++)
        {
            string castle_name = flags.GetChild(i).name;
            string house = Data.getCastleHouse(castle_name);
            switch (house)
            {
                case "Stark":
                    flags.GetChild(i).Find("BannerD_Cloth").GetComponent<Renderer>().material = StarkBlue;
                    break;
                case "Lannister":
                    flags.GetChild(i).Find("BannerD_Cloth").GetComponent<Renderer>().material = LannisterRed;
                    break;
                case "Targaryen":
                    flags.GetChild(i).Find("BannerD_Cloth").GetComponent<Renderer>().material = TargayrenRed;
                    break;
                case "Tyrell":
                    flags.GetChild(i).Find("BannerD_Cloth").GetComponent<Renderer>().material = TyrellGreen;
                    break;
                default:
                    flags.GetChild(i).Find("BannerD_Cloth").GetComponent<Renderer>().material = NoOneWhite;
                    break;
            }
        }
    }


    public void Move()
    {
        
        if (curUnit.PathLocation <= 2)
        {
            diceRoll = 2; 
        }
        else
        {
            diceRoll = UnityEngine.Random.Range(2, 12);
        }
        
        displayManager.DisplayDiceRoll("Dice rolled to " + diceRoll.ToString());

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

    public void EndTurn()
    {
        updatePlayerUI();
        curPlayer = curPlayer + 1;
        if (curPlayer >= numPlayers)
        {
            curPlayer = curPlayer % numPlayers;
        }
        curUnit = units[curPlayer];


        for (var i = 0; i < playerMarkers.Count; i++)
        {
            if (i == curPlayer)
            {
                playerMarkers[i].gameObject.SetActive(true);
            }
            else
            {
                playerMarkers[i].gameObject.SetActive(false);
            }
        }

        //handle ai moves
        if (curUnit.isAi())
        {
            handleAiMove();
        }

        updateFlags();
    }

    private void handleAiMove()
    {
        StartCoroutine(waitMove());
        Invoke("EndTurn", 3f);
    }

    private IEnumerator waitMove()
    {
        yield return new WaitForSeconds(1.5f);
        Move();
        StartCoroutine(waitProcessData());
        yield return null;
    }

    private IEnumerator waitProcessData()
    {
        yield return new WaitForSeconds(diceRoll * 0.1f + 1f);
        string event_type = Data.getEvent(curUnit.PathLocation)["type"];
        switch (event_type)
        {
            default:
                //			StartCoroutine (waitEndTurn ());
                yield return null;
                break;
        }
    }

    private IEnumerator waitEndTurn()
    {
        yield return null;
        EndTurn();
    }


    public void startGame()
    {
        Data.initializeData();
        Path = CellGrid.generatePath();
        DiceText.text = "";
        UnitsParent = UnitsParentObj.transform;
        for (int i = 0; i < UnitsParent.childCount; i++)
        {
            var child = UnitsParent.GetChild(i).GetComponent<Unit>();
            units.Add(child);
            curUnit = units[i];
            //int randomIndex = UnityEngine.Random.Range(0, 5);
            int randomIndex = i;
            Cell startCell = Path[randomIndex];
            List<Cell> pp = new List<Cell>();
            pp.Add(startCell);
            curUnit.Move(startCell, pp);
            curUnit.PathLocation = randomIndex;
        }
        curUnit = units[0];
        updatePlayerUI();
        initialized = true;
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
        return curUnit;
    }

    public int getPlayerNum()
    {
        return curPlayer;
    }

    public int getDiceRoll()
    {
        return diceRoll;
    }

}
