﻿using Application;

namespace API.Core
{
    public class JwtActor : IApplicationActor
    {
        public int Id { get; set; }
        public string Identity { get; set; }
        public IEnumerable<int> AllowedUseCases { get; set; }
    }
}
