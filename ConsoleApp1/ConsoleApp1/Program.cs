using System.Text.RegularExpressions;

string res = " Предложение один Теперь предложение два Предложение три ";

RegexOptions options = RegexOptions.None;
Regex regex2 = new Regex(" (?=[А-Я]){1,}", options);
string res2 = regex2.Replace(res, ".");
Regex regex3 = new Regex(@" $", options);
string res3 = regex3.Replace(res2, ".");
Regex regex4 = new Regex(@"^.", options);
string res4 = regex4.Replace(res3, "");
Console.WriteLine(res4);