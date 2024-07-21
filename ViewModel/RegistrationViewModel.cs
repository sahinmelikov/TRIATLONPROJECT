﻿using TriatlonProject.Models;

namespace TriatlonProject.ViewModel
{
    public class RegistrationViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string SurName { get; set; }
        public string EmailAddres { get; set; }
        public string Country { get; set; }
        public string NewYear { get; set; }
        public string? Comando { get; set; }
        public string? Cinsi { get; set; }
        public string T_ShirtSie { get; set; }
        public int RaceId { get; set; }
        public List<Race> Race { get; set; }
    }
}