using System;

namespace ValidacaoCpf
{
    public struct Cpf
    {
        private string value;
        public bool isValid;

        public Cpf(string value)
        {
            this.value = value;
            isValid = false;
        }
    }
}
