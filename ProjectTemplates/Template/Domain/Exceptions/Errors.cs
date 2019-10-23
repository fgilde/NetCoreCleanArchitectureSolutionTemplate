using System;
using System.Collections.Generic;

namespace $safeprojectname$.Exceptions
{
    public class Errors
    {
        public static Exception NotFound(in int id, string name)
        {
            return new KeyNotFoundException($"Entity {name} with id {id} not found");
        }
    }
}