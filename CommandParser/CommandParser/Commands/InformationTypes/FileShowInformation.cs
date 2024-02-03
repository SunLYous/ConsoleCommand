using CommandParser.Commands.ShowModes;
using SourceKit.Generators.Builder.Annotations;

namespace CommandParser.Commands.InformationTypes;

[GenerateBuilder]
public partial record FileShowInformation(string SystemPath, IShowMode Mode);