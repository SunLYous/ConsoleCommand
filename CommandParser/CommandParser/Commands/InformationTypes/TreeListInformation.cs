using SourceKit.Generators.Builder.Annotations;

namespace CommandParser.Commands.InformationTypes;

[GenerateBuilder]
public partial record TreeListInformation(int Depth = 1);