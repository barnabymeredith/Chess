var input = "Qxe1";

if (input[input.Length - 3] == 'x')
{
    // inputType = capture
    input = input.Remove(input.Length - 3, 1);
}

input = input.Remove(input.Length - 2, 2);

input = input.Remove(0, 1);

switch (input.Length) {
    case 1:
        Console.WriteLine("!");
        return;
    case 0:
        Console.WriteLine("Hello");
        return;
}

Console.WriteLine(input);