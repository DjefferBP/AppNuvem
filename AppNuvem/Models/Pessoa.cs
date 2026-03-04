using System;
using System.Collections.Generic;
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
    }
}
