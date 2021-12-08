using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;

public partial class GameManager : MonoBehaviour
{
    private State currentState, nextState;
    private int captainAmericaScore, ironManScore;
    private Result currentResult;
    private bool onButtonClick = false;

    public void OnButtonClickCallback()
    {
        onButtonClick = true;
    }

    private void Start()
    {
        nextState = new StartState(this);
        NextState();
    }

    private void Update()
    {
        if (currentState != null && currentState.Update())
        {
            NextState();
        }

        onButtonClick = false;
    }

    private void NextState()
    {
        if (currentState != null)
        {
            currentState.End();
            currentState = null;
        }
        if (nextState != null)
        {
            currentState = nextState;
            currentState.Begin();
            nextState = null;
        }
    }

    private void EvaluateGame()
    {
        List<VuforiaObjectController> controllersOnTracking = new List<VuforiaObjectController>();
        foreach (VuforiaObjectController vuforiaObjectController in VuforiaObjectController.Controllers)
        {
            if (vuforiaObjectController.OnTracking)
            {
                controllersOnTracking.Add(vuforiaObjectController);
            }
        }

        if (controllersOnTracking.Count != 2)
        {
            return;
        }

        VuforiaObjectController ironManController = controllersOnTracking[0], captainAmericaController = controllersOnTracking[1];
        
        if (captainAmericaController.ScreenPosition.x < ironManController.ScreenPosition.x)
        {
            ironManController = controllersOnTracking[1];
            captainAmericaController = controllersOnTracking[0];
        }

        EvaluateResult(ironManController, captainAmericaController);
    }

    private void EvaluateResult(VuforiaObjectController ironManController, VuforiaObjectController captainAmericaController)
    {
        Type captainAmericaType = captainAmericaController.GetType();
        Type ironManType = ironManController.GetType();

        if (captainAmericaType == ironManType)
        {
            currentResult = Result.Draw;
        }
        else
        {
            if (captainAmericaType == typeof(BlackWidowController))
            {
                currentResult = ironManType == typeof(BlackPantherController) ? Result.CaptainAmericaWin : Result.IronManWin;
            }
            else if (captainAmericaType == typeof(BlackPantherController))
            {
                currentResult = ironManType == typeof(SpiderManController) ? Result.CaptainAmericaWin : Result.IronManWin;
            }
            else if (captainAmericaType == typeof(SpiderManController))
            {
                currentResult = ironManType == typeof(BlackWidowController) ? Result.CaptainAmericaWin : Result.IronManWin;
            }
        }

        if (currentResult == Result.CaptainAmericaWin)
        {
            captainAmericaScore++;
        }
        else if (currentResult == Result.IronManWin)
        {
            ironManScore++;
        }

        UpdateScoreView();
    }

    private enum Result
    {
        Draw,
        CaptainAmericaWin,
        IronManWin
    }
}
