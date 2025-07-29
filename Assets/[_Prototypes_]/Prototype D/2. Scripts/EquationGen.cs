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
    private void Start()
    {
        GenerateEquation();
    }
    public void GenerateEquation()
    {
        /*int coinflip = Random.Range(1, 5))
         * 1 = addition
         * 2 = subtraction
         * 3 = multiplication
         * 4 = division

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
