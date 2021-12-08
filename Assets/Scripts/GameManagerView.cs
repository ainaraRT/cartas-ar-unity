using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public partial class GameManager : MonoBehaviour
{
    private string GetResultText()
    {
        switch (currentResult)
        {
            case Result.CaptainAmericaWin:
                return "¡Ha ganado el equipo Captain America!";
            case Result.IronManWin:
                return "¡Ha ganado el equipo Iron Man!";
            // case Result.Draw:
            default:
                return "La partida ha quedado en empate.";
        }
    }

    private void UpdateScoreView()
    {
        ironManResultText.text = ironManScore.ToString();
        captainAmericaResultText.text = captainAmericaScore.ToString();
    }

    [SerializeField]
    private Text stateText = null;
    [SerializeField]
    private Text descriptionText = null;
    [SerializeField]
    private Text buttonText = null;
    [SerializeField]
    private Text ironManResultText = null;
    [SerializeField]
    private Text captainAmericaResultText = null;
}
