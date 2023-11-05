using Model.Enums;
using Model.Pieces;
using StateService;

Console.WriteLine("Enter mode.");

var pieces = Machine.StartMatch(Console.ReadLine() ?? "hello");

PrintPieces(pieces);

Console.WriteLine("Make a move");

pieces = Machine.Move(Console.ReadLine() ?? "hello");

Console.WriteLine("gfdgfdfgfdgfg");
Console.WriteLine("gfdgfdfgfdgfg");
Console.WriteLine("gfdgfdfgfdgfg");
Console.WriteLine("gfdgfdfgfdgfg");
Console.WriteLine("gfdgfdfgfdgfg");
Console.WriteLine("gfdgfdfgfdgfg");
Console.WriteLine("gfdgfdfgfdgfg");
Console.WriteLine("gfdgfdfgfdgfg");
Console.WriteLine("gfdgfdfgfdgfg");
Console.WriteLine("gfdgfdfgfdgfg");

PrintPieces(pieces);

static void PrintPieces(List<Piece> pieces)
{
    foreach (var piece in pieces)
    {
        Console.WriteLine(piece.GetType().Name + " " + piece.GetPositionAlgebraicNotation());
    }
}