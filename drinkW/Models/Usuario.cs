﻿using drinkW.Enums;
using System.ComponentModel.DataAnnotations.Schema;

namespace drinkW.Models
{
    [Table("tblUsuario")]
    public class Usuario
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Login { get; set; }
        public string Senha { get; set; }
        public string Email { get; set; }
        public PerfilEnum Perfil { get; set; }
    }
}
