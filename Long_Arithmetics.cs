using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LongArith
{
    public class Long_Arithmetics
    {
        public static String findProizv(String oneS, String twoS)
        {
            bool signOne = oneS.Contains("-"), signTwo = twoS.Contains("-");
            oneS = oneS.Replace("-", "");
            twoS = twoS.Replace("-", "");

            if (isSecondValueHigher(oneS, twoS))
            { 
                String temp = twoS;
                twoS = oneS;
                oneS = temp;
            }

            String result = "0";
            while (!twoS.Equals("0"))
            {
                twoS = findRaznost(twoS, "1");
                result = findSumm(result, oneS);
            }

            return (signOne || signTwo ? "-" : "") + result;

        }

        public static String findRaznost(String oneS, String twoS)
        {
            bool signOne = oneS.Contains("-"), signTwo = twoS.Contains("-");

            if (signOne && !signTwo) {
                return "-" + findSumm(oneS.Replace("-", ""), twoS.Replace("-", ""));
            }

            if (!signOne && signTwo) {
                return findSumm(oneS.Replace("-", ""), twoS.Replace("-", ""));
            }

            if (signOne && signTwo)
            {
                return findSumm(oneS, twoS.Replace("-", ""));
            }

            bool sign = false;

            if (isSecondValueHigher(oneS, twoS)) {
                sign = !sign;
                String temp = twoS;
                twoS = oneS;
                oneS = temp;
            }

            while (oneS.Length != twoS.Length)
            {
                if (oneS.Length > twoS.Length)
                {
                    twoS = stringPlusZero(twoS);
                }
                else
                {
                    oneS = stringPlusZero(oneS);
                }
            }

            String obrKod = "";

            for (int i = 0; i < twoS.Length; i++)
            {
                if ((i == twoS.Length - 2) && (Convert.ToInt32(Convert.ToString(twoS[twoS.Length - 1])) == 0))
                {
                    obrKod += "" + ((i == twoS.Length - 1 ? 10 : 9) - (Convert.ToInt32(Convert.ToString(twoS[i])) - 1)) + "0";
                    break;
                }
                else
                {
                    obrKod += "" + ((i == twoS.Length - 1 ? 10 : 9) - Convert.ToInt32(Convert.ToString(twoS[i])));
                }
            }

            String answer = findSumm(oneS, obrKod).Remove(0, 1);
            int itemsToDel = 0;

            for (int i = 0; i < answer.Length; i++)
            {
                if (Convert.ToInt32(Convert.ToString(answer[i])) > 0)
                {
                    break;
                }
                else
                {
                    itemsToDel++;
                }
            }

            answer = answer.Remove(0, itemsToDel);




            return answer.Length > 0 ? ((sign ? "-" : "") + answer) : ("0");
        }

        public static String findSumm(String oneS, String twoS)
        {
            bool signOne = oneS.Contains("-"), signTwo = twoS.Contains("-");

            if (signOne && !signTwo) {
                return findRaznost(twoS.Replace("-", ""), oneS.Replace("-", ""));
            }

            if (!signOne && signTwo)
            {
                return findRaznost(oneS.Replace("-", ""), twoS.Replace("-", ""));
            }

            if (signOne && signTwo)
            {
                return "-" + findSumm(oneS.Replace("-", ""), twoS.Replace("-", ""));
            }

            while (oneS.Length != twoS.Length)
            {
                if (oneS.Length > twoS.Length)
                {
                    twoS = stringPlusZero(twoS);
                }
                else
                {
                    oneS = stringPlusZero(oneS);
                }
            }

            byte[] one = new byte[oneS.Length];
            byte[] two = new byte[twoS.Length];

            for (int i = 0; i < oneS.Length; i++)
            {
                one[i] = Convert.ToByte(Convert.ToString(oneS[i]));
            }
            for (int i = 0; i < twoS.Length; i++)
            {
                two[i] = Convert.ToByte(Convert.ToString(twoS[i]));
            }

            byte[] result = new byte[oneS.Length];


            for (int i = oneS.Length - 1; i >= 0; i--)
            {

                result[i] = (byte) (one[i] + two[i]);

                if (result[i] >= 10 && i != 0)
                {
                    int temp = result[i] / 10;
                    one[i - 1] += (byte)(temp);
                    result[i] -= (byte)(temp * 10);
                }
            }

            String answer = "";
            for (int i = 0; i < result.Length; i++)
            {
                answer += "" + result[i];
            }

            return answer;
        }

        public static bool isFirstValueHigher(String oneS, String twoS) { 
            return oneS.Equals(findMax(oneS, twoS));
        }

        public static bool isSecondValueHigher(String oneS, String twoS)
        {
            return twoS.Equals(findMax(oneS, twoS));
        }

        public static String findMin(String oneS, String twoS)
        {
            bool signOne = oneS.Contains("-"), signTwo = twoS.Contains("-");

            if (!signOne && signTwo)
            {
                return twoS;
            }

            if (!signTwo && signOne)
            {
                return oneS;
            }

            if (!signOne && !signTwo)
            {
                if (oneS.Length == twoS.Length)
                {
                    for (int i = 0; i < twoS.Length; i++)
                    {
                        if (Convert.ToInt32(Convert.ToString(oneS[i])) < Convert.ToInt32(Convert.ToString(twoS[i])))
                        {
                            return oneS;
                        }
                        if (Convert.ToInt32(Convert.ToString(oneS[i])) > Convert.ToInt32(Convert.ToString(twoS[i])))
                        {
                            return twoS;
                        }
                    }
                }

                if (oneS.Length < twoS.Length)
                {
                    return oneS;
                }
                else
                {
                    return twoS;
                }
            }

            if (signOne && signTwo)
            {
                if (oneS.Length == twoS.Length)
                {
                    for (int i = 1; i < twoS.Length; i++)
                    {
                        if (Convert.ToInt32(Convert.ToString(oneS[i])) > Convert.ToInt32(Convert.ToString(twoS[i])))
                        {
                            return oneS;
                        }
                        if (Convert.ToInt32(Convert.ToString(oneS[i])) < Convert.ToInt32(Convert.ToString(twoS[i])))
                        {
                            return twoS;
                        }
                    }
                }

                if (oneS.Length > twoS.Length)
                {
                    return oneS;
                }
                else
                {
                    return twoS;
                }
            }

            return oneS;
        }

        public static String findMax(String oneS, String twoS) {
            bool signOne = oneS.Contains("-"), signTwo = twoS.Contains("-");

            if (signOne && !signTwo) {
                return twoS;
            }

            if (signTwo && !signOne) {
                return oneS;
            }

            if (!signOne && !signTwo) {
                if (oneS.Length == twoS.Length) {
                    for (int i = 0; i < twoS.Length; i++) {
                        if (Convert.ToInt32(Convert.ToString(oneS[i])) > Convert.ToInt32(Convert.ToString(twoS[i])))
                        {
                            return oneS;
                        }
                        if (Convert.ToInt32(Convert.ToString(oneS[i])) < Convert.ToInt32(Convert.ToString(twoS[i])))
                        {
                            return twoS;
                        }
                    }
                }

                if (oneS.Length > twoS.Length)
                {
                    return oneS;
                }
                else {
                    return twoS;
                }
            }

            if (signOne && signTwo)
            {
                if (oneS.Length == twoS.Length)
                {
                    for (int i = 1; i < twoS.Length; i++)
                    {
                        if (Convert.ToInt32(Convert.ToString(oneS[i])) < Convert.ToInt32(Convert.ToString(twoS[i])))
                        {
                            return oneS;
                        }
                        if (Convert.ToInt32(Convert.ToString(oneS[i])) > Convert.ToInt32(Convert.ToString(twoS[i])))
                        {
                            return twoS;
                        }
                    }
                }

                if (oneS.Length < twoS.Length)
                {
                    return oneS;
                }
                else
                {
                    return twoS;
                }
            }

            return oneS;
        }

        static String stringPlusZero(String s)
        {
            return "0" + s;
        }
    }
}
