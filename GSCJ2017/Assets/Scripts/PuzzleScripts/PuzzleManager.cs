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
    }

    public void loadElevatorPuzzle(int playerNumber, InteractableObject requestor)
    {
        // need elevator puzzle
    }

    public void puzzleComplete(bool won, int playerIndex, InteractableObject requestor)
    {
        Debug.Log("Puzzle Complete!" + " " + playerIndex + " - " + won);
    }
}
