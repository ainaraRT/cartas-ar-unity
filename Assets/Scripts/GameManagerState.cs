using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public partial class GameManager : MonoBehaviour
{
    private abstract class State
    {
        protected GameManager game;

        public State(GameManager gameManager)
        {
            game = gameManager;
        }

        public abstract void Begin();
        public abstract bool Update();
        public abstract void End();
    }

    private class StartState : State
    {
        public StartState(GameManager gameManager) : base(gameManager)
        {

        }

        public override void Begin()
        {
            game.stateText.text = "¡Bienvenidos!";
            game.descriptionText.text = "Por favor, fija la cámara y reparte una carta de cada tipo a cada jugador. Black Panther gana a Spider Man; Spider Man gana a Black Widow; Black Widow gana a Black Panther. Cuando estén listos, pulsen el botón 'Siguiente'";
            game.buttonText.text = "Siguiente";
        }
        public override bool Update()
        {
            if (game.onButtonClick)
            {
                return true;
            }
            return false;
        }

        public override void End()
        {
            game.nextState = new PutCardState(game);
        }
    }

    private class PutCardState : State
    {
        public PutCardState(GameManager gameManager) : base(gameManager)
        {

        }

        public override void Begin()
        {
            game.stateText.text = "¡Prepárense para luchar!";
            game.descriptionText.text = "Ambos jugadores ponen la carta elegida boca abjao dentro del campo de visión de la cámara. Luego darle la vuelta y pulsar el boton 'A luchar'";
            game.buttonText.text = "A luchar";
        }
        public override bool Update()
        {
            if (game.onButtonClick)
            {
                return true;
            }
            return false;
        }

        public override void End()
        {
            game.nextState = new EvaluateState(game);
        }
    }

    private class EvaluateState : State
    {
        public EvaluateState(GameManager gameManager) : base(gameManager)
        {
            game.EvaluateGame();

            game.stateText.text = "Resultado";
            game.descriptionText.text = game.GetResultText();
            game.buttonText.text = "Revancha";
        }

        public override void Begin()
        {

        }
        public override bool Update()
        {
            if (game.onButtonClick)
            {
                return true;
            }
            return false;
        }

        public override void End()
        {
            game.nextState = new PutCardState(game);
            game.currentResult = Result.Draw;
        }
    }
}
