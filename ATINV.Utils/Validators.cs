using System;

namespace ATINV.Utils
{
    public static class Validators
    {
        public static bool CpfIsValid(string cpf)
        {
            var currentCpf = cpf.Replace(".", "").Replace("-", "");
            if (!Int64.TryParse(currentCpf, out long currentCpfInt)) return false;
            currentCpf = currentCpfInt.ToString("D11");

            int[] array1digit = new int[9] { 10, 9, 8, 7, 6, 5, 4, 3, 2 };
            int[] array2digit = new int[10] { 11, 10, 9, 8, 7, 6, 5, 4, 3, 2 };

            var tempCpf = currentCpf.Substring(0, 9);
            string digit;
            int rest;

            /* computing the 1st digit */
            var total = 0;
            for (int i = 0; i < 9; i++)
                total += int.Parse(tempCpf[i].ToString()) * array1digit[i];

            rest = total % 11;

            if (rest < 2)
                rest = 0;
            else
                rest = 11 - rest;

            digit = rest.ToString();
            tempCpf += digit;

            /* computing the 2nd digit */
            total = 0;

            for (int i = 0; i < 10; i++)
                total += int.Parse(tempCpf[i].ToString()) * array2digit[i];

            rest = total % 11;

            if (rest < 2)
                rest = 0;
            else
                rest = 11 - rest;

            digit += rest.ToString();

            return cpf.EndsWith(digit);
        }
    }
}
