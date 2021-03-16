using UnityEngine;
using UnityEngine.UI;

public class UI_EndGame : MonoBehaviour
{
    public Text message;
    GameManager gm;

    private void OnEnable()
    {
       gm = GameManager.GetInstance();

       if (gm.points <= 10000 || gm.lives <= 0)
       {
           message.text = "Você Perdeu!!! :(";
       }
       else
       {
           message.text = "Você Ganhou!!";
       }
   }

   public void Back()
   {
       gm.ChangeState(GameManager.GameState.MENU);
   }
}
