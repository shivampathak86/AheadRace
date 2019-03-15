using System;

namespace Regression_Suite
{
    internal class ConfigClass
    {
        internal static readonly string Url = "https://ondemand.questionmark.com/home/403160/";

        internal static readonly string UserName = "TechTestUser";

        internal static readonly string Password = "Qs5e8W4T";

        internal static readonly string GenerateRandomEmail_Address = string.Concat(Guid.NewGuid().ToString(), "@gmail.com");
        internal static readonly int Timeout = 30;

        internal static readonly    int[,] ExcelRowsandColumns = new int[,] { { 3, 3 }, { 4, 3 }, { 5, 3 }, { 6, 3 },{ 7, 3 } };
        internal static readonly string[] ExcelCellvalues = new string[] { "TestUser1", "Testuser2", "TestUser3", "TestUser4" ,"Testuser5"};

        internal static readonly string ReadExcelPath = @"C:\Users\patha\Desktop\TestExcel.xlsx";
        internal static readonly string WriteExcelPath = @"C:\Users\patha\Desktop\UpdatedTestExcelByShivam.xlsx";

    }
}