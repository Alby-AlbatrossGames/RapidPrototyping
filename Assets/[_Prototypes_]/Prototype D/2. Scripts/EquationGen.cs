using Prototype4;
using TMPro;
using UnityEngine;

public class EquationGen : GameBehaviour
{
    public TMP_Text answerText;
    public TMP_Text num1Text;
    public TMP_Text num2Text;
    public TMP_Text symbolText;

    private string correct;

    public enum CorrectSymbol { Add, Subtract, Multiply, Divide, Waiting }
    public CorrectSymbol correctSymbol = CorrectSymbol.Waiting;
    private void Start()
    {
        GenerateEquation();
    }
    public void GenerateEquation()
    {
        symbolText.text = "?";
        int coinflip = Random.Range(1, 5);

        switch (coinflip)
        {
            case 1:
                AddGen(RNGPosNumGen(), RNGPosNumGen());
                break;
            case 2:
                SubtractGen(RNGPosNumGen(), RNGPosNumGen());
                break;
            case 3:
                MultiplyGen(RNGPosNumGen(), RNGPosNumGen());
                break;
            case 4:
                DivideGen(DivGen1(), 2);
                break;
        }
    }
    void AddGen(int num1, int num2)
    {
        correctSymbol = CorrectSymbol.Add;
        correct = "+";
        float ans = num1 + num2;

        num1Text.text = num1.ToString();
        num2Text.text = num2.ToString();
        answerText.text = ans.ToString();

        Debug.Log(num1 + "+" + num2 + "=" + ans);
    }
    void SubtractGen(int num1, int num2)
    {
        correctSymbol = CorrectSymbol.Subtract;
        correct = "-";
        float ans = num1 - num2;

        num1Text.text = num1.ToString();
        num2Text.text = num2.ToString();
        answerText.text = ans.ToString();

        Debug.Log(num1 + "-" + num2 + "=" + ans);
    }

    void MultiplyGen(int num1, int num2)
    {
        correctSymbol = CorrectSymbol.Multiply;
        correct = "x";
        float ans = num1 * num2;

        num1Text.text = num1.ToString();
        num2Text.text = num2.ToString();
        answerText.text = ans.ToString();

        Debug.Log(num1 + "x" + num2 + "=" + ans);
    }

    void DivideGen(int num1, int num2)
    {
        correctSymbol = CorrectSymbol.Divide;
        correct = "/";
        float ans = num1 / num2;

        num1Text.text = num1.ToString();
        num2Text.text = num2.ToString();
        answerText.text = ans.ToString();

        Debug.Log(num1 + "/" + num2 + "=" + ans);
    }

    public void ShowAnswer()
    {
        symbolText.text = correct;
    }

    int RNGPosNumGen() => Random.Range(1, 11);

    int DivGen1()
    {
        int rng = Random.Range(1, 6); // 1-5
        switch (rng)
        {
            case 1:
                return 2;
            case 2:
                return 4;
            case 3:
                return 6;
            case 4:
                return 8;
            case 5:
                return 10;

            default:
                return 2;
        }
    }
}
