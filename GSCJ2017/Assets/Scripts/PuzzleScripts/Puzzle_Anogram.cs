using UnityEngine;
using System.Collections.Generic;

public class Puzzle_Anogram : Puzzle
{
    public struct anogram
    {
        [SerializeField] List<string> lettersInOrder;
    }

    [SerializeField] List<anogram> words = new List<anogram>();

    void Update()
    {
        //completePuzzle(true);
    }
}
