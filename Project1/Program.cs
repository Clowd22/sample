using System;
using System.Collections.Generic;

namespace Project1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var lines = GetStdin();
            if (lines.Length < 3) return;

            double height = double.Parse(lines[0]);
            double weight = double.Parse(lines[1]);
            double aimBmi = double.Parse(lines[2]);

            // 現在のBMIを計算
            double currentBmi = 10000 * weight / (height * height);

            if (currentBmi <= aimBmi)
            {
                // すでに目標BMI以下の場合
                Console.WriteLine(0);
            }
            else
            {
                // 目標BMI以下にするために必要な体重の許容最大値から、逆算して切り上げる
                // 許容できる最大の体重 = (aimBmi * height * height) / 10000
                double maxAllowableWeight = (aimBmi * height * height) / 10000;
                double dropWeight = weight - maxAllowableWeight;

                // 整数にするため切り上げる（例: 0.3 なら 1 にする）
                int result = (int)Math.Ceiling(dropWeight);

                Console.WriteLine(result);
            }
        }

        static private string[] GetStdin()
        {
            var list = new List<string>();
            string line;
            while ((line = Console.ReadLine()) != null && line != "")
            {
                list.Add(line);
            }
            return list.ToArray();
        }
    }
}