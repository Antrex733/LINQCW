using CsvHelper;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;

namespace LINQCW
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string csvPath = @"C:\Users\Antoni\Desktop\googleplaystore1.csv";
            var googleApps = LoadGoogleAps(csvPath);

            //GetData(googleApps);
            ProjectData(googleApps);
        }
        static void ProjectData(IEnumerable<GoogleApp> googleApps)
        {
            var highRatedBeautyApps = googleApps.Where(app => app.Rating > 4.5 && app.Category == Category.BEAUTY);
            var highRatedBeautyAppsNames = highRatedBeautyApps.Select(app => app.Name);

            Console.WriteLine(string.Join(", ", highRatedBeautyAppsNames));

            //Display(highRatedBeautyApps);
        }
        static void GetData(IEnumerable<GoogleApp> googleApps)
        {
            var highRatedApps = googleApps.Where(app => app.Rating > 4.5);
            var highRatedBeutyApps = googleApps.Where(app => app.Rating > 4.5 && app.Category == Category.BEAUTY);
            Display(highRatedBeutyApps);

            var firstHighRatedBeutyApps = highRatedBeutyApps.First(app => app.Reviews > 30);
            Console.WriteLine("firstHighRatedBeutyApps ");
            Console.WriteLine(firstHighRatedBeutyApps);
        }
        static void Display(IEnumerable<GoogleApp> googleApps)
        {
            foreach (var googleApp in googleApps)
            {
                Console.WriteLine(googleApp);
            }
        }

        static void Display(GoogleApp googleApp)
        {
            Console.WriteLine(googleApp);
        }

        static List<GoogleApp> LoadGoogleAps(string csvPath)
        {
            using (var reader = new StreamReader(csvPath))
            using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
            {
                csv.Context.RegisterClassMap<GoogleAppMap>();
                var records = csv.GetRecords<GoogleApp>().ToList();
                return records;
            }

        }
    }
}
