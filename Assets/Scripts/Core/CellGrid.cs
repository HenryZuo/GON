using UnityEngine;
using System.Collections.Generic;
using System.Linq;
using System;

/// <summary>
/// CellGrid class keeps track of the game, stores cells, units and players objects. It starts the game and makes turn transitions. 
/// It reacts to user interacting with units or cells, and raises events related to game progress. 
/// </summary>
public class CellGrid : MonoBehaviour
{
    public event EventHandler GameStarted;
    public event EventHandler GameEnded;
    public event EventHandler TurnEnded;
    
    private CellGridState _cellGridState;//The grid delegates some of its behaviours to cellGridState object.
    public CellGridState CellGridState
    {
        private get
        {
            return _cellGridState;
        }
        set
        {
            if(_cellGridState != null)
                _cellGridState.OnStateExit();
            _cellGridState = value;
            _cellGridState.OnStateEnter();
        }
    }

    public int NumberOfPlayers { get; private set; }

    public Player CurrentPlayer
    {
        get { return Players.Find(p => p.PlayerNumber.Equals(CurrentPlayerNumber)); }
    }
    public int CurrentPlayerNumber { get; private set; }

    public Transform PlayersParent;

    public List<Player> Players { get; private set; }
    public List<Cell> Cells = new List<Cell>();
    public List<Unit> Units { get; private set; }
    
    void Start()
    {
        Players = new List<Player>();
        for (int i = 0; i < PlayersParent.childCount; i++)
        {
            var player = PlayersParent.GetChild(i).GetComponent<Player>();
            if (player != null)
                Players.Add(player);
            else
                Debug.LogError("Invalid object in Players Parent game object");
        }
        NumberOfPlayers = Players.Count;
        CurrentPlayerNumber = Players.Min(p => p.PlayerNumber);

        createCellsList();

        var unitGenerator = GetComponent<IUnitGenerator>();
        if (unitGenerator != null)
        {
            Units = unitGenerator.SpawnUnits(Cells);
        }
        else
            Debug.LogError("No IUnitGenerator script attached to cell grid");
        StartGame();
    }

    private void createCellsList()
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            var cell = transform.GetChild(i).gameObject.GetComponent<Cell>();
            if (cell != null)
                Cells.Add(cell);
            else
                Debug.LogError("Invalid object in cells paretn game object");
        }
    }
    
    /// <summary>
    /// Method is called once, at the beggining of the game.
    /// </summary>
    public void StartGame()
    {
        if(GameStarted != null)
            GameStarted.Invoke(this, new EventArgs());

        Units.FindAll(u => u.PlayerNumber.Equals(CurrentPlayerNumber)).ForEach(u => { u.OnTurnStart(); });
        Players.Find(p => p.PlayerNumber.Equals(CurrentPlayerNumber)).Play(this);
    }
    /// <summary>
    /// Method makes turn transitions. It is called by player at the end of his turn.
    /// </summary>
    public void EndTurn()
    {
        if (Units.Select(u => u.PlayerNumber).Distinct().Count() == 1)
        {
            return;
        }
        CellGridState = new CellGridStateTurnChanging(this);

        Units.FindAll(u => u.PlayerNumber.Equals(CurrentPlayerNumber)).ForEach(u => { u.OnTurnEnd(); });

        CurrentPlayerNumber = (CurrentPlayerNumber + 1) % NumberOfPlayers;
        while (Units.FindAll(u => u.PlayerNumber.Equals(CurrentPlayerNumber)).Count == 0)
        {
            CurrentPlayerNumber = (CurrentPlayerNumber + 1)%NumberOfPlayers;
        }//Skipping players that are defeated.

        if (TurnEnded != null)
            TurnEnded.Invoke(this, new EventArgs());

        Units.FindAll(u => u.PlayerNumber.Equals(CurrentPlayerNumber)).ForEach(u => { u.OnTurnStart(); });
        Players.Find(p => p.PlayerNumber.Equals(CurrentPlayerNumber)).Play(this);     
    }

    public List<Cell> generatePath()
    {
        if(Cells.Count == 0)
        {
            createCellsList();
        }
        List<Cell> returnPath = new List<Cell>();
		GameObject[] arr = GameObject.FindGameObjectsWithTag("path");
		var unsortedList = new List<GameObject> ();
		for (int i = 0; i < arr.Length; i++) {
			if (arr [i].name != "pathTile") {
				unsortedList.Add (arr [i]);
			}
		}
		var sortedList = unsortedList.OrderBy (x => int.Parse(x.name.Substring(9))).ToList ();
		for (int i = 0; i < sortedList.Count; i++) {
			if (i == 86) {
				returnPath.Add (sortedList [34].GetComponent<Cell>());
				returnPath.Add (sortedList [35].GetComponent<Cell>());
			}
			returnPath.Add (sortedList [i].GetComponent<Cell>());
		}
        return returnPath;
    }

    public int CoordToIndex(int[] coord, int width)
    {
        return coord[0] * width + coord[1];
    }
}
