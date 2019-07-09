using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Calculator
{
    public class Calculator
    {
        string[] ParseFunction(string opdracht)
        {
            string safe;
            if (opdracht[0] == '(')
            {
                safe = "0+";
            }
            else
            {
                safe = "0";
            }
            opdracht = safe + opdracht;
            int aantalBewerkingen = opdracht.Count(x => x == '+' || x == '-' || x == '*' || x == '/');
            int aantalHaakjes = opdracht.Count(x => x == '(' || x == ')');

            aantalBewerkingen -= Regex.Matches(opdracht, "\\+-").Count;
            aantalBewerkingen -= Regex.Matches(opdracht, "--").Count;
            aantalBewerkingen -= Regex.Matches(opdracht, "/-").Count;
            aantalBewerkingen -= Math.Max(Regex.Matches(opdracht, "\\*-").Count, 0);
            aantalBewerkingen -= Regex.Matches(opdracht, "\\(-").Count;


            string[] getallen = new string[1 + aantalBewerkingen * 2 + aantalHaakjes];

            int indexi = 0;
            int indexj = 0;

            for (int i = indexi; i < getallen.Length; i++)
            {

                for (int j = indexj; j < opdracht.Length; j++)
                {
                    if ((opdracht[j] == '+' || opdracht[j] == '-' || opdracht[j] == '*' || opdracht[j] == '/' || opdracht[j] == '(' || opdracht[j] == ')') && j != 0 && !(opdracht[j - 1] == '+' || opdracht[j - 1] == '-' || opdracht[j - 1] == '*' || opdracht[j - 1] == '/' || opdracht[j - 1] == '(' || opdracht[j - 1] == ')'))
                    {
                        indexi++;
                        i++;
                        getallen[i] = Convert.ToString(opdracht[j]);
                        j = opdracht.Length;
                    }
                    else if (opdracht[j] == '-' && j != 0 && (opdracht[j - 1] == '+' || opdracht[j - 1] == '-' || opdracht[j - 1] == '*' || opdracht[j - 1] == '/' || opdracht[j - 1] == '('))
                    {
                        getallen[i] = getallen[i] + "-";
                    }
                    else if (opdracht[j] == '+' || opdracht[j] == '-' || opdracht[j] == '*' || opdracht[j] == '/' || opdracht[j] == '(' || opdracht[j] == ')')
                    {
                        indexi++;
                        getallen[i] = Convert.ToString(opdracht[j]);
                        j = opdracht.Length;
                    }
                    else
                    {
                        string temp = Convert.ToString(opdracht[j]);
                        if (temp == ".")
                        {
                            temp = ",";
                        }
                        getallen[i] = getallen[i] + temp;
                    }

                    indexj++;
                }
            }

            return getallen;
        }

        public int VolgordeBewerkingen(string[] getallen)
        {
            int level = 0; //0 = + -;;  1 = * /;; 2 = ( )

            for (int i = 0; i < getallen.Length; i++)
            {
                if ((getallen[i] == "*" || getallen[i] == "/") && level < 1)
                {
                    level = 1;
                }
                else if ((getallen[i] == "(" || getallen[i] == ")") && level < 2)
                {
                    level = 2;
                }
            }

            return level;
        }



        string[] LosOp(ref string[] getallen)
        {
            int level = VolgordeBewerkingen(getallen);

            string[] nieuw = new string[getallen.Length - 2];

            if (level == 0)
            {
                if (getallen[1] == "+")
                {
                    nieuw[0] = Convert.ToString(Convert.ToDecimal(getallen[0]) + Convert.ToDecimal(getallen[2]));

                    for (int i = 3; i < getallen.Length; i++)
                    {
                        nieuw[i - 2] = getallen[i];
                    }
                }
                else if (getallen[1] == "-")
                {
                    nieuw[0] = Convert.ToString(Convert.ToDecimal(getallen[0]) - Convert.ToDecimal(getallen[2]));

                    for (int i = 3; i < getallen.Length; i++)
                    {
                        nieuw[i - 2] = getallen[i];
                    }
                }
            }
            if (level == 1)
            {
                for (int i = 0; i < getallen.Length; i++)
                {
                    if (getallen[i] == "*")
                    {
                        getallen[i - 1] = Convert.ToString(Convert.ToDecimal(getallen[i - 1]) * Convert.ToDecimal(getallen[i + 1]));
                        for (int j = 0; j < i; j++)
                        {
                            nieuw[j] = getallen[j];
                        }
                        for (int j = i; j < nieuw.Length; j++)
                        {
                            nieuw[j] = getallen[j + 2];
                        }
                        break;
                    }
                    else if (getallen[i] == "/")
                    {
                        getallen[i - 1] = Convert.ToString(Convert.ToDecimal(getallen[i - 1]) / Convert.ToDecimal(getallen[i + 1]));
                        for (int j = 0; j < i; j++)
                        {
                            nieuw[j] = getallen[j];
                        }
                        for (int j = i; j < nieuw.Length; j++)
                        {
                            nieuw[j] = getallen[j + 2];
                        }
                        break;
                    }
                }
            }
            if (level == 2)
            {
                int haakjes = 0;
                int openPos = 0;
                int closePos = 0;
                for (int i = 0; i < getallen.Length; i++)
                {
                    if (getallen[i] == "(")
                    {
                        if (haakjes == 0)
                            openPos = i;
                        haakjes++;
                    }
                    else if (getallen[i] == ")")
                    {
                        haakjes--;
                        if (haakjes == 0)
                        {
                            closePos = i;
                            break;
                        }
                    }
                }

                string[] temp = new string[closePos - openPos - 1];
                int tempLength = temp.Length;

                for (int j = 0; j < temp.Length; j++)
                {
                    temp[j] = getallen[openPos + j + 1];
                }

                nieuw = new string[getallen.Length - temp.Length - 1];

                while (temp.Length > 1)
                {
                    temp = LosOp(ref temp);
                }

                getallen[openPos] = temp[0];


                int endPos = 0;
                for (int x = 0; x <= openPos; x++)
                {
                    nieuw[x] = getallen[x];
                    endPos = x;
                }
                for (int x = 1; x + openPos + 1 + tempLength < getallen.Length; x++)
                {
                    nieuw[x + endPos] = getallen[x + openPos + 1 + tempLength];
                }
            }

            return nieuw;

        }

        public string Main(string opdracht)
        {
            string[] getallen = ParseFunction(opdracht);


            bool opnieuw = true;
            try
            {
                while (opnieuw)
                {
                    getallen = LosOp(ref getallen);

                    if (getallen.Length < 2)
                    {
                        opnieuw = false;
                    }
                }
            }
            catch
            {
            }

            return getallen[0];
        }
    }
}
