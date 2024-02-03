using CommandParser.Commands.ConnectModes;
using SourceKit.Generators.Builder.Annotations;

namespace CommandParser.Commands.InformationTypes;

[GenerateBuilder]
public partial record ConnectInformation(string Address, IConnectMode ConnectMode);