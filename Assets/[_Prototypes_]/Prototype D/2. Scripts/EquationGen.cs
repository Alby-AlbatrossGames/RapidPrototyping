using Prototype4;
using TMPro;
using UnityEngine;

public class EquationGen : MonoBehaviour
{
    public TMP_Text answerText;
    public TMP_Text num1Text;
    public TMP_Text num2Text;

    public enum CorrectSymbol { Add, Subtract, Multiply, Divide, Waiting }
    public CorrectSymbol correctSymbol = CorrectSymbol.Waiting;
    public void GenerateEquation()
    {
        /*int coinflip = Random.Range(1, 3))
        if ( ( == 1) {

        }*/

        AdditionGen(RandomNumberGen(), RandomNumberGen());
    }
    void AdditionGen(int num1, int num2)
    {
        correctSymbol = CorrectSymbol.Add;
        int ans = num1 + num2;

        num1Text.text = num1.ToString();
        num2Text.text = num2.ToString();
        answerText.text = ans.ToString();

    }

    int RandomNumberGen()
    {
        return Random.Range(0, 10);
    }
}
