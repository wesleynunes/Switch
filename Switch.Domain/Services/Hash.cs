﻿using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

namespace Switch.Domain.Services
{
    public class Hash
    {
        public static string GenerateHash(string texto)
        {
            SHA256 sha256 = SHA256Managed.Create();
            byte[] bytes = Encoding.UTF8.GetBytes(texto);
            byte[] hash = sha256.ComputeHash(bytes);
            StringBuilder result = new StringBuilder();
            for (int i = 0; i < hash.Length; i++)
            {
                result.Append(hash[i].ToString("X"));
            }
            return result.ToString();
        }
    }
}
