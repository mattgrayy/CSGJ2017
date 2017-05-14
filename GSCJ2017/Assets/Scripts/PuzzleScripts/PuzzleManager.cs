using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UI;

public class PuzzleManager : MonoBehaviour {

    [SerializeField] List<Transform> puzzles = new List<Transform>();
    [SerializeField] List<Transform> puzzleSpawnpoints = new List<Transform>();
    public List<Transform> players = new List<Transform>();
    [SerializeField] List<Text> defaultTextObjects = new List<Text>();

    [SerializeField] Transform elevatorPuzzle;

    public static PuzzleManager m_instance = null;

    void Start()
    {
        if (m_instance)
        {
            Destroy(this.gameObject);
        }
        else
        {
            m_instance = this;
        } 
    }

    public void loadPuzzle(int playerNumber, InteractableObject requestor)
    {
        defaultTextObjects[playerNumber].text = "";
        int randIndex = Random.Range(0,puzzles.Count);
        Transform madePuzzle = Instantiate(puzzles[randIndex], puzzleSpawnpoints[playerNumber].position, Quaternion.identity) as Transform;
        madePuzzle.GetComponent<Puzzle>().setPlayer(playerNumber, requestor);
        players[playerNumber].GetComponent<PlayerController>().isInPuzzle(true);
    }

    public void loadElevatorPuzzle(int playerNumber, InteractableObject requestor)
    {
        defaultTextObjects[playerNumber].text = "";
        Transform madePuzzle = Instantiate(elevatorPuzzle, puzzleSpawnpoints[playerNumber].position, Quaternion.identity) as Transform;
        madePuzzle.GetComponent<Puzzle>().setPlayer(playerNumber, requestor);
        players[playerNumber].GetComponent<PlayerController>().isInPuzzle(true);
    }

    public void puzzleComplete(bool outcome, int playerIndex, int score, InteractableObject requestor)
    {
        if (outcome)
        {
            players[playerIndex].GetComponent<PlayerController>().puzzlesSolved++;
        }
        players[playerIndex].GetComponent<PlayerController>().isInPuzzle(false);
        players[playerIndex].GetComponent<PlayerController>().score += score;
        GameManager.m_instance.addToGlobalScore(score);
        requestor.completedInteraction(outcome);
        setPuzzleIdle(playerIndex);
    }

    public Transform getPlayer(int _playerIndex)
    {
        return players[_playerIndex];
    }

    public void setPuzzleDropout(int _playerIndex)
    {
        defaultTextObjects[_playerIndex].text = "Player " + (_playerIndex + 1) + "\n\nPress Start to\njoin!";
    }

    public void setPuzzleIdle(int _playerIndex)
    {
        defaultTextObjects[_playerIndex].text = "Player " + (_playerIndex + 1)
                                                + "\n\nScore: " + players[_playerIndex].GetComponent<PlayerController>().score
                                                + "\nPuzzles solved: " + players[_playerIndex].GetComponent<PlayerController>().puzzlesSolved
                                                + "\nRacoons scared: " + players[_playerIndex].GetComponent<PlayerController>().racoonsScared;
    }
}
