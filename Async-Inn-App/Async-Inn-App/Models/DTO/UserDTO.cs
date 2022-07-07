﻿using System.Collections.Generic;

namespace Async_Inn_App.Models.DTO
{
    public class UserDTO
    {
        public string Id { get; set; }
        public string Username { get; set; }
        public string Token { get; set; }

        public IList<string> Roles { get; set; }
    }
}
