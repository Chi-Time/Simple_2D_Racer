using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour
{
    /// The total score of the player in the game so far.
    public int Score { get { return _Score; } set { ChangeScore (value); } }

    [Tooltip("The player's total score in the game so far.")]
    [SerializeField] private int _Score = 0;

    private void ChangeScore (int score)
    {
        _Score = score;
    }
}
