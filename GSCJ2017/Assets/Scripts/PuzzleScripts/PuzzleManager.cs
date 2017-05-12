using UnityEngine;
using System.Collections.Generic;

public class PuzzleManager : MonoBehaviour {

    [SerializeField] List<Transform> puzzles = new List<Transform>();
    [SerializeField] List<Transform> puzzleSpawnpoints = new List<Transform>();

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

    public void loadPuzzle(int playerNumber)
    {
        int randIndex = Random.Range(0,puzzles.Count);
        Transform madePuzzle = Instantiate(puzzles[randIndex], puzzleSpawnpoints[playerNumber].position, Quaternion.identity) as Transform;
        madePuzzle.GetComponent<Puzzle>().setPlayer(playerNumber);
    }

    public void puzzleComplete(bool won, int playerIndex)
    {
        Debug.Log("Puzzle Complete!" + " " + playerIndex + " - " + won);
    }
}
