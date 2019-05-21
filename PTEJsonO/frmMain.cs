using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using OfficeOpenXml;
using OfficeOpenXml.FormulaParsing.Excel.Functions.Logical;

namespace PTEJsonO
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
        }

        private void cmdConvert_Click(object sender, EventArgs e)
        {
            var Content = File.ReadAllLines(@"E:\Desktop\FIB.txt").ToList();
            Console.Write(Content);
            var fitContent = new List<string>();
            var fitMain = new List<string>();
            var fitOptions = new List<string>();
            var fitAnswer = new List<string>();
            //去除无用行
            for (var i = 0; i < Content.Count; i++)
                if (i % 2 != 1)
                {
                    var tempArray = Content[i].Split(new[] {"\":\""}, StringSplitOptions.None);

                    //fitContent.Add(Content[i]);
                    var tempOption = "";
                    var tempAnswer = "";
                    var tempMain = tempArray[1].Replace("\",\"serviceActive\":[{\"selectWords", "")
                        .Replace(@"\u2018", "'").Replace(@"\u2019", "'").Replace(@"\u2013", "-").Replace(@"\u2014", "-")
                        .Replace(@"\u201c", "\"").Replace(@"\u201d", "\"").Replace(@"\n", "").Replace("''", "\"")
                        .Replace(@"\", "");
                    for (var j = 3; j < tempArray.Length; j++)
                    {
                        if (j % 2 == 1)
                        {
                            var tempFArray = tempArray[j].Split(new[] {"\",\""}, StringSplitOptions.None);
                            tempOption = tempOption + "|" + tempFArray[0].Trim().Replace("^", " ");
                            tempAnswer = tempAnswer + "|" + tempFArray[0].Trim().Replace("^", " ");

                            var tempOrderArray = tempFArray[1].Split(new[] {"}"}, StringSplitOptions.None);
                            var tempOrder = tempOrderArray[0].Replace("order\":", "");

                            tempMain = tempMain.Replace(tempFArray[0].Trim(), "[]").Replace("^", " ");
                        }

                        if (j == tempArray.Length - 1)
                        {
                            var tempFArray2 = tempArray[j].Split(new[] {","}, StringSplitOptions.None);
                            foreach (var tempFA in tempFArray2)
                                tempOption = tempOption + "|" +
                                             tempFA.Trim().Replace("\\t", "").Trim().Replace("\"}", "");
                        }
                    }

                    fitMain.Add(Regex.Replace(tempMain, @"\b\s+\b", " "));
                    fitOptions.Add(tempOption.Substring(1).Replace("^", " "));
                    fitAnswer.Add(tempAnswer.Substring(1).Replace("^", " "));
                    //MessageBox.Show(Content[i]);
                }

            Console.Write(fitContent);
            /*
             * var fitMain = new List<string>();
            var fitOptions = new List<string>();
            var fitAnswer = new List<string>();
             */
            var fileName = "FIB-" + DateTime.Now.ToString("yyyy-MM-dd--hh-mm-ss") + ".xlsx";
            var file = new FileInfo(fileName);
            using (var package = new ExcelPackage(file))
            {
                var worksheet = package.Workbook.Worksheets.Add("RFIB - " + DateTime.Now.ToShortDateString());

                for (var i = 0; i < fitMain.Count; i++)
                {
                    worksheet.Cells[i + 1, 1].Value = fitMain[i];
                    worksheet.Cells[i + 1, 2].Value = fitOptions[i];
                    worksheet.Cells[i + 1, 3].Value = fitAnswer[i];
                }

                package.Save();
            }
        }


        private void cmdConvert2_Click(object sender, EventArgs e)
        {
            var Content = File.ReadAllLines(@"E:\Desktop\105.txt").ToList();
            Console.Write(Content);
            var fitContent = new List<string>();
            var fitMain = new List<string>();
            var fitOptions = new List<string>();
            var fitAnswer = new List<string>();
            //去除无用行
            for (var i = 0; i < Content.Count; i++)
                if (i % 2 != 1)
                {
                    var tempArray = Content[i].Split(new[] {"\":\""}, StringSplitOptions.None);

                    //fitContent.Add(Content[i]);
                    var tempOption = "";
                    var tempAnswer = "";
                    var tempMain = tempArray[1].Replace("\",\"serviceActive\":[{\"selectWords", "")
                        .Replace(@"\u2018", "'").Replace(@"\u2019", "'").Replace(@"\u2013", "-").Replace(@"\u2014", "-")
                        .Replace(@"\u201c", "\"").Replace(@"\u201d", "\"").Replace(@"\n", "").Replace("''", "\"")
                        .Replace(@"\", "");
                    for (var j = 2; j < tempArray.Length; j++)
                        if (j % 2 == 0)
                        {
                            var tempFArray = tempArray[j].Split(new[] {"\""}, StringSplitOptions.None);
                            var tempFArray2 = tempFArray[0].Split(new[] {","}, StringSplitOptions.None);
                            foreach (var tempFA in tempFArray2)
                                tempOption = tempOption + "|" + tempFA.Replace("\\t", "").Trim();
                        }
                        else
                        {
                            var tempFArray = tempArray[j].Split(new[] {"\""}, StringSplitOptions.None);
                            tempOption = tempOption + "|" + tempFArray[0].Replace("\\t", "").Replace("^", " ").Trim();
                            tempAnswer = tempAnswer + "|" + tempFArray[0].Replace("\\t", "").Replace("\\n", "")
                                             .Replace(".", "").Replace("^", " ").Trim();
                            tempMain = tempMain.Replace(tempFArray[0].Trim(), "[]");
                            tempOption = tempOption.Replace("^", " ") + "\\";
                        }

                    tempAnswer = tempAnswer.Replace("^", " ");
                    fitMain.Add(tempMain);
                    tempOption = tempOption.Substring(1).Replace("\\|", "\\");
                    tempOption = tempOption.Substring(0, tempOption.Length - 1);
                    fitOptions.Add(tempOption.Replace("^", " "));
                    fitAnswer.Add(tempAnswer.Substring(1).Replace("^", " "));
                    //MessageBox.Show(Content[i]);
                }

            Console.Write(fitContent);
            /*
             * var fitMain = new List<string>();
            var fitOptions = new List<string>();
            var fitAnswer = new List<string>();
             */
            var fileName = "RWFIB-" + DateTime.Now.ToString("yyyy-MM-dd--hh-mm-ss") + ".xlsx";
            var file = new FileInfo(fileName);
            using (var package = new ExcelPackage(file))
            {
                var worksheet = package.Workbook.Worksheets.Add("RFIB - " + DateTime.Now.ToShortDateString());

                for (var i = 0; i < fitMain.Count; i++)
                {
                    worksheet.Cells[i + 1, 1].Value = fitMain[i];
                    worksheet.Cells[i + 1, 2].Value = fitOptions[i];
                    worksheet.Cells[i + 1, 3].Value = fitAnswer[i];
                }

                package.Save();
            }
        }

        private void cmdConvert3_Click(object sender, EventArgs e)
        {
            var Content = File.ReadAllLines(@"E:\Desktop\105.txt").ToList();
            Console.Write(Content);
            var fitContent = new List<string>();
            var fitMain = new List<string>();
            string[] wordList;
            var realwordList = new List<string>();
            var fitOptions = new List<string>();
            //var fitAnswer = new List<string>();
            //去除无用行
            for (var i = 0; i < Content.Count; i++)
                if (i % 2 != 1)
                {
                    var tempArray = Content[i].Split(new[] {"\":\""}, StringSplitOptions.None);

                    //fitContent.Add(Content[i]);
                    var tempOption = "";
                    //var tempAnswer = "";

                    var tempMain = tempArray[1].Replace("\",\"serviceActive\":[{\"selectWords", "")
                        .Replace(@"\u2018", "'").Replace(@"\u2019", "'").Replace(@"\u2013", "-").Replace(@"\u2014", "-")
                        .Replace(@"\u201c", "\"").Replace(@"\u201d", "\"").Replace(@"\n", "").Replace("''", "\"")
                        .Replace(@"\", "").Replace("^", " ");
                    Regex.Replace(tempMain, @"\b\s+\b", " ");
                    wordList = tempMain.Split(' ');
                    tempMain = "";
                    foreach (var tempStr in wordList)
                    {
                        if (tempStr.Contains("'"))
                        {
                            var tempDash = tempStr.Split('\'');

                            realwordList.Add(tempDash[0]);
                            realwordList.Add("'");
                            if (tempDash[1] != "") realwordList.Add(tempDash[1]);

                            continue;
                        }

                        if (tempStr.Contains("\""))
                        {
                            realwordList.Add(tempStr.Replace("\"", ""));
                            realwordList.Add("\"");
                            continue;
                        }

                        if (tempStr.Contains("-"))
                        {
                            var tempDash = tempStr.Split('-');

                            realwordList.Add(tempDash[0]);
                            realwordList.Add("-");
                            realwordList.Add(tempDash[1]);
                            continue;
                        }

                        if (tempStr.Contains(","))
                        {
                            realwordList.Add(tempStr.Replace(",", ""));
                            realwordList.Add(",");
                            continue;
                        }

                        if (tempStr.Contains("["))
                        {

                            var tempDash = tempStr.Split('[');

                            realwordList.Add(tempDash[0]);
                            realwordList.Add("[");
                            if (tempDash[1] != "") realwordList.Add(tempDash[1]);

                            continue;
                        }

                        if (tempStr.Contains("]"))
                        {
                            realwordList.Add(tempStr.Replace("]", ""));
                            realwordList.Add("]");
                            continue;

                            var tempDash = tempStr.Split(']');

                            if (tempDash[0] != "") realwordList.Add(tempDash[0]);
                            realwordList.Add("]");
                            if (tempDash[1] != "") realwordList.Add(tempDash[1]);

                            continue;
                        }

                        if (tempStr.Contains("!"))
                        {
                            realwordList.Add(tempStr.Replace("!", ""));
                            realwordList.Add("!");
                            continue;
                        }
             

                        if (tempStr.Contains(":"))
                        {
                            realwordList.Add(tempStr.Replace(":", ""));
                            realwordList.Add(":");
                            continue;
                        }

                        if (tempStr.Contains("("))
                        {
                            realwordList.Add(tempStr.Replace("(", ""));
                            realwordList.Add("(");
                            continue;
                        }

                        if (tempStr.Contains(")"))
                        {
                            realwordList.Add(tempStr.Replace(")", ""));
                            realwordList.Add(")");
                            continue;
                        }

                        if (tempStr.Contains(";"))
                        {
                            realwordList.Add(tempStr.Replace(";", ""));
                            realwordList.Add(";");
                            continue;
                        }

                        if (tempStr.Contains("."))
                        {
                            realwordList.Add(tempStr.Replace(".", ""));
                            realwordList.Add(".");
                            continue;
                        }

                        if (tempStr.Contains("…"))
                        {
                            realwordList.Add(tempStr.Replace("…", ""));
                            realwordList.Add("…");
                            continue;
                        }

                        if (tempStr.Contains("?"))
                        {
                            realwordList.Add(tempStr.Replace("?", ""));
                            realwordList.Add("?");
                            continue;
                        }

                        

                        realwordList.Add(tempStr);
                    }

                    for (var j = 3; j < tempArray.Length; j++)
                    {
                        if (j % 2 == 1)
                        {
                            var tempFArray = tempArray[j].Split(new[] {"\",\""}, StringSplitOptions.None);
                            tempOption = tempOption + "|" + tempFArray[0].Trim().Replace("^", " ");
                            //tempAnswer = tempAnswer + "|" + tempFArray[0].Trim().Replace("^", " ");

                            var tempOrderArray = tempFArray[1].Split(new[] {"}"}, StringSplitOptions.None);
                            var tempOrder = tempOrderArray[0].Replace("order\":", "");
                            try
                            {
                                realwordList[int.Parse(tempOrder)] = "|" + realwordList[int.Parse(tempOrder)] + "|";
                            }
                            catch (Exception exception)
                            {
                                Console.WriteLine(exception);
                                //throw;
                            }
                            
                        }
                        if (j == tempArray.Length - 1)
                        {
                            var tempFArray2 = tempArray[j].Split(new[] { "," }, StringSplitOptions.None);
                            foreach (var tempFA in tempFArray2)
                                tempOption = tempOption + "|" +
                                             tempFA.Trim().Replace("\\t", "").Trim().Replace("\"}", "");
                        }
                    }

                    for (var k = 0; k < realwordList.Count; k++)
                    {
                        if (k != realwordList.Count -1)
                        {
                            if (realwordList[k] != " " && realwordList[k + 1] != "." && realwordList[k + 1] != "," && realwordList[k + 1] != "!" && realwordList[k + 1] != "'")
                            {
                                tempMain += realwordList[k] + " ";
                            }
                            else
                            {
                                tempMain += realwordList[k];
                            }
                        }
                        else
                        {
                            tempMain += realwordList[k];
                        }
                        
                    }

                    realwordList.Clear();

                    fitMain.Add(tempMain);
                    fitOptions.Add(tempOption.Substring(1).Replace("^", " "));
                    //fitAnswer.Add(tempAnswer.Substring(1).Replace("^", " "));
                    //MessageBox.Show(Content[i]);
                }

            Console.Write(fitContent);
            /*
             * var fitMain = new List<string>();
            var fitOptions = new List<string>();
            var fitAnswer = new List<string>();
             */
            var fileName = "105-" + DateTime.Now.ToString("yyyy-MM-dd--hh-mm-ss") + ".xlsx";
            var file = new FileInfo(fileName);
            using (var package = new ExcelPackage(file))
            {
                var worksheet = package.Workbook.Worksheets.Add("105 - " + DateTime.Now.ToShortDateString());

                for (var i = 0; i < fitMain.Count; i++)
                {
                    worksheet.Cells[i + 1, 1].Value = fitMain[i];
                    worksheet.Cells[i + 1, 2].Value = fitOptions[i];
                }
                    
                //worksheet.Cells[i + 1, 3].Value = fitAnswer[i];

                package.Save();
            }
        }
    }
}