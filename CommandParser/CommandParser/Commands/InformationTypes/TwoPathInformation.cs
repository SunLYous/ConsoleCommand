using SourceKit.Generators.Builder.Annotations;

namespace CommandParser.Commands.InformationTypes;

[GenerateBuilder]
public partial record TwoPathInformation(string SourceSystemPath, string DestinationSystemPath);