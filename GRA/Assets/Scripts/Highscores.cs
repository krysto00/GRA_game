using UnityEngine;
using UnityEngine.UI;

public class HighScores : MonoBehaviour
{
    public Text highScoresText;
    int[] highScoresArray;

    void Start()
    {
        // Prova a caricare l'array salvato
        highScoresArray = PlayerPrefsX.GetIntArray("HighScoreArray");

        // Se l'array è vuoto o non esiste, creane uno di default
        if (highScoresArray == null || highScoresArray.Length == 0)
        {
            highScoresArray = new int[] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
            PlayerPrefsX.SetIntArray("HighScoreArray", highScoresArray);
            PlayerPrefs.Save();
        }

        // Visualizzazione
        if (highScoresArray.Length == 0 || highScoresArray[0] == 0)
        {
            highScoresText.text = "NESSUN RISULTATO PRESENTE";
        }
        else
        {
            highScoresText.text = "";
            for (int i = 0; i < highScoresArray.Length && highScoresArray[i] != 0; i++)
            {
                highScoresText.text += (i + 1) + ". " + highScoresArray[i] + " pt " + System.Environment.NewLine;
            }
        }
    }
}
