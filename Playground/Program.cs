// See https://aka.ms/new-console-template for more information
using Model.Enums;

var myChar = '4';
var myIntFromChar = (int)char.GetNumericValue(myChar);
Console.WriteLine(Enum.IsDefined(typeof(Row), myIntFromChar));