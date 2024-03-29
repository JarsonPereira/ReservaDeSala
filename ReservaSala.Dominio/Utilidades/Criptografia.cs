﻿using System;
using System.Security.Cryptography;
using System.Text;


namespace ReservaSala.Dominio.Utilidades
{
    public static class Criptografia
    {
        public enum TipoCriptografia
        {
            MD5,
            SHA256,
            Base64
        }
        public static string Criptografar(string item, TipoCriptografia tipoCriptografia)
        {
            string itemCriptografado = string.Empty;
            switch (tipoCriptografia)
            {
                case TipoCriptografia.MD5:
                    itemCriptografado = CriptografiaMD5(item);
                    break;
                case TipoCriptografia.SHA256:
                     itemCriptografado = CriptografiaSHA256(item);
                    break;

                case TipoCriptografia.Base64:
                     itemCriptografado = CriptografiaBase64(item);
                    break;
                default:
                    break;
            }
            return itemCriptografado;
        }

        public static string CriptografiaMD5(string item)
        {
            MD5 md5 = MD5.Create();
            var itemHash = Encoding.UTF8.GetBytes(item);
            var hash = md5.ComputeHash(itemHash);

            StringBuilder montaHashMd5 = new StringBuilder();
            for (int i = 0; i < hash.Length; i++)
            {
                montaHashMd5.Append(hash[i].ToString("X2"));
            }
            return montaHashMd5.ToString();

        }

        public static string CriptografiaSHA256(string item)
        {
            SHA256 md5 = SHA256.Create();
            var itemHash = Encoding.UTF8.GetBytes(item);
            var hash = md5.ComputeHash(itemHash);

            StringBuilder montaHashSHA256 = new StringBuilder();
            for (int i = 0; i < hash.Length; i++)
            {
                montaHashSHA256.Append(hash[i].ToString("X2"));
            }
            return montaHashSHA256.ToString();

        }

        public static string CriptografiaBase64(string item)
        {
            var hash = Convert.FromBase64String(item);
            
            StringBuilder montaHashSHA256 = new StringBuilder();
            for (int i = 0; i < hash.Length; i++)
            {
                montaHashSHA256.Append(hash[i].ToString("X2"));
            }
            return montaHashSHA256.ToString();
           

        }
    }
}
