﻿using System;
using System.Collections.Generic;

#nullable disable

namespace Loja.API.Models.Loja
{
    public partial class Cliente
    {
        public string Nome { get; set; }
        public string Fone { get; set; }
        public DateTime Datanasc { get; set; }
        public string Endereco { get; set; }
        public string Bairro { get; set; }
        public string Cep { get; set; }
        public string Referencia { get; set; }
        public string Email { get; set; }
        public string Cpf { get; set; }
        public int Id { get; set; }
    }
}
