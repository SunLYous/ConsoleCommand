using SourceKit.Generators.Builder.Annotations;

namespace CommandParser.Commands.InformationTypes;
[GenerateBuilder]
public partial record RenameInformation(string SystemPath, string Name);