﻿using Microsoft.Extensions.Logging;

namespace Alice.Dialogs.Anegdots.Repository.Services
{
    public interface IAnegdotsSerivce
    {
        string GetRandom();
    }

    public class AnegdotsSerivce : IAnegdotsSerivce
    {
        int LEN = 8;
        private readonly ILogger<AnegdotsSerivce> logger;
        private readonly string[] list;


        public AnegdotsSerivce(ILogger<AnegdotsSerivce> logger)
        {
            this.logger = logger;

            var str = File.ReadAllText($"{AppDomain.CurrentDomain.BaseDirectory}TxtData/nikulin.txt");
            var ls = new List<string>();

            list = str.Split("* * *", StringSplitOptions.RemoveEmptyEntries);
        }

        public string GetRandom()
        {
            var rnd = new Random();
            var r = rnd.Next(list.Length - LEN);
            var str = "";

            for (int i = r; i < r + LEN; i++)
            {
                str += list[i];
            }

            if (str.Length > 1024)
                return str.Substring(0, 1023);
            else
                return str;
        }
    }
}
