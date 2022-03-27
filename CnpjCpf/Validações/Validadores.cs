namespace CnpjCpf.Validações
{
    public static class Validadores
    {
        public static bool ValidarCpf(string cpf)
        {            
            //Retirando espaços e caracteres especiais da string
            cpf = cpf.Trim();
            cpf = cpf.Replace(".", "").Replace("-", "");


            //Verificando se o numero de caracteres condiz
            if (cpf.Length != 11)
                return false;

                
            //Verificando se todos os caracteres são iguais

            char compare = cpf [0];
            string verificarComparacao = string.Empty;

            for (int i = 0; i < 11; i++)
            {
                verificarComparacao = verificarComparacao + compare;
            }

            if (cpf.Equals(verificarComparacao))
                return false;

            //Autenticando digitos verificadores

            string digitoCpf = cpf.Substring(9, 2);
            int total = 0;
            int peso = 10;

            string cpfSemDigito = string.Empty;

            for (int i = 0; i < 9; i++)
            {
                total = peso * Convert.ToInt32(cpf.Substring(i, 1)) + total;
                peso--;
                cpfSemDigito = cpfSemDigito + cpf.Substring(i, 1);
            }

            int resto = total % 11;

            string dvCpf = "0";

            if (resto > 2)
                dvCpf = Convert.ToString(11 - resto);

            int peso2 = 11;

            string cpfComUmDigito = cpfSemDigito + Convert.ToString(dvCpf);

            total = 0;

            for (int i = 0; i < 10; i++)
            {
                total = peso2 * Convert.ToInt32(cpfComUmDigito.Substring(i, 1)) + total;
                peso2--;
            }

            resto = total % 11;

            if (resto < 2)
                dvCpf = dvCpf + "0";

            else dvCpf = dvCpf + Convert.ToString(11 - resto);
            
            bool resultado;

            return resultado = (dvCpf == digitoCpf)? true : false;
        }



        public static bool ValidarCnpj(string cnpj)
        {
            //Retirando espaços e caracteres especiais da string
            cnpj = cnpj.Trim();
            cnpj = cnpj.Replace(".", "").Replace("-", "").Replace("/", "");


            //Verificando se o numero de caracteres condiz
            if (cnpj.Length != 14)
                return false;


            //Verificando se todos os caracteres são iguais

            char compare = cnpj [0];
            string verificarComparacao = string.Empty;

            for (int i = 0; i < 14; i++)
            {
                verificarComparacao = verificarComparacao + compare;
            }

            if (cnpj.Equals(verificarComparacao))
                return false;
            

            //Autenticando digitos verificadores

            int[] peso = new int[12] { 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 };
            string digitoCnpj = cnpj.Substring(12, 2);
            int total = 0;

            string cnpjSemDigito = string.Empty;

            for (int i = 0; i < 12; i++)
            {
                total = peso[i] * Convert.ToInt32(cnpj.Substring(i, 1)) + total;
                cnpjSemDigito = cnpjSemDigito + (cnpj.Substring(i, 1));
            }

            int resto = total % 11;

            string dvCnpj = "0";

            if (resto > 2)
                dvCnpj = Convert.ToString(11 - resto);

            int[] peso2 = new int[13] { 6, 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 };

            string cnpjComUmDigito = cnpjSemDigito + Convert.ToString(dvCnpj);

            total = 0;
            for (int i = 0; i < 13; i++)
            {
                total = peso2[i] * Convert.ToInt32(cnpjComUmDigito.Substring(i, 1)) + total;
            }

            resto = total % 11;

            if (resto < 2)
                dvCnpj = dvCnpj + "0";

            else dvCnpj = dvCnpj + Convert.ToString(11 - resto);

            return (dvCnpj == digitoCnpj)? true : false; 
        }
    }
}
