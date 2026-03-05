using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace AppNuvem.Models
{
	public class Pessoa
	{
        public int id { get; set; }
        public string nome { get; set; }
        public string celular { get; set;}
        public DateTime datanasc { get; set;}
        public string genero { get; set;}
        public Color CorGenero
        {
            get
            {
                if (genero == "M")
                    return Color.Blue;
                else if (genero == "F")
                    return Color.Pink;
                else
                    return Color.Gray;
            }
        }

        public string GeneroDesc
        {
            get
            {
                switch(genero)
                {
                    case "M":
                        return "Masculino";
                    case "F":
                        return "Feminino";
                    default:
                        return "Outro";
                }
            }
        }

        public string CelularFormatado
        {
            get
            {
                if (string.IsNullOrEmpty(celular))
                    return "";

                if (celular.Length == 11)
                    return $"({celular.Substring(0, 2)}) {celular.Substring(2, 5)}-{celular.Substring(7, 4)}";

                if (celular.Length == 10)
                    return $"({celular.Substring(0, 2)}) {celular.Substring(2, 4)}-{celular.Substring(6, 4)}";

                return celular;
            }
        }
    }
}
