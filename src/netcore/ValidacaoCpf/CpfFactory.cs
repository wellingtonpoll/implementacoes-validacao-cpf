using System;
using System.Linq;

namespace ValidacaoCpf
{
    public class CpfFactory
    {
        public static Cpf CreateInstance(string number)
        {
            number = number.Trim().Replace(".", "").Replace("-", "");

            Cpf cpf = new Cpf(number);

            if (number.Length != 11)
            {
                cpf.isValid = false;
                return cpf;
            }

            var numberInts = new int[11];

            for (int i = 0; i < 11; i++)
            {
                numberInts[i] = Convert.ToInt32(number[i]);
            }

            int soma1 = 0, soma2 = 0;

            for (int i = 0; i < 10; i++)
            {
                soma1 += (i < 9) ? (numberInts[i] * (10 - i)) : 0;
                soma2 += numberInts[i] * (11 - i);
            }

            int resto1 = mod11(soma1);
            int resto2 = mod11(soma2);

            cpf.isValid = resto1 == numberInts[9] &&
                          resto2 == numberInts[10];

            return cpf;
        }

        private static int mod11(int soma)
        {
            int digito = soma % 11;
            return (digito < 2) ? 0 : 11 - digito;
        }
    }
}
