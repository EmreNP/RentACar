﻿using Core.Entities;

namespace Entities.DtoS
{
    public class UserForLoginDto : IDto
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
