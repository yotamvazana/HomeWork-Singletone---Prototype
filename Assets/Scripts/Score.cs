using UnityEngine;

public class Score : MonoBehaviour
{
    public static Score scoreSingle;

    internal float score = 0f;

    void Awake()
    {
        if (scoreSingle == null)
        {
            scoreSingle = this;
        }

    }

    public void AddScore(int points)
    {

        this.score += points;

    }

}
