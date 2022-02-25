using UnityEngine;
using UnityEngine.UI;
public class UI_FimDeJogo : MonoBehaviour
{
    public Text message;
    GameManager gm;
    private void OnEnable()
    {
        gm = GameManager.GetInstance();
        if (gm.vidas > 0)
        {
            message.text = "You Win!!!";
        }
        else
        {
            message.text = "GameOver";
        }
    }
    public void Voltar()
    {
        gm.ChangeState(GameManager.GameState.GAME);
    }
}