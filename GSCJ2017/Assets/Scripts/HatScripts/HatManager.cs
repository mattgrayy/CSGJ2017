using UnityEngine;
using System.Collections.Generic;

public class HatManager : MonoBehaviour {
    [SerializeField]
    List<Transform> players = new List<Transform>();

    public static HatManager m_instance = null;
   
    void Start ()
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
	
	public void addHat(int _playerNum, int _hatNum)
    {
        Debug.Log(players[_playerNum]);
        players[_playerNum].GetComponent<HatController>().addHat(_hatNum);
    }
}
