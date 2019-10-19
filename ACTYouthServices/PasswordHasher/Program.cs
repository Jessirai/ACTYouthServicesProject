using System;

using Microsoft.AspNetCore.Identity;

namespace PasswordHasher
{
    class Program
    {
        static void Main(string[] args)
        {
            var passwordHasher = new PasswordHasher<string>();
            Console.WriteLine(passwordHasher.HashPassword(null, "admin"));
            Console.ReadLine();
        }
    }
}
