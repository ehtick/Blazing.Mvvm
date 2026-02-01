namespace Blazing.Mvvm.Sample.Shared.Models;

public record ConvertHexToAsciiMessage(string HexToConvert);
public record ConvertAsciiToHexMessage(string AsciiToConvert);
public record ResetHexAsciiInputsMessage;
