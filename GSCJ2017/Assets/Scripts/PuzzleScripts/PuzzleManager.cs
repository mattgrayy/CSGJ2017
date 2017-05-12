using UnityEngine;
using System.Collections.Generic;

public class PuzzleManager : MonoBehaviour {

    [SerializeField] List<Transform> puzzles = new List<Transform>();
    [SerializeField] List<Transform> puzzleSpawnpoints = new List<Transform>();
    [SerializeField] List<Transform> players = new List<Transform>();

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
        int randIndex = Random.Range(0,puzzles.Count);
        Transform madePuzzle = Instantiate(puzzles[randIndex], puzzleSpawnpoints[playerNumber].position, Quaternion.identity) as Transform;
        madePuzzle.GetComponent<Puzzle>().setPlayer(playerNumber, requestor);
        players[playerNumber].GetComponent<PlayerController>().isInPuzzle(true);
    }

    public void loadElevatorPuzzle(int playerNumber, InteractableObject requestor)
    {
        players[playerNumber].GetComponent<PlayerController>().isInPuzzle(true);
        Transform madePuzzle = Instantiate(elevatorPuzzle, puzzleSpawnpoints[playerNumber].position, Quaternion.identity) as Transform;
        madePuzzle.GetComponent<Puzzle>().setPlayer(playerNumber, requestor);
    }

    public void puzzleComplete(bool outcome, int playerIndex, InteractableObject requestor)
    {
        players[playerIndex].GetComponent<PlayerController>().isInPuzzle(false);
        requestor.completedInteraction(outcome);
    }
}
