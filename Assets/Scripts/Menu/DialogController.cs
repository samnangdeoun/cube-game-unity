
using UnityEngine;

public class DialogController : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject dialogWin;
    public GameObject dialogLost;
    public GameObject dialogPause;

    private void Start()
    {
        Time.timeScale = 1;
        GameSystem.GetInstance().isShowDialog = false;  
    }

    public void ShowWin(bool isShow)
    {
        if (dialogWin != null)
        {
            dialogWin.SetActive(isShow);
            AudioManager.GetInstance().Play("game_win");
        }

    }

    public void ShowLost(bool isShow)
    {
        if (dialogLost != null)
        {
            dialogLost.SetActive(isShow);
            if(isShow)
            {
                LockMouse();

            }
            else
            {
                UnlockMouse();
                AudioManager.GetInstance().Play("game_over");
            }
        }
    }
    public void Resume()
    {
        AudioManager.GetInstance().Play("vine_boom");
        UnlockMouse();
        ShowPause(false);
    }
    public void Pause()
    {
        LockMouse();
        ShowPause(true);

    }
    public void ShowPause(bool isShow)
    {
        AudioManager.GetInstance().Play("dialog_popup");
        if (dialogPause != null)
        {
            dialogPause.SetActive(isShow);
        }

    }
    public void LockMouse()
    {
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
        GameSystem.GetInstance().isShowDialog = true;
        Time.timeScale = 0;
    }
    public void UnlockMouse()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        GameSystem.GetInstance().isShowDialog = false;
        Time.timeScale = 1;
    }
    private void Update()
    {
        if(GameSystem.GetInstance().isShowDialog)
        {
            return;
        }
        if(dialogPause!= null)
        {
            if(Input.GetKeyDown(KeyCode.Escape))
            {

                if (dialogPause.activeSelf)
                {
                  Resume();
                }
                else
                {
                  Pause();

                }
            }
        }
    }
    
}
